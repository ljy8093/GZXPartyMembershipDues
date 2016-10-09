using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using Microsoft.Office.Interop.Excel;

namespace Excel2Word.Reference
{
    class ExcelHandle
    {
        /// <summary>
        /// 读取Excel数据
        /// </summary>
        /// <param name="filepath">文件路径</param>
        /// <returns>结果数据集</returns>
        public static DataSet ReadExcel(string filepath)
        {
            try
            {
                string strConn;
                string FileType = filepath.Substring(filepath.LastIndexOf("."));

                //注意：把一个excel文件看做一个数据库，一个sheet看做一张表。语法 "SELECT * FROM [sheet1$]"，表单要使用"[]"和"$"
                // 1、HDR表示要把第一行作为数据还是作为列名，作为数据用HDR=no，作为列名用HDR=yes；
                // 2、通过IMEX=1来把混合型作为文本型读取，避免null值。
                if (FileType == ".xls")
                    strConn = "Provider=Microsoft.Jet.OLEDB.4.0;" +
                                 "Data Source=" + filepath + ";Extended Properties='Excel 8.0;HDR=YES;IMEX=1';";
                else //.xlsx
                    strConn = "Provider=Microsoft.ACE.OLEDB.12.0;" + "Data Source=" + filepath + ";" +
                                 ";Extended Properties='Excel 12.0;HDR=YES;IMEX=0'";
                OleDbConnection oleConn = new OleDbConnection(strConn);
                oleConn.Open();
                //获取所有sheet表名
                System.Data.DataTable dt = oleConn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
                DataSet oleDsExcel = new DataSet();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    string vSheetsName = dt.Rows[i][2].ToString();
                    if (vSheetsName[0].ToString() == "'" && vSheetsName[vSheetsName.Length - 1].ToString() == "'")
                    {
                        vSheetsName = vSheetsName.Substring(1, vSheetsName.Length - 2); 
                    }
                    if (vSheetsName[vSheetsName.Length - 1].ToString() != "$")
                    {
                        continue;
                    }
                    vSheetsName = vSheetsName.Replace("$", "");
                    string sql = "select * from [" + vSheetsName + "$]";
                    
                    OleDbDataAdapter oleDaExcel = new OleDbDataAdapter(sql, oleConn);
                    oleDaExcel.Fill(oleDsExcel, vSheetsName);
                }
                oleConn.Close();
                return oleDsExcel;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
                return null;
            }
        }

        #region old 读取excel方法一——将所有sheets表统一读取到一个table中 测试可用
        public static DataSet ReadExcel1(string filepath)
        {
            try
            {
                string strConn;
                string FileType = filepath.Substring(filepath.LastIndexOf("."));

                //注意：把一个excel文件看做一个数据库，一个sheet看做一张表。语法 "SELECT * FROM [sheet1$]"，表单要使用"[]"和"$"
                // 1、HDR表示要把第一行作为数据还是作为列名，作为数据用HDR=no，作为列名用HDR=yes；
                // 2、通过IMEX=1来把混合型作为文本型读取，避免null值。
                if (FileType == ".xls")
                    strConn = "Provider=Microsoft.Jet.OLEDB.4.0;" +
                                 "Data Source=" + filepath + ";Extended Properties='Excel 8.0;HDR=YES;IMEX=1';";
                else //.xlsx
                    strConn = "Provider=Microsoft.ACE.OLEDB.12.0;" + "Data Source=" + filepath + ";" +
                                 ";Extended Properties='Excel 12.0;HDR=YES;IMEX=0'";
                OleDbConnection oleConn = new OleDbConnection(strConn);
                oleConn.Open();
                //获取所有sheet表名
                System.Data.DataTable dt = oleConn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
                string sql = "";
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    string vSheetsName = dt.Rows[i][2].ToString().Replace("$", "");
                    if (vSheetsName.Contains("FilterDatabase") || vSheetsName.Contains("Print_Titles")
                        || vSheetsName.Contains("_xlnm#Database") || vSheetsName.Contains("Print_Area")
                        || vSheetsName.Contains("_xlnm.Database") || vSheetsName.Contains("ExternalData")
                        || vSheetsName.Contains("Sheet1$zy") || vSheetsName.Contains("DRUG_IMP_STOCK")
                        || vSheetsName.Contains("Sheet1$xy") || vSheetsName.Contains("data_xy_zcy")
                        || vSheetsName.Contains("Results"))
                    {
                        continue;
                    }
                    if (vSheetsName[0].ToString() == "'" && vSheetsName[vSheetsName.Length - 1].ToString() == "'")
                    {
                        vSheetsName = vSheetsName.Substring(1, vSheetsName.Length - 2);
                    }
                    sql += "select * from [" + vSheetsName + "$] union ";
                }
                sql = sql.Substring(0, sql.LastIndexOf("union "));
                OleDbDataAdapter oleDaExcel = new OleDbDataAdapter(sql, oleConn);
                DataSet oleDsExcel = new DataSet();
                oleDaExcel.Fill(oleDsExcel, "table1");
                oleConn.Close();
                return oleDsExcel;
            }
            catch (Exception ex)
            {
                return null;
                throw;
            }
        }
        #endregion


        /// <summary>
        /// 移动某列到指定位置
        /// </summary>
        /// <param name="wsheet">工作表</param>
        /// <param name="beforeIdx">要移动的列索引</param>
        /// <param name="afterIdx">目标位置列索引</param>
        public static void MoveColumn(Worksheet wsheet, string beforeIdx, string afterIdx)
        {
            Range rage1 = (Range)wsheet.Columns[beforeIdx, Missing.Value];
            rage1.Copy();
            Range rage2 = (Range)wsheet.Columns[afterIdx, Missing.Value];
            rage2.EntireColumn.Insert(Microsoft.Office.Interop.Excel.XlDirection.xlToLeft, Missing.Value);
            rage1.Delete();
        }

        /// <summary>
        /// 复制某一列的数值到指定位置
        /// </summary>
        /// <param name="wsheet">工作表</param>
        /// <param name="beforeIdx">要复制的列索引</param>
        /// <param name="afterIdx">目标位置列索引</param>
        public static void CopyColumnValue(Worksheet wsheet, string beforeIdx, string afterIdx)
        {
            Range rage1 = (Range)wsheet.Columns[beforeIdx, Missing.Value];
            rage1.Copy();
            Range rage2 = (Range)wsheet.Columns[afterIdx, Missing.Value];
            rage2.PasteSpecial(XlPasteType.xlPasteValues); //设置只粘贴数值
        }

        /// <summary>
        /// 删除某一列
        /// </summary>
        /// <param name="wsheet">工作表</param>
        /// <param name="delIdx">要删除的列索引</param>
        public static void DeleteColumn(Worksheet wsheet, string delIdx)
        {
            Range rage = (Range)wsheet.Columns[delIdx, Missing.Value];
            rage.Delete();
        }

        /// <summary>
        /// 设置列自动换行和字体大小
        /// </summary>
        /// <param name="wsheet">工作表</param>
        /// <param name="sIdx">要设置的列索引</param>
        /// <param name="fontSize">字体大小</param>
        public static void SetWordWrap(Worksheet wsheet, string sIdx, int fontSize)
        {
            Range rage = (Range)wsheet.Columns[sIdx, Missing.Value];
            rage.WrapText = true;//文本自动换行
            rage.Font.Size = fontSize;//设置字体大小
        }

        public static void SaveDataTable2Excel(System.Data.DataTable dt, string filepath)
        {
            if (dt == null)
                return;
            //OleDbConnection oleConn = new OleDbConnection();
            OleDbCommand oleCmd = new OleDbCommand();
            try
            {
                string strConn;
                string FileType = filepath.Substring(filepath.LastIndexOf("."));

                //注意：把一个excel文件看做一个数据库，一个sheet看做一张表。语法 "SELECT * FROM [sheet1$]"，表单要使用"[]"和"$"
                // 1、HDR表示要把第一行作为数据还是作为列名，作为数据用HDR=no，作为列名用HDR=yes；
                // 2、通过IMEX=1来把混合型作为文本型读取，避免null值。
                if (FileType == ".xls")
                    strConn = "Provider=Microsoft.Jet.OLEDB.4.0;" +
                              "Data Source=" + filepath + ";Extended Properties='Excel 8.0;HDR=no;IMEX=0';";
                else //.xlsx
                    strConn = "Provider=Microsoft.ACE.OLEDB.12.0;" + "Data Source=" + filepath + ";" +
                              ";Extended Properties='Excel 12.0;HDR=YES;IMEX=1'";
                //oleConn.ConnectionString = strConn;
                OleDbConnection oleConn = new OleDbConnection(strConn);
                oleConn.Open();

                string sheetName = "Sheet1";
                foreach (DataRow dr in dt.Rows)
                {
                    //string sql = "INSERT INTO [" + sheetName + "$] (" + dt.Columns[0] + "," + dt.Columns[1] + "," +
                    //             dt.Columns[2] + "," + dt.Columns[3] + "," + dt.Columns[4] + ") VALUES ('" + dr[0] +
                    //             "','" + dr[1] + "','" + dr[2] + "','" + dr[3] + "','" + dr[4] + "')";
                    string sql = "INSERT INTO [Sheet1$] (F1,F2,F3,F4,F5) VALUES('" + dr[0] +
                                 "','" + dr[1] + "','" + dr[2] + "','" + dr[3] + "','" + dr[4] + "')";
                    oleCmd.Connection = oleConn;
                    oleCmd.CommandType = CommandType.Text;
                    oleCmd.CommandText = sql;
                    oleCmd.ExecuteNonQuery();
                }
                oleConn.Close();
            }
            catch (Exception ex)
            {

            }
            finally
            {
                //if (oleConn.State == ConnectionState.Open)
                //{
                //    oleConn.Close();
                //    oleCmd.Dispose();
                //}

            }
        }
    }
}
