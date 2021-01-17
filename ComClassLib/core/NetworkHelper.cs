using System;
using System.Collections.Generic;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Text;
using System.Threading;
//网络连接操作
namespace ComClassLib.core {
    public class NetworkHelper {
        //定义主机的IP及端口 
        private IPAddress Ipaddress;
        private IPEndPoint IpEnd;
        private Socket ConnSocket;
        public static Action<DataType.NetTaskCmd> CallFunc { get; set; } //回调函数
        // bool IsConnect;
        public NetworkHelper(string _ip, int iPort) {
            //定义主机的IP 
            Ipaddress = IPAddress.Parse(_ip);
            //将IP地址和端口号绑定到网络节点endpoint上
            IpEnd = new IPEndPoint(Ipaddress, iPort); //端口号
            IsTCPClient = true;
            th = new Thread(Receive);
        }


        public object _lock = new object();
        Thread th = null;
        public bool ConnectSvr() {
            //尝试连接--采用同步方法
            try {
                lock (_lock) {
                    //重新链接
                    if (ConnSocket != null && !ConnSocket.Connected) {
                        ConnSocket.Close();
                    } //定义套接字类型
                    ConnSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                    ConnSocket.Connect(IpEnd);
                    IsTCPClient = true;
                }
            } catch (SocketException) {
                //Console.Write("Fail to connect server");
                // Console.Write(e.ToString());
                return false;
            }
            return true;
        }
        private bool IsTCPClient = false;
        public void Close() {
            th.Abort();
            IsTCPClient = false;
        }
        /// <summary>
        /// 任务监听一直打开
        /// </summary>
        public void Receive() {
            while (IsTCPClient) {
                while (ConnSocket == null || !ConnSocket.Connected) {
                    ConnectSvr();//链接失败 反复尝试
                    CallFunc?.Invoke(DataType.NetTaskCmd.Disconn);
                    //Console.Write("Fail to connect server");
                }
                try {
                    //定义接收数据的长度
                    byte[] data = new byte[1024];
                    int recv = ConnSocket.Receive(data);
                    CallFunc?.Invoke(DataType.NetTaskCmd.Conn);
                    if (recv == 0) {//服务器断开 重新连接
                        CallFunc?.Invoke(DataType.NetTaskCmd.Reconn);
                        continue;
                    } else {
                        int cmdState = BitConverter.ToInt32(data, 6);
                        if (1 == cmdState) {
                            CallFunc?.Invoke(DataType.NetTaskCmd.TaskStart);
                        } else
                        if (2 == cmdState) {
                            CallFunc?.Invoke(DataType.NetTaskCmd.TaskEnd);
                        }
                    }
                } catch { }
            }
        }
        //返回所有的IP地址
        public static List<string> GetIPs() {
            List<string> ips = new List<string>();
            NetworkInterface[] NetworkInterfaces = NetworkInterface.GetAllNetworkInterfaces();
            foreach (NetworkInterface NetworkIntf in NetworkInterfaces) {
                IPInterfaceProperties IPInterfaceProperties = NetworkIntf.GetIPProperties();
                UnicastIPAddressInformationCollection UnicastIPAddressInformationCollection = IPInterfaceProperties.UnicastAddresses;
                foreach (UnicastIPAddressInformation UnicastIPAddressInformation in UnicastIPAddressInformationCollection) {
                    if (UnicastIPAddressInformation.Address.AddressFamily == AddressFamily.InterNetwork) {
                        string ip = UnicastIPAddressInformation.Address.ToString();
                        string firstIp = ip.Substring(0, 3);
                        if (firstIp == "169" || firstIp == "127") {
                            continue;
                        }

                        ips.Add(ip);
                    }
                }
            }
            return ips;
        }
        public void Send(byte[] buffer) {
            if (ConnSocket == null || !ConnSocket.Connected) {
                ConnectSvr();
                CallFunc?.Invoke(DataType.NetTaskCmd.Disconn);
            }
            //byte[] buffer = Encoding.ASCII.GetBytes("00 00 00 00 00 06 01 05 00 04 00 00"); ;
            ConnSocket.Send(buffer);
        }



    }
    public class UDPHelper {
        UdpClient udpcRecv = null;
        IPEndPoint ipEnd = null;
        bool IsUdpcRecvStart; //开关
        Thread thrRecv;
        public static Action<string> CallFunc { get; set; } //回调函数

        public UDPHelper(string ip, int udpPort) {
            try {
                ipEnd = new IPEndPoint(IPAddress.Parse(ip), udpPort);
                Console.WriteLine(ip);
                udpcRecv = new UdpClient(ipEnd);
                thrRecv = new Thread(ReceivMsg);
                IsUdpcRecvStart = false;

            } catch(Exception ex) { Console.WriteLine(ex.ToString()); }
        }
        public void StartReceive() {
            if (!IsUdpcRecvStart) { //开始监听            
                thrRecv.Start();
                IsUdpcRecvStart = true;
            }
        }

        public void StopReceive() {
            if (IsUdpcRecvStart) {
                try {
                    if (thrRecv.IsAlive) {
                        thrRecv.Abort();
                    }
                    udpcRecv.Close();
                    IsUdpcRecvStart = false;
                } catch { }
            }
        }
        public void ReceivMsg() {
            while (IsUdpcRecvStart) {
                try {
                    byte[] bytRecv = udpcRecv.Receive(ref ipEnd);
                    string msg = Encoding.ASCII.GetString(bytRecv, 0, bytRecv.Length);

                    CallFunc?.Invoke(msg);
                    //Thread.Sleep(5000);
                } catch (Exception ex) {
                   // MsgBox.Show("UDP接收数据错误：" + ex.ToString());
                }
            }
        }
    }

    public class TCPHelper {
        private static TcpClient tcpClient;
        private static NetworkStream networkStream;
        public static List<byte[]> ResponseBytes = new List<byte[]>();
        public static string RemoteIp = string.Empty;
        public static int RemotePort = -1;
        public static bool IsConnected = false;
        public static void ConnectToServer(string servIp, int port) {
            try {
                tcpClient = new TcpClient();
                tcpClient.BeginConnect(IPAddress.Parse(servIp), port, new AsyncCallback(AsynConnect), tcpClient);
            } catch (Exception) {
            }
        }

        private static void AsynConnect(IAsyncResult ar) {
            try {
                tcpClient.EndConnect(ar);
                IsConnected = true;
                networkStream = tcpClient.GetStream();
                byte[] tempByte = new byte[1024];
                networkStream.BeginRead(tempByte, 0, tempByte.Length, new AsyncCallback(AsynReceiveData), tempByte);
            } catch (Exception) {
            }
        }
        //接收数据
        private static void AsynReceiveData(IAsyncResult ar) {
            byte[] CurrDatas = (byte[])ar.AsyncState;
            try {
                int num = networkStream.EndRead(ar);
                ResponseBytes.Add(CurrDatas);
                byte[] newBytes = new byte[1024];
                networkStream.BeginRead(newBytes, 0, newBytes.Length, new AsyncCallback(AsynReceiveData), newBytes);
                string smg = Encoding.ASCII.GetString(newBytes);
                Console.WriteLine("测试--接收到的信息为：" + smg);
            } catch (Exception ex) {
               // MsgBox.Show("TCP 接收数据错误" + ex.ToString());
            }
        }

        //发送数据
        public static void SendData(byte[] datas) {
            try {
                if (networkStream.CanWrite && datas != null && datas.Length > 0) {
                    networkStream.Write(datas, 0, datas.Length);
                    networkStream.Flush();
                }
            } catch (Exception) {
                if (tcpClient != null) {
                    tcpClient.Close();
                    IsConnected = false;
                }
            }
        }
        public static void Close() {
            IsConnected = false;
            tcpClient.Close();
        }
    }

}
