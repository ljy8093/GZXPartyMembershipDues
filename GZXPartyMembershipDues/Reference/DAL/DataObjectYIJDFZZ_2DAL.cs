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
    public class DataObjectYIJDFZZ_2DAL
    {
        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="pDataObject"></param>
        /// <param name="sqLiteTransaction"></param>
        public void Add(Obj_YIJDF_ZZ_2 pDataObject, SQLiteTransaction sqLiteTransaction)
        {
            const string mySqlString =
                "insert into YIJDF_ZZ_2 (DATE,NAME,GWGZ,XJGZ,ZWBT,JXGZ,TENPERCENT,XJ,JSJE,YKSJ,DFJS,YJDF,YJDFQZ,JFQZYF) values ($DATE,$NAME,$GWGZ,$XJGZ,$ZWBT,$JXGZ,$TENPERCENT,$XJ,$JSJE,$YKSJ,$DFJS,$YJDF,$YJDFQZ,$JFQZYF)";

            using (SQLiteCommand myCommand = sqLiteTransaction.Connection.CreateCommand())
            {
                myCommand.CommandText = mySqlString;
                myCommand.Parameters.Add(new SQLiteParameter("DATE", pDataObject.DATE));
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

                myCommand.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="name">姓名</param>
        /// <param name="sqLiteTransaction"></param>
        public void Delete(DateTime date, string name, SQLiteTransaction sqLiteTransaction)
        {
            const string mySqlString = "delete from YIJDF_ZZ_2 where NAME=$NAME and DATE=$DATE";

            using (var myCommand = sqLiteTransaction.Connection.CreateCommand())
            {
                myCommand.CommandText = mySqlString;
                myCommand.Parameters.Add(new SQLiteParameter("DATE", date));
                myCommand.Parameters.Add(new SQLiteParameter("NAME", name));

                myCommand.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="pDataObject"></param>
        /// <param name="sqLiteTransaction"></param>
        public void Update(Obj_YIJDF_ZZ_2 pDataObject, SQLiteTransaction sqLiteTransaction)
        {
            const string mySqlString =
                "update YIJDF_ZZ_2 set GWGZ=$GWGZ,XJGZ=$XJGZ,ZWBT=$ZWBT,JXGZ=$JXGZ,TENPERCENT=$TENPERCENT,XJ=$XJ,JSJE=$JSJE,YKSJ=$YKSJ,DFJS=$DFJS,YJDF=$YJDF,YJDFQZ=$YJDFQZ,JFQZYF=$JFQZYF where NAME=$NAME and DATE=$DATE";

            using (SQLiteCommand myCommand = sqLiteTransaction.Connection.CreateCommand())
            {
                myCommand.CommandText = mySqlString;
                myCommand.Parameters.Add(new SQLiteParameter("DATE", pDataObject.DATE));
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

                myCommand.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// 删除所有记录
        /// </summary>
        /// <param name="sqLiteTransaction"></param>
        public void DeleteAll(SQLiteTransaction sqLiteTransaction)
        {
            const string mySqlString = "delete from YIJDF_ZZ_2";

            using (var myCommand = sqLiteTransaction.Connection.CreateCommand())
            {
                myCommand.CommandText = mySqlString;

                myCommand.ExecuteNonQuery();
            }
        }

    }
}
