using ComClassLib;
using DevComponents.DotNetBar.Metro;
using ProjectDropper.core;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//1.115.199
//
namespace ProjectDropper.P4C {
    public partial class FrmP4 : MetroAppForm {
        public FrmP4() {
            InitializeComponent();
        }
        #region 属性

        private int _iImgNumWithRow;//每行显示的图像数
        private int _iCameraTotalNum; //总的相机数量
        private int iCameraTotalNum {
            get { return _iCameraTotalNum; }
            set {
                if (value > 0) {
                    _iCameraTotalNum = value;
                    //计算每行个数
                    _iImgNumWithRow = (int)Math.Sqrt(value);
                }
            }
        }


        #region 设备相关属性
        private CtrlView[] _imageViews;//图像控件
        #endregion
        #endregion


        #region 初始化图像显示
        private void LoadImgViewCtrl() {
            //根据总相机数初始化控件
            _imageViews = new CtrlView[_iCameraTotalNum];

            //初始化 表格控件
            tbLayoutPanelMiddle.RowCount = 1;
            float percent = 100.0f / _iImgNumWithRow;
            this.tbLayoutPanelMiddle.RowStyles.Clear();
            this.tbLayoutPanelMiddle.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, percent));

            this.tbLayoutPanelMiddle.ColumnStyles.Clear();
            this.tbLayoutPanelMiddle.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, percent));

            for (int i = 1; i < _iImgNumWithRow; ++i) {
                ++tbLayoutPanelMiddle.RowCount;
                this.tbLayoutPanelMiddle.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, percent));
                ++tbLayoutPanelMiddle.ColumnCount;
                this.tbLayoutPanelMiddle.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, percent));
            }                       
            for (int i = 0; i < iCameraTotalNum; i++) {
                _imageViews[i] = new CtrlView($"imgV{i}", $"192.168.100.{i}");
                int row = i / _iImgNumWithRow;
                int col = i % _iImgNumWithRow;
                _imageViews[i].Dock = System.Windows.Forms.DockStyle.Fill;
                this.tbLayoutPanelMiddle.Controls.Add(_imageViews[i], col, row);
            }
        }
        #endregion


        #region # 相机设备配置&管理
        private  List<Device>devs;//设备列表
        private void DevLoad() {

        }
        #endregion
    }
}
