﻿using System;
using System.Data;
using System.Runtime.InteropServices;

namespace JCW
{

    /// <summary>
    /// 常量定义
    /// </summary>
    public class JcwDefine
    {
        /// <summary>
        /// 检测结果的无效值
        /// </summary>
        public const int JCW_INVALIDVALUE = 0x10000;

        /// <summary>
        /// 几何参数检测最大导线数量
        /// </summary>
        public const int JCWJH_MAX_LINE_NUM = 4;
        
        /// <summary>
        /// 动态库名称
        /// </summary>
        public const string JcwDllName = "jcwlib.dll";
    };



    /// <summary>
    /// 功能函数的返回值
    /// </summary>
    public enum JcwReturn
    {
        JCW_OK = 0,                 //执行正确完成
        JCW_ERROR_UNKNOW = -1,      //发生未知错误
        JCW_INVALID_HANDLE = -2,        //无效的实例句柄
        JCW_ERR_INVALID_DEVID = -3, //无效设备ID
        JCW_ERR_ALREADY_START = -4, //已启动，不能更改设置
        JCW_ERR_NO_START = -5,          //未启动，不能更改设置
        JCW_ERR_INVALID_PARAMETER = -6, //无效参数值，参数超出有效范围，或者参数组合无效
        JCW_ERR_CFG_FILE_NO_EXIST = -7, //文件不存在
        JCW_ERR_CFG_INVALID_CONTENT = -8,   //配置文件无效内容，或者文件格式不正确 
        JCW_ERR_CFG_DEVICE_NULL = -9,   //未配置设备，设备的配置数量为空
        JCW_ERR_CREATE_COMM_FAIL = -10, //创建通信失败
        JCW_ERR_DEV_CONN_FAIL = -11,    //链接到设备失败

        JCW_ERR_NOIMPLEMENT = -404,	//未实现
    };

    /// <summary>
    /// //设备ID编制
    /// </summary>
    public enum JMID
    {
        JMID_GLOBAL = 0,        //全局对象，不能用来创建设备

        JMID_COMP_LEFT = 1,     //左补偿
        JMID_COMP_RIGHT = 2,    //右补偿

        JMID_GEO_DEV0 = 11,     //几何参数1
        JMID_GEO_DEV1 = 12,     //几何参数2
        JMID_GEO_DEV2 = 13,     //几何参数3
        JMID_GEO_DEV3 = 14,
        JMID_GEO_DEV4 = 15,
        JMID_GEO_DEV5 = 16,
        JMID_GEO_DEV6 = 17,
        JMID_GEO_DEV7 = 18,


        JMID_TRACK3_LEFT = 21,  //第三轨左轨
        JMID_TRACK3_RIGHT = 22, //第三轨右轨
    };



    /// <summary>
    /// 定位类型
    /// </summary>
    public enum JCWPosi
    {
        JCXP_UNKNOW = 0,    //未知
        JCXP_LINE = 1,      //导线位置
        JCXP_DROPPER = 2,   //吊弦位置
        JCXP_POLE = 3,      //支柱位置
        JCXP_ELECCONN = 4,  //电连接
        JCXP_MAO = 5,       //锚段关节位置
    };          


    /// <summary>
    /// //接触线类型
    /// </summary>
    public enum JCXType
    {
        JCXT_UNKNOW = 0,    //未知导线类型
        JCXT_FLEX = 1,      //柔性导线
        JCXT_RIGI = 2,      //刚性导线
        JCXT_TRACK3 = 3,    //第三轨
    };

    /// <summary>
    /// 接触网类型
    /// </summary>
    public enum JCWType
    {
        JCWT_UNKNOW = 0,        //未知导线类型
        JCWT_LINE_1 = 1,        //单支导线
        JCWT_LINE_2 = 2,        //双支导线
        JCWT_MAO_1 = 3,         //单支导线锚段关节
        JCWT_MAO_2 = 4,         //双支导线锚段关节
        JCWT_RF_1 = 5,          //刚柔混合
        JCWT_RF_2 = 6,          //双支柔性，刚柔混合

    };

    /// <summary>
    /// 浮点坐标
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 4)]
    public struct POINTF
    {
        public float x;
        public float y;
    };


    /// <summary>
    /// 接触线磨耗值
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 4)]

    public struct JCXMH
    {
        /// <summary>
        /// 导线直径，指定导线的类型.单位(um);eg 13200,15200
        /// </summary>
        public Int32 iLineRidus_UM;     //
        /// <summary>
        /// 磨损的厚度(mm)	 <=0 = 无效值，表示未测量到结果；有效测量最小值 >=0.01
        /// </summary>
        public float fMsH;              //
        /// <summary>
        /// 剩余的厚度(mm)	 <= 0 = 无效值，表示未测量到结果 有效测量最小值 >=0.01
        /// </summary>
        public float fSyH;              //
        /// <summary>
        /// 底面的长度(mm)	 <= 0 = 无效值，表示未测量到结果 有效测量最小值 >=0.01
        /// </summary>
        public float fBotLen;           
    };


    /// <summary>
    /// 接触线测量数据
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 4)]
    public struct JCXData
    {
        /// <summary>
        /// 导线空间位置;x = 拉出值; y = 导高
        /// </summary>
        public POINTF pntLinePos;
        /// <summary>
        /// 磨耗值
        /// </summary>
        public JCXMH mh;
        /// <summary>
        /// 接触线类型
        /// </summary>
        public JCXType lt;         
        /// <summary>
        /// 导线是否定位导线
        /// </summary>
        public JCWPosi posi;       
    };

    /// <summary>
    /// 接触网几何参数检测结果结构体
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 4 )]
    public struct JCWJH
    {
        public Int16 sVersion;     //数据的版本
        public Int16 sBagSize;     //数据包大小

        /// <summary>
        /// 数据来源于哪个设备的索引
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = JcwDefine.JCWJH_MAX_LINE_NUM)] 
        public char[] ucDataDevSrcIndex;
        /// <summary>
        /// 同步的ID
        /// </summary>
        public UInt64 uiSyncID;
        /// <summary>
        /// 接收时候的时间戳
        /// </summary>
        public double dTimestamp;

        /// <summary>
        /// 测量的时间，参考windows FILETIME
        /// </summary>
        public UInt64 uiFileTime;

        /// <summary>
        /// 测量到的导线数量，对应 数组：jcx
        /// </summary>
        public UInt32 uiLineNum;

        /// <summary>
        /// 未补偿的几何参数，通过 uiLineNum 表示有效内容数量
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = JcwDefine.JCWJH_MAX_LINE_NUM)] 
        public JCXData[] jcx;

        /// <summary>
        /// 补偿后的几何参数;通过 uiLineCompsateNum 表示有效内容数量
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = JcwDefine.JCWJH_MAX_LINE_NUM)] 
        public JCXData[] jcxComp;

        /// <summary>
        /// 左补偿
        /// </summary>
        public POINTF pntCompLeft;
        /// <summary>
        /// 右补偿
        /// </summary>
        public POINTF pntCompRight;

        /// <summary>
        /// 是否定位点
        /// </summary>
        public JCWPosi posi;  
       
        /// <summary>
        /// 导线的类型
        /// </summary>
        public JCXType lt;                 
        /// <summary>
        /// 补偿后有效的导线数量，对应数组:jcxComp
        /// </summary>
        public UInt32 uiLineCompsateNum;

        public void LoadData(DataRow dr) {
            if (dr == null) return;
            dTimestamp = Convert.ToDouble(dr["time_stamp"]);
            uiFileTime = Convert.ToUInt64(dr["file_time"]);
            ucDataDevSrcIndex = new char[1];
            ucDataDevSrcIndex[0] = Convert.ToChar(dr["ucDataDevSrc"]);
            uiSyncID = Convert.ToUInt64(dr["uiSyncID"]);
            uiLineNum = Convert.ToUInt32(dr["uiLineNum"]);
            posi = (JCWPosi)Convert.ToInt32(dr["posi"]);
            lt= (JCXType)Convert.ToInt32(dr["lt"]);
            uiLineCompsateNum= Convert.ToUInt32(dr["uiLineCompsateNum"]);
            pntCompLeft = new POINTF();
            pntCompLeft.x = Convert.ToSingle(dr["CxLeft"]);
            pntCompLeft.y = Convert.ToSingle(dr["CyLeft"]);
            pntCompRight = new POINTF();
            pntCompRight.x =  Convert.ToSingle(dr["CxRight"]);
            pntCompRight.y =  Convert.ToSingle(dr["CyRight"]);
            #region JCXData jcx
            jcx = new JCXData[4];
            jcx[0] = new JCXData();
            jcx[0].pntLinePos = new POINTF() {  x= Convert.ToSingle(dr["jhx1"]) ,y=Convert.ToSingle(dr["jhy1"])};
            jcx[0].mh = new JCXMH();
            jcx[0].mh.fMsH = Convert.ToSingle(dr["mh1"]);
            jcx[0].lt = (JCXType)Convert.ToInt32(dr["lt1"]);
            jcx[0].posi= (JCWPosi)Convert.ToInt32(dr["posi1"]);
            //
            jcx[1] = new JCXData();
            jcx[1].pntLinePos = new POINTF() { x = Convert.ToSingle(dr["jhx2"]), y = Convert.ToSingle(dr["jhy2"]) };
            jcx[1].mh = new JCXMH();
            jcx[1].mh.fMsH = Convert.ToSingle(dr["mh2"]);
            jcx[1].lt = (JCXType)Convert.ToInt32(dr["lt2"]);
            jcx[1].posi = (JCWPosi)Convert.ToInt32(dr["posi2"]);
            //
            jcx[2] = new JCXData();
            jcx[2].pntLinePos = new POINTF() { x = Convert.ToSingle(dr["jhx3"]), y = Convert.ToSingle(dr["jhy3"]) };
            jcx[2].mh = new JCXMH();
            jcx[2].mh.fMsH = Convert.ToSingle(dr["mh3"]);
            jcx[2].lt = (JCXType)Convert.ToInt32(dr["lt3"]);
            jcx[2].posi = (JCWPosi)Convert.ToInt32(dr["posi3"]);
            //
            jcx[3] = new JCXData();
            jcx[3].pntLinePos = new POINTF() { x = Convert.ToSingle(dr["jhx4"]), y = Convert.ToSingle(dr["jhy4"]) };
            jcx[3].mh = new JCXMH();
            jcx[3].mh.fMsH = Convert.ToSingle(dr["mh4"]);
            jcx[3].lt = (JCXType)Convert.ToInt32(dr["lt4"]);
            jcx[3].posi = (JCWPosi)Convert.ToInt32(dr["posi4"]);
            #endregion
            jcxComp = new JCXData[4];
            //
            jcxComp[0] = new JCXData();
            jcxComp[0].pntLinePos=new POINTF() { x = Convert.ToSingle(dr["jhcx1"]), y = Convert.ToSingle(dr["jhcy1"]) };
            //
            jcxComp[1] = new JCXData();
            jcxComp[1].pntLinePos = new POINTF() { x = Convert.ToSingle(dr["jhcx2"]), y = Convert.ToSingle(dr["jhcy2"]) };
            //
            jcxComp[2] = new JCXData();
            jcxComp[2].pntLinePos = new POINTF() { x = Convert.ToSingle(dr["jhcx3"]), y = Convert.ToSingle(dr["jhcy3"]) };
            //
            jcxComp[3] = new JCXData();
            jcxComp[3].pntLinePos = new POINTF() { x = Convert.ToSingle(dr["jhcx4"]), y = Convert.ToSingle(dr["jhcy4"]) };
            #region JCXData jcxComp[]
            #endregion

        }
    };


    /*
     * 
     * 
     * 
	//功能：设置单一设备的检测数据的回调
	JCW_RET Jcw_SetDevResultCallBack(JCWHANDLE h, JMDEVID id, const void* pTag, Jcw_fnJCWResultCallBack fnCB);


	//点云回调函数
	//UINT64	系统同步id，或者帧号
	//UINT		单帧图像的第n组数据
	//POINTF*	点云的空间点
	//UINT		2d点的数量
	typedef void(*___Jcw_fnPointCloudCallBack_)(const void*, UINT64, UINT, const POINTF*, const UINT);


        

	//获取指定功能数据的传输频率
	JCW_RET Jcw_GetFuncFPS(JCWHANDLE h, JMDEVID jid, int imid, OUT float& fFPS);


	//功能：采集检测目标的轮廓点
	//iGrabState 是否采集
	JCW_RET Jcw_GrabTargetProfile(JCWHANDLE h, JMDEVID id, int iGrabState);


	//设置图像点云的回调，传输的是压缩包
	typedef void(*Jcw_fnLaserPointCouldCallBack)(const void*, JMDEVID id, SyncData sid, USHORT usOffsetX, USHORT usOffsetY, UINT uiImageWidth, float* fImageY, UCHAR* ucGrayConstant);
	JCW_RET Jcw_SetLaserPointCouldCallBack(JCWHANDLE h, const void* pTag, Jcw_fnLaserPointCouldCallBack fnCB);

	//保存激光点文件
	JCW_RET Jcw_CreateLaserPointFile(JCWHANDLE h, const char* strFilePath);

	JCW_RET Jcw_CloseLaserPointFile(JCWHANDLE h);
     * 
     * 
     */


    /// <summary>
    /// 衍衍科技提供的检测网几何参数检测通信库
    /// </summary>
    public class jcwlib
    {

        [DllImport(JcwDefine.JcwDllName, EntryPoint = "Jcw_GetLibVersionStr", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        private static extern IntPtr _Jcw_GetLibVersionStr();

        /// <summary>
        /// 获取开发库版本号
        /// const char* Jcw_GetLibVersionStr();
        /// </summary>
        /// <returns></returns>
        public static string Jcw_GetLibVersionStr()
        {
            IntPtr ipName = _Jcw_GetLibVersionStr();
            return Marshal.PtrToStringAnsi(ipName);
        }

        /// <summary>
        /// 功能：构造一个实例
        /// JCWHANDLE Jcw_InitInstance();
        /// </summary>
        /// <returns></returns>
        [DllImport(JcwDefine.JcwDllName, EntryPoint = "Jcw_InitInstance", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern IntPtr Jcw_InitInstance();

        /// <summary>
        /// //功能：释放一个实例
        /// JCW_RET Jcw_UninitInstance(JCWHANDLE h);
        /// </summary>
        /// <param name="hjcw"></param>
        /// <returns></returns>

        [DllImport(JcwDefine.JcwDllName, EntryPoint = "Jcw_UninitInstance", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern JcwReturn Jcw_UninitInstance(IntPtr hjcw);


        /// <summary>
        /// //读取一份配置
        /// JCW_RET Jcw_LoadConfig(JCWHANDLE h, const char* strCfgFile);
        /// </summary>
        /// <param name="hjcw"></param>
        /// <param name="strCfgFile"></param>
        /// <returns></returns>
        [DllImport(JcwDefine.JcwDllName, EntryPoint = "Jcw_LoadConfig", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern JcwReturn Jcw_LoadConfig(IntPtr hjcw, string strCfgFile);


        /// <summary>
        /// 写入配置文件
	    /// JCW_RET Jcw_SaveConfig(JCWHANDLE h, const char* strCfgFile);
        /// </summary>
        /// <param name="hjcw"></param>
        /// <param name="strCfgFile"></param>
        /// <returns></returns>
        [DllImport(JcwDefine.JcwDllName, EntryPoint = "Jcw_SaveConfig", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern JcwReturn Jcw_SaveConfig(IntPtr hjcw, string strCfgFile);

        
        
        /// <summary>
        /// 功能：启动数据接收工作，设置参数完毕后调用本接口
        /// JCW_RET Jcw_Start(JCWHANDLE h);
        /// </summary>
        /// <param name="hjcw"></param>
        /// <param name="strCfgFile"></param>
        /// <returns></returns>
        [DllImport(JcwDefine.JcwDllName, EntryPoint = "Jcw_Start", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern JcwReturn Jcw_Start(IntPtr hjcw);



        /// <summary>
        /// 功能：停止数据接收工作
        /// JCW_RET Jcw_Stop(JCWHANDLE h);
        /// </summary>
        /// <param name="hjcw"></param>
        /// <returns></returns>
        [DllImport(JcwDefine.JcwDllName, EntryPoint = "Jcw_Stop", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern JcwReturn Jcw_Stop(IntPtr hjcw);


        /// <summary>
        /// JCW_RET Jcw_IsStart(JCWHANDLE h, int& iState);
        /// </summary>
        /// <param name="hjcw"></param>
        /// <param name="iState"></param>
        /// <returns></returns>
        [DllImport(JcwDefine.JcwDllName, EntryPoint = "Jcw_IsStart", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern JcwReturn Jcw_IsStart(IntPtr hjcw, ref int iState);



        /// <summary>
        /// 功能：返回设备的连接状态，状态值参数以上枚举变量值
        /// JCW_RET Jcw_GetDevState(JCWHANDLE h, JMDEVID id, OUT int& iState);
        /// </summary>
        /// <param name="hjcw"></param>
        /// <param name="id"></param>
        /// <param name="iState">
        /// JCW_DEVSTATE_NOWORK = -1,           //未工作 
        /// JCW_DEVSTATE_DISCONNECT = 0,        //未连接
        /// JCW_DEVSTATE_WORKING = 1,           //正常工作状态
        /// </param>
        /// <returns> </returns>
        [DllImport(JcwDefine.JcwDllName, EntryPoint = "Jcw_GetDevState", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern JcwReturn Jcw_GetDevState(IntPtr hjcw, JMID id, ref int iState);


        /// <summary>
        /// 功能：获取设备的测量帧率
        /// JCW_RET Jcw_GetDevFPS(JCWHANDLE h, JMDEVID id, OUT float& fFPS);
        /// </summary>
        /// <param name="hjcw"></param>
        /// <param name="id"></param>
        /// <param name="fFPS"></param>
        /// <returns></returns>
        [DllImport(JcwDefine.JcwDllName, EntryPoint = "Jcw_GetDevFPS", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern JcwReturn Jcw_GetDevFPS(IntPtr hjcw, JMID id, ref float fFPS);


        /// <summary>
        /// 功能：获取设备连接的时长，单位秒(s)
        /// JCW_RET Jcw_GetDevConnTime(JCWHANDLE h, JMDEVID id, OUT UINT& uiTimeSec);
        /// </summary>
        /// <param name="hjcw"></param>
        /// <param name="id"></param>
        /// <param name="uiTimeSec"></param>
        /// <returns></returns>
        [DllImport(JcwDefine.JcwDllName, EntryPoint = "Jcw_GetDevConnTime", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern JcwReturn Jcw_GetDevConnTime(IntPtr hjcw, JMID id, ref uint uiTimeSec);


        /// <summary>
        /// 功能：设置设备连接地址信息
        /// JCW_RET Jcw_SetDevAddress(JCWHANDLE h, JMDEVID id, const char* strDevIP, UINT uiDevPort);
        /// </summary>
        /// <param name="hjcw"></param>
        /// <param name="id">设备ID</param>
        /// <param name="strDevIP">设备的IP地址</param>
        /// <param name="uiDevPort">设备的通信端口；非特殊情况，填写0，表示使用默认端口</param>
        /// <returns></returns>
        [DllImport(JcwDefine.JcwDllName, EntryPoint = "Jcw_SetDevAddress", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern JcwReturn Jcw_SetDevAddress(IntPtr hjcw, JMID id, string strDevIP, uint uiDevPort);



        /// <summary>
        /// 功能：获取已经设置的设备地址列表
        /// JCW_RET Jcw_GetDevIDList(JCWHANDLE h, JMDEVID* idArray, IN UINT uiBuffNum, OUT UINT& uiDevNumber);
        /// </summary>
        /// <param name="hjcw"></param>
        /// <param name="idArray">设备ID的缓冲区</param>
        /// <param name="uiBuffNum">缓冲区的数量，数组大小；可理解为 uiBuffNum = sizeof(idArray) / sizeof(JMDEVID)</param>
        /// <param name="uiDevNumber">已设置的设备数量</param>
        /// <returns></returns>
        [DllImport(JcwDefine.JcwDllName, EntryPoint = "Jcw_GetDevIDList", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern JcwReturn Jcw_GetDevIDList(IntPtr hjcw, JMID[] idArray, uint uiBuffNum, ref uint uiDevNumber);


        /// <summary>
        /// 功能：获取设备连接地址信息
        /// JCW_RET Jcw_GetDevAddress(JCWHANDLE h, JMDEVID id, OUT char* strDevIPBuff, OUT UINT& uiDevPort);
        /// </summary>
        /// <param name="hjcw"></param>
        /// <param name="id">设备ID</param>
        /// <param name="strDevIPBuff">设备的IP地址</param>
        /// <param name="uiDevPort">设备的通信端口；非特殊情况，填写0，表示使用默认端口</param>
        /// <returns></returns>
        [DllImport(JcwDefine.JcwDllName, EntryPoint = "Jcw_GetDevAddress", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern JcwReturn Jcw_GetDevAddress(IntPtr hjcw, JMID id, ref string strDevIPBuff, ref uint uiDevPort);
        

        /// <summary>
        /// 回调函数的托管，用于回调获取数据
        /// </summary>
        /// <param name="iTag"></param>
        /// <param name="jh"></param>
        public delegate void Jcw_fnJCWResultCallBack(IntPtr iTag, ref JCWJH jh);


        /// <summary>
        /// 功能：设置检测结果数据回调的接口函数指针
        /// JCW_RET Jcw_SetResultCallBack(JCWHANDLE h, const void* pTag, Jcw_fnJCWResultCallBack fnCB);
        /// 回调函数的定义
        /// typedef void(*Jcw_fnJCWResultCallBack)(const void*, const JCWJH&);
        /// </summary>
        /// <param name="hjcw"></param>
        /// <param name="id"></param>
        /// <param name="pTag"></param>
        /// <returns></returns>
        [DllImport(JcwDefine.JcwDllName, EntryPoint = "Jcw_SetResultCallBack", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern JcwReturn Jcw_SetResultCallBack(IntPtr hjcw, IntPtr pTag, Jcw_fnJCWResultCallBack fnptr);


        /// <summary>
        /// 查询是否有检测数据并且获取队列中的第一个。
        /// </summary>
        /// <param name="hjcw"></param>
        /// <param name="jh"></param>
        /// <returns>如果队列中有数据，则返回JcwReturn.JCW_OK</returns>
        [DllImport(JcwDefine.JcwDllName, EntryPoint = "Jcw_PopResult", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern JcwReturn Jcw_PopResult(IntPtr hjcw, ref JCWJH jh);



        /// <summary>
        /// 转换一份调试数据到jcwd
        /// </summary>
        /// <param name="strJdbg"></param>
        /// <param name="strJcwd"></param>
        /// <returns></returns>
        [DllImport(JcwDefine.JcwDllName, EntryPoint = "Jcw_JdbgToJCWD", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern JcwReturn Jcw_JdbgToJCWD(string strJdbg, string strJcwd);

        /// <summary>
        /// 转换一份调试数据到csv格式
        /// </summary>
        /// <param name="strJdbg"></param>
        /// <param name="strCsv"></param>
        /// <returns></returns>
        [DllImport(JcwDefine.JcwDllName, EntryPoint = "Jcw_JdbgToCsv", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern JcwReturn Jcw_JdbgToCsv(string strJdbg, string strCsv);



        //功能：创建一个保存调试包的文件，并且开始保存
        //strFilePath 保存的文件名
        [DllImport(JcwDefine.JcwDllName, EntryPoint = "Jcw_CreateDebugDataFile", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern JcwReturn Jcw_CreateDebugDataFile(IntPtr hjcw, string strFilePath);

        //功能：停止保存调试数据，并且关闭结调试包的文件
        [DllImport(JcwDefine.JcwDllName, EntryPoint = "Jcw_CloseDebugDataFile", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern JcwReturn Jcw_CloseDebugDataFile(IntPtr hjcw);


        /// <summary>
        /// 创建任务，在指定的路径保存数据
        /// </summary>
        /// <param name="hjcw"></param>
        /// <param name="strfile"></param>
        /// <returns></returns>
        public static JcwReturn Jcw_CreateTask(IntPtr hjcw, string strfile)
        {
            return Jcw_CreateDebugDataFile(hjcw, strfile);
        }


        /// <summary>
        /// 停止任务
        /// </summary>
        /// <param name="hjcw"></param>
        /// <returns></returns>
        public static JcwReturn Jcw_StopTask(IntPtr hjcw)
        {
            return Jcw_CloseDebugDataFile(hjcw);
        }
    }
}
