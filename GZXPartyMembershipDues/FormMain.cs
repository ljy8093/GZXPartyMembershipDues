using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using Excel2Word.Reference;
using GZXPartyMembershipDues.Reference;
using Microsoft.Office.Interop.Excel;
using Application = Microsoft.Office.Interop.Excel.Application;
using DataTable = System.Data.DataTable;

namespace GZXPartyMembershipDues
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }

        private void 数据入库ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.Show();
        }

        private void 清理应缴数据表ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBoxButtons messButton = MessageBoxButtons.OKCancel;
            DialogResult dr = MessageBox.Show("确定要清除应缴数据表中的所有数据吗?", "确认提示", messButton);
            if (dr == DialogResult.OK)
            {
                SqlLiteCommon sqliteCommon = new SqlLiteCommon();
                bool result = sqliteCommon.Clear("YINGJDF");
                if (result)
                    MessageBox.Show("清理应缴数据表完成！");
            }
        }

        private void 在职ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBoxButtons messButton = MessageBoxButtons.OKCancel;
            DialogResult dr = MessageBox.Show("确定要清除已缴（在职）数据表中的所有数据吗?", "确认提示", messButton);
            if (dr == DialogResult.OK)
            {
                SqlLiteCommon sqliteCommon = new SqlLiteCommon();
                bool result = sqliteCommon.Clear("YIJDFZZ_2");
                if (result)
                    MessageBox.Show("清理已缴（在职）数据表完成！");
            }
        }

        private void 退休数据表ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBoxButtons messButton = MessageBoxButtons.OKCancel;
            DialogResult dr = MessageBox.Show("确定要清除已缴（退休）数据表中的所有数据吗?", "确认提示", messButton);
            if (dr == DialogResult.OK)
            {
                SqlLiteCommon sqliteCommon = new SqlLiteCommon();
                bool result = sqliteCommon.Clear("YIJDFTX_2");
                if (result)
                    MessageBox.Show("清理已缴（退休）数据表完成！");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "xlsx files(*.xlsx)|*.xlsx|xls files(*.xls)|*.xls|All files(*.*)|*.*";
            DialogResult result = saveFileDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                textBox1.Text = saveFileDialog.FileName;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.ToString() != string.Empty)
            {
                DataTable dtResult = new DataTable();
                dtResult.Columns.Add("姓名");
                dtResult.Columns.Add("日期");
                dtResult.Columns.Add("应缴党费");
                dtResult.Columns.Add("已缴党费");
                dtResult.Columns.Add("欠缴党费");
                SqlLiteCommon sqliteCommon = new SqlLiteCommon();
                dtResult = sqliteCommon.Select("ZZ");

                SaveDataTable2Excel(dtResult, textBox1.Text);
            }
        }

        private void SaveDataTable2Excel(DataTable dtable, string excelPath)
        {
            string xltPath = System.Windows.Forms.Application.StartupPath + "\\需补缴党费统计表.xlt";

            object missing = Missing.Value;
            if (!File.Exists(excelPath))
            {
                Application app = new ApplicationClass();
                try
                {
                    //让后台执行设置为不可见
                    app.Visible = false;
                    app.AlertBeforeOverwriting = false;

                    //新建一个工作簿
                    //Workbook wBooknew = app.Application.Workbooks.Add(missing);
                    ////通过模板新建一个结果工作簿
                    Workbook wBooknew = app.Workbooks.Open(xltPath,
                        missing, missing, missing, missing, missing, missing, missing,
                        missing, missing, missing, missing, missing, missing, missing);
                    Worksheet wSheetnew = (Worksheet) wBooknew.ActiveSheet;
                    wBooknew.SaveAs(excelPath, missing, missing, missing, missing, missing,
                        XlSaveAsAccessMode.xlExclusive, XlSaveConflictResolution.xlOtherSessionChanges, missing, missing,
                        missing, missing);
                    wBooknew.Close();
                }
                catch (Exception ex)
                {

                }
                finally
                {
                    app.Quit();
                    app = null;
                
                    Process[] procs = Process.GetProcessesByName("Excel");
                    foreach (Process pro in procs)
                    {
                        pro.Kill();//没有更好的方法,只有杀掉进程
                    }
                    GC.Collect();
            }
            }
            
            ExcelHandle.SaveDataTable2Excel(dtable, excelPath);
        }
    }
}
