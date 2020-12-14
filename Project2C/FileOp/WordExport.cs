using System;
using System.Linq;
using Microsoft.Office.Core;
using Word = Microsoft.Office.Interop.Word;
using Excel = Microsoft.Office.Interop.Excel;
using Graph = Microsoft.Office.Interop.Graph;

namespace Project2C.FileOp {
    /// <summary>
    /// word 导出类
    /// </summary>
    class WordExport {

        private Word._Application _wordApp = null;
        private Word._Document _wordDoc = null;
        private object miss = System.Reflection.Missing.Value;
        //属性 - _wordApp
        public Word._Application WordApp {
            get { return _wordApp; }
            set { _wordApp = value; }
        }

        //属性 - _wordDoc
        public Word._Document WordDoc {
            get { return _wordDoc; }
            set { _wordDoc = value; }
        }

        //通过模板创建新文档
        public void CreateNewDocument(string filePath) {
            KillWinWordProcess();
            _wordApp = new Word.Application();

            _wordApp.DisplayAlerts = Word.WdAlertLevel.wdAlertsNone;

            _wordApp.Visible = false;

            object templateName = filePath;
            _wordDoc = _wordApp.Documents.Open(ref templateName, ref miss,
                ref miss, ref miss, ref miss, ref miss, ref miss,
                ref miss, ref miss, ref miss, ref miss, ref miss,
                ref miss, ref miss, ref miss, ref miss);
        }

        //保存新文件  
        public void SaveDocument(string filePath) {
            object fileName = filePath;
            object format = Word.WdSaveFormat.wdFormatDocument; //保存格式  

            _wordDoc.SaveAs(ref fileName, ref format, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss,
                ref miss,
                ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss);
            //关闭__wordDoc,_wordApp对象  
            object SaveChanges = Word.WdSaveOptions.wdSaveChanges;
            object OriginalFormat = Word.WdOriginalFormat.wdOriginalDocumentFormat;
            object RouteDocument = false;
            _wordDoc.Close(ref SaveChanges, ref OriginalFormat, ref RouteDocument);
            _wordApp.Quit(ref SaveChanges, ref OriginalFormat, ref RouteDocument);
        }

        //写入页眉  
        public void InsertHeader(string docHeader) {
            //添加页眉  
            _wordApp.ActiveWindow.View.Type = Word.WdViewType.wdOutlineView;
            _wordApp.ActiveWindow.View.SeekView = Word.WdSeekView.wdSeekPrimaryHeader;
            _wordApp.ActiveWindow.ActivePane.Selection.InsertAfter(docHeader); //页眉内容  

            //设置中间对齐   
            _wordApp.Selection.ParagraphFormat.Alignment =
                Word.WdParagraphAlignment.wdAlignParagraphCenter;

            //跳出页眉设置   
            _wordApp.ActiveWindow.View.SeekView = Word.WdSeekView.wdSeekMainDocument;

        }


        //在书签处插入值  
        public bool InsertValue(string bookmark, string value) {
            object bkObj = bookmark;
            if (_wordApp.ActiveDocument.Bookmarks.Exists(bookmark)) {
                //该方法会截取value，输入文本内容显示不全  
                //_wordApp.ActiveDocument.Bookmarks.get_Item(ref bkObj).Select();  
                //_wordApp.Selection.TypeText(value);  

                Word.Range range = _wordApp.ActiveDocument.Bookmarks.get_Item(ref bkObj).Range; //表格插入位置   
                range.Text = value; //在书签处插入文字内容    
                return true;
            }
            return false;
        }

        /// <summary>
        /// 在书签处插入表格  
        /// </summary>
        /// <param name="bookmark">书签-表格插入位置</param>
        /// <param name="rows">插入的表格rows</param>
        /// <param name="cols">插入的表格cols</param>
        /// <returns></returns>
        public Word.Table InsertTable(string bookmark, int rows, int cols) {
            object oStart = bookmark;
            Word.Range range = _wordDoc.Bookmarks.get_Item(ref oStart).Range; //表格插入位置  
            Word.Table newTable = _wordDoc.Tables.Add(range, rows, cols, ref miss, ref miss);
            //设置表的样式  
            newTable.Borders.Enable = 1; //允许有实线边框  
            newTable.Borders.OutsideLineWidth = Word.WdLineWidth.wdLineWidth050pt; //边框宽度  
                                                                                   //newTable.PreferredWidth = 17;  
            newTable.AllowAutoFit = true;
            return newTable;
        }

        //给表格中单元格插入元素，table所在表格，row行号，column列号,value插入的元素  
        public void InsertCell(Word.Table table, int row, int column, string value) {
            table.Cell(row, column).Range.Text = value;
        }

        //给表格插入一行数据，n为表格的序号，row行号，column列数，values插入的值  
        public void InsertCell(Word.Table table, int row, int colNums, string[] values) {
            for (int i = 0; i < colNums; i++) {
                table.Cell(row, i + 1).Range.Text = values[i];
            }
        }

        // 杀掉winword.exe进程  
        public void KillWinWordProcess() {
            System.Diagnostics.Process[] processes = System.Diagnostics.Process.GetProcessesByName("WINWORD");
            foreach (System.Diagnostics.Process process in processes) {
                if (process.MainWindowTitle == "") {
                    process.Kill();
                }
            }
        }

        /// <summary>
        /// 创建chart -- 注：适用于office2010以上的版本
        /// </summary>
        public void CreateChart(string bookmark, string title, string[] names, double[] values) {
            if (string.IsNullOrEmpty(title))
                title = "测试-动态生成Chart";
            //string[] names = { "松", "断", "脱", "其他" };
            // double[] values = { 50, 10, 20, 20 };
            // var inlineShape = _wordDoc.Bookmarks.Cast<Word.Bookmark>().FirstOrDefault(o => o.Name == bookmark).Range;  
            object oStart = string.IsNullOrEmpty(bookmark) ? Type.Missing : bookmark;
            Word.Range pos = _wordDoc.Bookmarks.get_Item(ref oStart).Range; //Chart插入位置    
                                                                            //  Word.Chart chartC = inlineShape.InlineShapes[0].Chart;
                                                                            //   Word.Chart chartB = pos.InlineShapes[0].Chart;

            // MsgBox.Show(chartB);
            // _wordDoc = _wordApp.Documents.Add();


            Word.Chart chartA = _wordDoc.InlineShapes.AddChart(XlChartType.xl3DPie, pos).Chart;
            //MsgBox.Show(_wordDoc.InlineShapes.Count.ToString());
            object lineshap = _wordDoc.InlineShapes[1];
            Word.Shape shap = ((Word.InlineShape)lineshap).ConvertToShape();
            shap.WrapFormat.Type = Word.WdWrapType.wdWrapTopBottom; //设置上下型环绕

            Excel.Worksheet book = chartA.ChartData.Workbook.Worksheets["sheet1"];
            book.Cells.Clear(); //清除原有数据
            book.Application.Visible = false;
            int count = names.Length;
            var data = new object[count, 2];
            Enumerable.Range(0, count).ToList().ForEach(i => {
                data[i, 0] = names[i];
                data[i, 1] = values[i];
            });
            book.Range["A2", "B" + (count + 1)].Value = data;
            book.Range["B1"].Value = title;

            //_wordDoc.SaveAs2(@"d:\test.doc");
            book.Application.Quit();
            //_wordApp.Quit(true);

        }


        public void CreateChart2(string bookmark, string title, string[] names, double[] values) {
            Excel.Application eApp = new Excel.Application();
            eApp.Visible = true;
            Excel.Workbook book = eApp.Workbooks.Add();//增加一个workboo
            Excel.Worksheet sheet = eApp.Worksheets[1];//获取第一个Worksheet
            Excel.Range range = sheet.get_Range("A1", "D2");//获取A1到D2范围内的Range
                                                            //向表格中插入数据
            range.Cells[1][1] = "姓名";
            range.Cells[1][2] = "成绩";
            range.Cells[2][1] = "张三";
            range.Cells[2][2] = "89";
            range.Cells[3][1] = "李四";
            range.Cells[3][2] = "100";
            range.Cells[4][1] = "王五";
            range.Cells[4][2] = "95";
            //插入图表À
            Excel.Chart xlChart = book.Charts.Add();
            //设置图表源
            xlChart.SetSourceData(range);
            xlChart.ApplyLayout(10);
            //最后，拷贝表格和图表到word中。
            //拷贝表格

            object oStart = string.IsNullOrEmpty(bookmark) ? Type.Missing : bookmark;
            Word.Range wdRange = _wordDoc.Bookmarks.get_Item(ref oStart).Range; //Chart插入位置    

            range.Copy();
            wdRange.Paste();
            //拷贝图表数据到
            wdRange.SetRange(wdRange.End, wdRange.End + 1);
            xlChart.ChartArea.Copy();
            wdRange.Paste();
        }

    }
}
