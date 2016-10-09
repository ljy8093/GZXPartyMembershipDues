using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Excel2Word.Reference;
using GZXPartyMembershipDues.Reference;
using GZXPartyMembershipDues.Reference.Base;

namespace GZXPartyMembershipDues
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
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
                FileInfo[] files = folder.GetFiles("*.*", SearchOption.AllDirectories);

                foreach (FileInfo file in files)
                {
                    if (file.Extension.ToUpper() == ".XLS" || file.Extension.ToUpper() == ".XLSX")
                    {
                        DataSet ds = ExcelHandle.ReadExcel(file.FullName);
                        if (ds != null)
                            Save2DBYINGJDF(ds);
                    }
                }
            }
            MessageBox.Show("入库完成！");
        }

        

        private void Save2DBYINGJDF(DataSet dataSet)
        {
            SqlLiteCommon sqlLite = new SqlLiteCommon();
            foreach (DataTable dt in dataSet.Tables)
            {
                ArrayList objArr = new ArrayList(); 
                foreach (DataRow dr in dt.Rows)
                {
                    Obj_YINGJDF objYingjdf = new Obj_YINGJDF();
                    
                    if (dt.Columns.Contains("姓名") && dr["姓名"].ToString().Trim() != string.Empty && dr["日期"].ToString() != string.Empty)
                    {
                        try
                        {
                            objYingjdf.Name = dr["姓名"].ToString().Trim();
                            objYingjdf.Date =
                                Convert.ToDateTime(dr["日期"].ToString());
                            objYingjdf.DFJS =
                                Convert.ToDouble(dr["党费基数"].ToString() == string.Empty ? "0" : dr["党费基数"].ToString());
                            objYingjdf.DFJSQZ =
                                Convert.ToDouble(dr["党费基数（取整）"].ToString() == string.Empty ? "0" : dr["党费基数（取整）"].ToString());
                            objYingjdf.YINGJDF =
                                Convert.ToDouble(dr["应缴党费"].ToString() == string.Empty ? "0" : dr["应缴党费"].ToString());
                            objYingjdf.YINGJDFQZ =
                                Convert.ToDouble(dr["应交党费（取整）"].ToString() == string.Empty ? "0" : dr["应交党费（取整）"].ToString());
                            objArr.Add(objYingjdf);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("文件 " + dataSet.DataSetName + " 的表 " + dt.TableName + "中的记录 '" +
                                                        objYingjdf.Name + "' 存在问题！\n" + ex.Message);
                        }
                    }
                }
                sqlLite.Add(objArr);
            }  
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                textBox2.Text = folderBrowserDialog.SelectedPath;
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                textBox3.Text = folderBrowserDialog.SelectedPath;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox2.Text.Trim() == "")
            {
                MessageBox.Show("请选择已缴Excel存储路径！");
                return;
            }
            else
            {
                DirectoryInfo folder = new DirectoryInfo(textBox2.Text);
                FileInfo[] files = folder.GetFiles("*.*", SearchOption.AllDirectories);
                
                foreach (FileInfo file in files)
                {
                    if (file.Extension.ToUpper() == ".XLS" || file.Extension.ToUpper() == ".XLSX")
                    {
                        DataSet ds = ExcelHandle.ReadExcel(file.FullName);
                        if (ds != null)
                        {
                            ds.DataSetName = file.FullName;
                            //Save2DBYIJDF_ZZ(ds);
                            Save2DBYIJDF_ZZ_2(ds);
                        }
                        
                    }
                }
            }
            MessageBox.Show("入库完成！");
        }

        
        private void Save2DBYIJDF_ZZ(DataSet dataSet)
        {
            SqlLiteCommon sqlLite = new SqlLiteCommon();
            foreach (DataTable dt in dataSet.Tables)
            {
                #region 注释代码——修改表头为英文
                //foreach (DataRow dr in dt.Rows)
                //{
                //    if (!dt.Columns.Contains("姓名"))//当表头中不包含姓名时，重新绑定表头并删除第一行数据
                //    {
                //        for (int i = 0; i < dt.Columns.Count; i++)
                //        {
                //            dt.Columns[i].ColumnName = dr[i].ToString().Replace(" ", "").Replace(Convert.ToChar(10).ToString(), "");
                //        }
                //        dr.Delete();
                //    }
                //    else
                //    {
                //        //把对应的中文表头改为英文
                //        for (int i=0;i< dt.Columns.Count;i++)
                //        {
                //            DataColumn col = dt.Columns[i];
                //            string colName_CN = col.Caption;
                //            Columns_YIJDF_ZZ_Excel colExcel = new Columns_YIJDF_ZZ_Excel();
                //            Dictionary<string, string> dict = colExcel.dir;
                //            if(dict.ContainsKey(colName_CN))
                //            {
                //                string colName_EN = colExcel.dir[colName_CN];
                //                col.ColumnName = colName_EN;
                //            }
                //            else
                //            {
                //                dt.Columns.Remove(col);
                //                i--;
                //            }
                //        }
                        
                //        break;
                //    }
                //}
                #endregion
            }
        }

        private void Save2DBYIJDF_ZZ_2(DataSet dataSet)
        {
            SqlLiteCommon sqlLite = new SqlLiteCommon();
            foreach (DataTable dt in dataSet.Tables)
            {
                if (!dt.TableName.Contains("退休") && !dt.TableName.Contains("补缴党费"))
                {
                    ArrayList objArr = new ArrayList();
                    foreach (DataRow dr in dt.Rows)
                    {
                        Obj_YIJDF_ZZ_2 obj = new Obj_YIJDF_ZZ_2();

                        if (!dt.Columns.Contains("姓名"))//当表头中不包含姓名时，重新绑定表头并删除第一行数据
                        {
                            for (int i = 0; i < dt.Columns.Count; i++)
                            {
                                if (dr[i].ToString() != null && dr[i].ToString() != string.Empty)
                                    dt.Columns[i].ColumnName = dr[i].ToString().Replace(" ", "").Replace(Convert.ToChar(10).ToString(), "");
                            }
                            dr.Delete();
                        }
                        else
                        {
                            if (dr["姓名"].ToString().Trim() != string.Empty)
                            {
                                try
                                {
                                    string dateSpan = dr["缴费起止月份"].ToString();
                                    string[] dateSpanArr = DateTrans(dateSpan);
                                    if (dateSpanArr != null)
                                    {
                                        foreach (string date in dateSpanArr)
                                        {
                                            obj = new Obj_YIJDF_ZZ_2();
                                            obj.JFQZYF = dateSpan;
                                            obj.Name = dr["姓名"].ToString().Trim();
                                            obj.GWGZ =
                                                Convert.ToDouble(dr["岗位工资"].ToString() == string.Empty ? "0" : dr["岗位工资"].ToString());
                                            obj.XJGZ = Convert.ToDouble(dr["薪级"].ToString() == string.Empty ? "0" : dr["薪级"].ToString());
                                            obj.ZWBT =
                                                Convert.ToDouble(dr["职务补贴"].ToString() == string.Empty ? "0" : dr["职务补贴"].ToString());
                                            obj.JXGZ =
                                                Convert.ToDouble(dr["绩效工资"].ToString() == string.Empty ? "0" : dr["绩效工资"].ToString());
                                            obj.TENPERCENT =
                                                Convert.ToDouble(dr["0.1"].ToString() == string.Empty ? "0" : dr["0.1"].ToString());
                                            obj.XJ = Convert.ToDouble(dr["小计"].ToString() == string.Empty ? "0" : dr["小计"].ToString());
                                            obj.YKSJ =
                                                Convert.ToDouble(dr["应扣税金"].ToString() == string.Empty ? "0" : dr["应扣税金"].ToString());
                                            obj.DFJS =
                                                Convert.ToDouble(dr["党费基数"].ToString() == string.Empty ? "0" : dr["党费基数"].ToString());
                                            obj.JSJE =
                                                Convert.ToDouble(dr["计税金额"].ToString() == string.Empty ? "0" : dr["计税金额"].ToString());
                                            obj.YJDF =
                                                Convert.ToDouble(dr["月缴党费"].ToString() == string.Empty ? "0" : dr["月缴党费"].ToString());
                                            obj.YJDFQZ =
                                                Convert.ToDouble(dr["保留整数"].ToString() == string.Empty ? "0" : dr["保留整数"].ToString());
                                            obj.DATE = Convert.ToDateTime(date);
                                            objArr.Add(obj);
                                        }
                                    }
                                    else
                                    {
                                        MessageBox.Show("文件 " + dataSet.DataSetName + " 的表 " + dt.TableName + "中的记录 '" +
                                                        obj.Name + "' '缴费起止月份' 有误! 未成功录入");
                                    }
                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show("文件 " + dataSet.DataSetName + " 的表 " + dt.TableName + "中的记录 '" +
                                                    obj.Name + "' 存在问题！\n" + ex.Message);
                                }
                                
                            }
                        }
                    }
                    sqlLite.Add(objArr);
                }   
            }
        }

        /// <summary>
        /// 转换日期区间字符串为日期数组
        /// </summary>
        /// <param name="str">日期区间字符串</param>
        /// <returns>日期区间数组</returns>
        private string[] DateTrans(string str)
        {
            string[] strArr = str.Split(new char[2] { '-', '.' });
            if (strArr.Length == 4 && strArr[0].Length == 4 && strArr[2].Length == 4 && strArr[1].Length <= 2 &&
                strArr[3].Length <= 2)
            {
                int startYear = Convert.ToInt32(strArr[0]);
                int endYear = Convert.ToInt32(strArr[2]);
                int startMon = Convert.ToInt32(strArr[1]);
                int endMon = Convert.ToInt32(strArr[3]);

                int n = endYear - startYear;
                if (n < 0)
                {
                    return null;
                }
                else if (n == 0) //同一年
                {
                    if (startMon > 0 && startMon <= 12 && endMon > 0 && endMon <= 12 && startMon < endMon)
                    {
                        string[] reSultArr = new string[endMon - startMon + 1];
                        for (int i = startMon; i <= endMon; i++)
                        {
                            reSultArr[i - startMon] = strArr[0] + "." + i.ToString("d2");
                        }
                        return reSultArr;
                    }
                    else
                    {
                        return null;
                    }
                }
                else
                {
                    string[] reSultArr = new string[endMon + n * 12 - startMon + 1];
                    for (int i = startMon; i <= endMon + n * 12; i++)
                    {
                        if (i <= 12)
                            reSultArr[i - startMon] = strArr[0] + "." + i.ToString("d2");
                        else
                        {
                            for (int j = 1; j <= n; j++)
                            {
                                reSultArr[i - startMon] = (startYear + j).ToString() + "." + (i - j * 12).ToString("d2");
                            }
                        }
                    }
                    return reSultArr;
                }

            #region old_上面代码确认没问题后此段可删除

                /*
                //同一年
                if (strArr[0] == strArr[2])
                {
                    int startMon = Convert.ToInt32(strArr[1]);
                    int endMon = Convert.ToInt32(strArr[3]);
                    string[] reSultArr = new string[endMon - startMon + 1];
                    for (int i = startMon; i <= endMon; i++)
                    {
                        reSultArr[i - startMon] = strArr[0] + "." + i.ToString("d2");
                    }
                    return reSultArr;
                }
                //跨年
                else
                {
                    int startYear = Convert.ToInt32(strArr[0]);
                    int endYear = Convert.ToInt32(strArr[2]);
                    int startMon = Convert.ToInt32(strArr[1]);
                    int endMon = Convert.ToInt32(strArr[3]);
                    int n = endYear - startYear;
                    if (n > 0)//跨一年以上
                    {
                        string[] reSultArr = new string[endMon + (endYear - startYear)*12 - startMon + 1];
                        for (int i = startMon; i <= endMon + n*12; i++)
                        {
                            if (i <= 12)
                                reSultArr[i - startMon] = strArr[0] + "." + i.ToString("d2");
                            else
                            {
                                for (int j = 1; j <= n; j++)
                                {
                                    reSultArr[i - startMon] = (startYear + j).ToString() + "." + (i - j*12).ToString("d2");
                                }
                            }
                        }
                        return reSultArr;
                    }
                    else
                        return null;
                }
                */

                #endregion

            }
            else
            {
                return null;
            }
        }
    }
}
