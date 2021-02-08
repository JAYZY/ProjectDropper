using ComClassLib;
using DevComponents.DotNetBar;
using System;
using System.Drawing;
using System.Globalization;

namespace ProjectDropper {
    public partial class FrmParent :OfficeForm {
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


        public FrmParent() {
            InitializeComponent();
            iCameraTotalNum = 20;
            LoadImgViewCtrl();
        }


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
        private void switchButtonItem1_ValueChanged(object sender, EventArgs e) {
           // ribbonControl1.Expanded = switchButtonItem1.Value;
        }

        #region 样式相关
        /// <summary>
        /// 样式改变命令
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AppCommandTheme_Executed(object sender, EventArgs e) {
            ICommandSource source = sender as ICommandSource;
            if (source.CommandParameter is string) {
                eStyle style = (eStyle)Enum.Parse(typeof(eStyle), source.CommandParameter.ToString());
                // Using StyleManager change the style and color tinting
                if (StyleManager.IsMetro(style)) {
                    // More customization is needed for Metro
                    // Capitalize App Button and tab
                    //buttonFile.Text = buttonFile.Text.ToUpper();
                   // foreach (BaseItem item in RibbonControl.Items) {
                        // Ribbon Control may contain items other than tabs so that needs to be taken in account
                   //     RibbonTabItem tab = item as RibbonTabItem;
                    //    if (tab != null) {
                   //         tab.Text = tab.Text.ToUpper();
                    //   }
                  //  }

                    // buttonFile.BackstageTabEnabled = true; // Use Backstage for Metro

                    //ribbonControl1.RibbonStripFont = new System.Drawing.Font("Segoe UI", 9.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
                    if (style == eStyle.Metro) {
                        StyleManager.MetroColorGeneratorParameters = DevComponents.DotNetBar.Metro.ColorTables.MetroColorGeneratorParameters.DarkBlue;
                    }

                    // Adjust size of switch button to match Metro styling
                   // switchButtonItem1.SwitchWidth = 16;
                   // switchButtonItem1.ButtonWidth = 48;
                   // switchButtonItem1.ButtonHeight = 19;

                    // Adjust tab strip style
                    //tabStrip1.Style = eTabStripStyle.Metro;

                    StyleManager.Style = style; // BOOM
                } else {
                    // If previous style was Metro we need to update other properties as well
                    if (StyleManager.IsMetro(StyleManager.Style)) {
                       // ribbonControl1.RibbonStripFont = null;
                        // Fix capitalization App Button and tab
                        //buttonFile.Text = ToTitleCase(buttonFile.Text);
                      //  foreach (BaseItem item in RibbonControl.Items) {
                            // Ribbon Control may contain items other than tabs so that needs to be taken in account
                         //   RibbonTabItem tab = item as RibbonTabItem;
                       //     if (tab != null) {
                         //       tab.Text = ToTitleCase(tab.Text);
                         //   }
                       // }
                        // Adjust size of switch button to match Office styling
                      //  switchButtonItem1.SwitchWidth = 28;
                      //  switchButtonItem1.ButtonWidth = 62;
                      //  switchButtonItem1.ButtonHeight = 20;
                    }
                    // Adjust tab strip style
                    //tabStrip1.Style = eTabStripStyle.Office2007Document;
                    StyleManager.ChangeStyle(style, Color.Empty);
                    //if (style == eStyle.Office2007Black || style == eStyle.Office2007Blue || style == eStyle.Office2007Silver || style == eStyle.Office2007VistaGlass)
                    //   buttonFile.BackstageTabEnabled = false;
                    // else
                    //    buttonFile.BackstageTabEnabled = true;
                }
            } else if (source.CommandParameter is Color) {
                if (StyleManager.IsMetro(StyleManager.Style)) {
                    StyleManager.MetroColorGeneratorParameters = new DevComponents.DotNetBar.Metro.ColorTables.MetroColorGeneratorParameters(Color.White, (Color)source.CommandParameter);
                } else {
                    StyleManager.ColorTint = (Color)source.CommandParameter;
                }
            }
        }
        //标题大小写转换
        private string ToTitleCase(string text) {
            if (text.Contains("&")) {
                int ampPosition = text.IndexOf('&');
                text = text.Replace("&", "");
                text = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(text.ToLower());
                if (ampPosition > 0) {
                    text = text.Substring(0, ampPosition) + "&" + text.Substring(ampPosition);
                } else {
                    text = "&" + text;
                }

                return text;
            } else {
                return CultureInfo.CurrentCulture.TextInfo.ToTitleCase(text.ToLower());
            }
        }


        /// <summary>
        /// 工具区域 折叠控制
        /// </summary>
        private void RibbonStateCommand_Executed(object sender, EventArgs e) {
           // ribbonControl1.Expanded = RibbonStateCommand.Checked;
            //RibbonStateCommand.Checked = !RibbonStateCommand.Checked;
        }
        #endregion
    }
}
