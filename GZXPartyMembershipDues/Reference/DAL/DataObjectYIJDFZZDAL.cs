using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using GZXPartyMembershipDues.Reference.Base;

namespace GZXPartyMembershipDues.Reference.DAL
{
    public class DataObjectYIJDFZZDAL
    {
        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="pDataObject"></param>
        /// <param name="sqLiteTransaction"></param>
        public void Add(Obj_YIJDF_ZZ pDataObject, SQLiteTransaction sqLiteTransaction)
        {
            const string mySqlString =
                "insert into YIJDF_ZZ (NAME,GWGZ,XJGZ,ZWBT,JXGZ,TENPERCENT,XJ,JSJE,YKSJ,DFJS,YJDF,YJDFQZ,JFQZYF,JFYS,JFZE) values ($NAME,$GWGZ,$XJGZ,$ZWBT,$JXGZ,$TENPERCENT,$XJ,$JSJE,$YKSJ,$DFJS,$YJDF,$YJDFQZ,$JFQZYF,$JFYS,$JFZE)";

            using (SQLiteCommand myCommand = sqLiteTransaction.Connection.CreateCommand())
            {
                myCommand.CommandText = mySqlString;
                myCommand.Parameters.Add(new SQLiteParameter("NAME", pDataObject.Name));
                myCommand.Parameters.Add(new SQLiteParameter("GWGZ", pDataObject.GWGZ));
                myCommand.Parameters.Add(new SQLiteParameter("XJGZ", pDataObject.XJGZ));
                myCommand.Parameters.Add(new SQLiteParameter("ZWBT", pDataObject.ZWBT));
                myCommand.Parameters.Add(new SQLiteParameter("JXGZ", pDataObject.JXGZ));
                myCommand.Parameters.Add(new SQLiteParameter("TENPERCENT", pDataObject.TENPERCENT));
                myCommand.Parameters.Add(new SQLiteParameter("XJ", pDataObject.XJ));
                myCommand.Parameters.Add(new SQLiteParameter("JSJE", pDataObject.JSJE));
                myCommand.Parameters.Add(new SQLiteParameter("YKSJ", pDataObject.YKSJ));
                myCommand.Parameters.Add(new SQLiteParameter("DFJS", pDataObject.DFJS));
                myCommand.Parameters.Add(new SQLiteParameter("YJDF", pDataObject.YJDF));
                myCommand.Parameters.Add(new SQLiteParameter("YJDFQZ", pDataObject.YJDFQZ));
                myCommand.Parameters.Add(new SQLiteParameter("JFQZYF", pDataObject.JFQZYF));
                myCommand.Parameters.Add(new SQLiteParameter("JFYS", pDataObject.JFYS));
                myCommand.Parameters.Add(new SQLiteParameter("JFZE", pDataObject.JFZE));
                myCommand.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="name">姓名</param>
        /// <param name="sqLiteTransaction"></param>
        public void Delete(string dateSpan, string name, SQLiteTransaction sqLiteTransaction)
        {
            const string mySqlString = "delete from YIJDF_ZZ where NAME=$NAME and JFQZYF=$JFQZYF";

            using (var myCommand = sqLiteTransaction.Connection.CreateCommand())
            {
                myCommand.CommandText = mySqlString;
                myCommand.Parameters.Add(new SQLiteParameter("JFQZYF", dateSpan));
                myCommand.Parameters.Add(new SQLiteParameter("NAME", name));

                myCommand.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="pDataObject"></param>
        /// <param name="sqLiteTransaction"></param>
        public void Update(Obj_YIJDF_ZZ pDataObject, SQLiteTransaction sqLiteTransaction)
        {
            const string mySqlString =
                "update YIJDF_ZZ set GWGZ=$GWGZ,XJGZ=$XJGZ,ZWBT=$ZWBT,JXGZ=$JXGZ,TENPERCENT=$TENPERCENT,XJ=$XJ,JSJE=$JSJE,YKSJ=$YKSJ,DFJS=$DFJS,YJDF=$YJDF,YJDFQZ=$YJDFQZ,JFYS=$JFYS,JFZE=$JFZE where NAME=$NAME and $JFQZYF=$JFQZYF";

            using (SQLiteCommand myCommand = sqLiteTransaction.Connection.CreateCommand())
            {
                myCommand.CommandText = mySqlString;
                myCommand.Parameters.Add(new SQLiteParameter("NAME", pDataObject.Name));
                myCommand.Parameters.Add(new SQLiteParameter("GWGZ", pDataObject.DFJS));
                myCommand.Parameters.Add(new SQLiteParameter("XJGZ", pDataObject.DFJS));
                myCommand.Parameters.Add(new SQLiteParameter("ZWBT", pDataObject.DFJS));
                myCommand.Parameters.Add(new SQLiteParameter("JXGZ", pDataObject.DFJS));
                myCommand.Parameters.Add(new SQLiteParameter("TENPERCENT", pDataObject.DFJS));
                myCommand.Parameters.Add(new SQLiteParameter("XJ", pDataObject.DFJS));
                myCommand.Parameters.Add(new SQLiteParameter("JSJE", pDataObject.DFJS));
                myCommand.Parameters.Add(new SQLiteParameter("YKSJ", pDataObject.DFJS));
                myCommand.Parameters.Add(new SQLiteParameter("DFJS", pDataObject.DFJS));
                myCommand.Parameters.Add(new SQLiteParameter("YJDF", pDataObject.YJDF));
                myCommand.Parameters.Add(new SQLiteParameter("YJDFQZ", pDataObject.YJDFQZ));
                myCommand.Parameters.Add(new SQLiteParameter("JFQZYF", pDataObject.JFQZYF));
                myCommand.Parameters.Add(new SQLiteParameter("JFYS", pDataObject.JFYS));
                myCommand.Parameters.Add(new SQLiteParameter("JFZE", pDataObject.JFZE));

                myCommand.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// 删除所有记录
        /// </summary>
        /// <param name="sqLiteTransaction"></param>
        public void DeleteAll(SQLiteTransaction sqLiteTransaction)
        {
            const string mySqlString = "delete from YIJDF_ZZ";

            using (var myCommand = sqLiteTransaction.Connection.CreateCommand())
            {
                myCommand.CommandText = mySqlString;

                myCommand.ExecuteNonQuery();
            }
        }
        #region BulkCopyInsert只对SqlServer有效
        public void BulkCopyInsert(DataTable dt, SQLiteTransaction sqLiteTransaction)
        {
            using (SqlBulkCopy sqlBulkCopy = new SqlBulkCopy(sqLiteTransaction.Connection.ConnectionString))
            {
                sqlBulkCopy.DestinationTableName = "YIJDF_ZZ";
                foreach (DataColumn dc in dt.Columns)
                {
                    sqlBulkCopy.ColumnMappings.Add(dc.ColumnName, dc.ColumnName);
                }

                sqlBulkCopy.WriteToServer(dt);
            }
            
            
            //sqlBulkCopy.ColumnMappings.Add("NAME", "NAME");
            //sqlBulkCopy.ColumnMappings.Add("GWGZ", "GWGZ");
            //sqlBulkCopy.ColumnMappings.Add("XJGZ", "XJGZ");
            //sqlBulkCopy.ColumnMappings.Add("ZWBT", "ZWBT");
            //sqlBulkCopy.ColumnMappings.Add("JXGZ", "JXGZ");
            //sqlBulkCopy.ColumnMappings.Add("TENPERCENT", "TENPERCENT");
            //sqlBulkCopy.ColumnMappings.Add("XJ", "XJ");
            //sqlBulkCopy.ColumnMappings.Add("JSJE", "JSJE");
            //sqlBulkCopy.ColumnMappings.Add("YKSJ", "YKSJ");
            //sqlBulkCopy.ColumnMappings.Add("DFJS", "DFJS");
            //sqlBulkCopy.ColumnMappings.Add("YJDF", "YJDF");
            //sqlBulkCopy.ColumnMappings.Add("YJDFQZ", "YJDFQZ");
            //sqlBulkCopy.ColumnMappings.Add("JFQZYF", "JFQZYF");
            //sqlBulkCopy.ColumnMappings.Add("JFYS", "JFYS");
            //sqlBulkCopy.ColumnMappings.Add("JFZE", "JFZE");
        }
        #endregion
    }
}
