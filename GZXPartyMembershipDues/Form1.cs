using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using Excel2Word.Reference;
using Microsoft.Office.Interop.Excel;
using Application = Microsoft.Office.Interop.Excel.Application;

namespace GZXPartyMembershipDues
{
    public partial class Form1 : Form
    {
        /// <summary>
        /// 后台线程
        /// </summary>
        private BackgroundWorker bkWorker = new BackgroundWorker();

        /// <summary>  
        /// 步进值  
        /// </summary>  
        private int percentValue = 0;

        private string xltPath = "";
        private string xlsPath = "";
        private object missing = Missing.Value;
        private bool findAllName = false;
        private string[] namesArr;

        private ArrayList folder1 = new ArrayList();
        private ArrayList folder2 = new ArrayList();


        public Form1()
        {
            InitializeComponent();
            xltPath = System.Windows.Forms.Application.StartupPath + "\\需补缴党费统计表.xlt";
            bkWorker.WorkerReportsProgress = true;
            bkWorker.WorkerSupportsCancellation = true;
            bkWorker.DoWork += new DoWorkEventHandler(DoWork);
            bkWorker.ProgressChanged += new ProgressChangedEventHandler(ProgessChanged);
            bkWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(CompleteWork);
        }

        private void btnSel_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                textBox1.Text = folderBrowserDialog.SelectedPath;
            }
            //OpenFileDialog openFileDialog = new OpenFileDialog();
            //DialogResult result = openFileDialog.ShowDialog();
            //if (result == DialogResult.OK)
            //{
            //    textBox1.Text = openFileDialog.FileName;
            //}
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Trim() == "")
            {
                MessageBox.Show("请选择应缴Excel存储路径！");
                return;
            }
            else
            {
                DirectoryInfo folder = new DirectoryInfo(textBox1.Text);
                foreach (FileInfo file in folder.GetFiles("*.xls"))
                {
                    folder1.Add(file.FullName);
                }
            }
            if (textBox4.Text.Trim() == "")
            {
                MessageBox.Show("请选择已缴Excel存储路径！");
                return;
            }
            else
            {
                DirectoryInfo folder = new DirectoryInfo(textBox4.Text);
                foreach (FileInfo file in folder.GetFiles("*.xls"))
                {
                    folder2.Add(file.FullName);
                }
            }

            xlsPath = @"D:\333333\"+DateTime.Now.ToString("yyyyMMddHHmmss") + ".xls";
            
            percentValue = 10;
            this.progressBar1.Maximum = 1000;
            // 执行后台操作  
            bkWorker.RunWorkerAsync();
        }

        public void DoWork(object sender, DoWorkEventArgs e)
        {
            // 事件处理，指定处理函数  
            e.Result = ProcessProgress(bkWorker, e);

        }

        public void ProgessChanged(object sender, ProgressChangedEventArgs e)
        {
            // bkWorker.ReportProgress 会调用到这里，此处可以进行自定义报告方式  
            this.progressBar1.Value = e.ProgressPercentage;
            int percent = (int)(e.ProgressPercentage / percentValue);
            this.label3.Text = "处理进度:" + Convert.ToString(percent) + "%";
        }

        private int ProcessProgress(object sender, DoWorkEventArgs e)
        {
            CalculateExcel();
            return -1;
        }

        public void CompleteWork(object sender, RunWorkerCompletedEventArgs e)
        {
            this.label3.Text = "计算完成!";
            MessageBox.Show("计算完成!");
        }

        private void CalculateExcel()
        {
            string selFields = textBox2.Text;
            string selFields2 = textBox5.Text;
            string[] fieldsArr = selFields.Split(new char[2] { ',', '，' });
            string[] fieldsArr2 = selFields2.Split(new char[2] { ',', '，' });

            if (textBox3.Text.Trim() == string.Empty)
                findAllName = true;
            else
            {
                namesArr = ReadTxtName(textBox3.Text);
                if (namesArr.Length == 0)
                    findAllName = true;
            }
            

            Application app = new ApplicationClass();

            try
            {
                //让后台执行设置为不可见
                app.Visible = false;
                app.AlertBeforeOverwriting = false;

                //新建一个工作簿
                Workbook wBooknew = app.Application.Workbooks.Add(missing);
                ////通过模板新建一个结果工作簿
                //Workbook wBooknew = app.Workbooks.Open(xltPath,
                //    missing, missing, missing, missing, missing, missing, missing,
                //    missing, missing, missing, missing, missing, missing, missing);
                Worksheet wSheetnew = (Worksheet)wBooknew.ActiveSheet;
                wBooknew.SaveAs(xlsPath, missing, missing, missing, missing, missing,
                        XlSaveAsAccessMode.xlExclusive, XlSaveConflictResolution.xlOtherSessionChanges, missing, missing, missing, missing);

                int curNum = 0;
                # region 应缴
                //打开应缴工作簿
                foreach (string filePath in folder1)
                {
                    Workbook wBook = app.Workbooks.Open(filePath,
                    missing, missing, missing, missing, missing, missing, missing,
                    missing, missing, missing, missing, missing, missing, missing);
                    int iEWSCnt = wBook.Worksheets.Count;
                    for (int i = 1; i <= iEWSCnt; i++)
                    {
                        //取得一个工作表
                        //如果打开了已有的工作簿,也可以这样获取工作表
                        Worksheet wSheet = wBook.Worksheets[i] as Worksheet;
                        int rowNum = wSheet.UsedRange.Rows.Count;
                        int columnNum = wSheet.UsedRange.Columns.Count;
                        string columnMax = ExcelRowIndex.IndexToColumn(columnNum);
                        Range titleRange = wSheet.get_Range("A1", columnMax + "1");

                        int[] selFieldColIdxs = getSelFieldColNum(titleRange, fieldsArr);
                        //if(wSheetnew.UsedRange.Rows.Count ==0)//第一个表时添加表头，后面不需要重复添加
                        //{
                        for (int j = 1; j <= selFieldColIdxs.Length; j++)
                        {
                            wSheetnew.Cells[1, j] = fieldsArr[j - 1];
                        }
                        //}
                        for (int k = 2; k <= rowNum; k++)
                        {
                            int rowNumtmp = wSheetnew.UsedRange.Rows.Count;
                            if (findAllName)
                            {
                                for (int m = 1; m <= selFieldColIdxs.Length; m++)
                                {
                                    wSheetnew.Cells[rowNumtmp + 1, m] = wSheet.Cells[k, selFieldColIdxs[m - 1]];
                                }
                            }
                            else if (namesArr.Contains(((Range)wSheet.Cells[k, selFieldColIdxs[0]]).Text.ToString().Trim()))
                            {
                                for (int m = 1; m <= selFieldColIdxs.Length; m++)
                                {
                                    wSheetnew.Cells[rowNumtmp + 1, m] = wSheet.Cells[k, selFieldColIdxs[m - 1]];
                                }
                            }
                            curNum++;
                            // 状态报告  
                            bkWorker.ReportProgress(1000 * curNum / (rowNum * iEWSCnt * (folder1.Count)));
                            // 等待，用于UI刷新界面，很重要  
                            System.Threading.Thread.Sleep(1);
                        }
                    }
                    wBook.Close(SaveChanges:false);
                    wBooknew.Save();
                }

                #endregion

                #region 已缴
                curNum = 0;
                foreach (string filePath in folder2)
                {
                    
                    //打开已缴工作簿
                    Workbook wBook2 = app.Workbooks.Open(filePath,
                        missing, missing, missing, missing, missing, missing, missing,
                        missing, missing, missing, missing, missing, missing, missing);
                    int iEWSCnt2 = wBook2.Worksheets.Count;
                    for (int ii = 1; ii <= iEWSCnt2; ii++)
                    {
                        Worksheet wSheet2 = wBook2.Worksheets[ii] as Worksheet;
                        int rowNum2 = wSheet2.UsedRange.Rows.Count;
                        int columnNum2 = wSheet2.UsedRange.Columns.Count;
                        string columnMax2 = ExcelRowIndex.IndexToColumn(columnNum2);
                        Range titleRange2 = wSheet2.get_Range("A2", columnMax2 + "2");//第二行
                        int[] selFieldColIdxs2 = getSelFieldColNum(titleRange2, fieldsArr2);
                        string[] dateStrArr = null;
                        for (int k = 3; k <= rowNum2; k++)
                        {
                            string dateStr = ((Range)wSheet2.Cells[k, selFieldColIdxs2[1]]).Text.ToString();
                            if (dateStrArr == null)
                                dateStrArr = DateTrans(dateStr);


                            int rowNumtmp2 = wSheetnew.UsedRange.Rows.Count;
                            for (int n = 2; n <= rowNumtmp2; n++)
                            {

                                if (((Range)wSheetnew.Cells[n, 1]).Text.ToString() == ((Range)wSheet2.Cells[k, selFieldColIdxs2[0]]).Text.ToString()
                                    && dateStrArr.Contains(((Range)wSheetnew.Cells[n, 2]).Text.ToString()))
                                {
                                    wSheetnew.Cells[n, 4] = (Range)wSheet2.Cells[k, selFieldColIdxs2[2]];
                                    wSheetnew.Cells[n, 5] = (Range)wSheet2.Cells[k, selFieldColIdxs2[3]];
                                }
                            }
                            curNum++;
                            // 状态报告  
                            bkWorker.ReportProgress(1000 * curNum / (rowNum2 * iEWSCnt2 * (folder2.Count)));
                            // 等待，用于UI刷新界面，很重要  
                            System.Threading.Thread.Sleep(1);
                        }
                    }
                    wBook2.Close(SaveChanges: false);
                    wBooknew.Save();
                }
                #endregion
                wBooknew.Close();
                
                app.Quit();
                app = null;


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                app.Quit();
                app = null;
            }
            finally
            {
                //确保Excel进程关闭
                if (app != null)
                {
                    app.Quit();
                    app = null;
                }
                Process[] procs = Process.GetProcessesByName("Excel");
                foreach (Process pro in procs)
                {
                    pro.Kill();//没有更好的方法,只有杀掉进程
                }
                GC.Collect();
            }
        }

        private string[] DateTrans(string str)
        {
            string[] strArr = str.Split(new char[2] { '-', '.' });
            if((strArr[1] == "01"|| strArr[1] == "1" ) && (strArr[3]== "06" || strArr[3] == "6"))
                return new string[6] { strArr[0]+".01", strArr[0] + ".02", strArr[0] + ".03" , strArr[0] + ".04", strArr[0] + ".05", strArr[0] + ".06" };
            else if ((strArr[1] == "07"|| strArr[1] == "7") && strArr[3] == "12")
                return new string[6] { strArr[0] + ".07", strArr[0] + ".08", strArr[0] + ".09", strArr[0] + ".10", strArr[0] + ".11", strArr[0] + ".12" };
            else
                return null;
        }

        /// <summary>
        /// 根据列名获取列索引号
        /// </summary>
        /// <param name="titleRange">表头区域</param>
        /// <param name="fieldsArr">列名数组</param>
        /// <returns>索引数组</returns>
        private int[] getSelFieldColNum(Range range, string[] strs)
        {
            int[] columnsArr = new int[strs.Length];
            for (int j = 0; j < strs.Length; j++)
            {
                string oText = strs[j].Trim();
                Range oRange = range.Find(oText, missing, missing, XlLookAt.xlWhole, missing, XlSearchDirection.xlNext,
                missing, missing, missing);
                if (oRange != null)
                {
                    //Find结果有值的话总是只能查到第一个
                    int columnIdx = oRange.Column;
                    columnsArr[j] = columnIdx;
                }
            }
            return columnsArr;
        }

        private void btnSel2_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            DialogResult result = openFileDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                textBox3.Text = openFileDialog.FileName;
            }
        }

        private string[] ReadTxtName(string path)
        {
            string[] nameArr;
            StreamReader sr = new StreamReader(path, Encoding.Default);
            String namesStr = sr.ReadToEnd();
            nameArr = namesStr.Split(new char[2] { ',', '，' });
            return nameArr;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                textBox4.Text = folderBrowserDialog.SelectedPath;
            }
            //OpenFileDialog openFileDialog = new OpenFileDialog();
            //DialogResult result = openFileDialog.ShowDialog();
            //if (result == DialogResult.OK)
            //{
            //    textBox4.Text = openFileDialog.FileName;
            //}
        }
    }
}
