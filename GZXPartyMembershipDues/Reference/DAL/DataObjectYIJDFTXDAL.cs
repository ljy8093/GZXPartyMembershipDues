using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using GZXPartyMembershipDues.Reference.Base;

namespace GZXPartyMembershipDues.Reference.DAL
{
    public class DataObjectYIJDFTXDAL
    {
        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="pDataObject"></param>
        /// <param name="sqLiteTransaction"></param>
        public void Add(Obj_YIJDF_TX pDataObject, SQLiteTransaction sqLiteTransaction)
        {
            const string mySqlString =
                "insert into YIJDF_TX (NAME,DFJS,YJDF,YJDFQZ,JFQZYF,JFYS,JFZE) values ($NAME,$DFJS,$YJDF,$YJDFQZ,$JFQZYF,$JFYS,$JFZE)";

            using (SQLiteCommand myCommand = sqLiteTransaction.Connection.CreateCommand())
            {
                myCommand.CommandText = mySqlString;
                myCommand.Parameters.Add(new SQLiteParameter("NAME", pDataObject.Name));
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
            const string mySqlString = "delete from YIJDF_TX where NAME=$NAME and JFQZYF=$JFQZYF";

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
        public void Update(Obj_YIJDF_TX pDataObject, SQLiteTransaction sqLiteTransaction)
        {
            const string mySqlString =
                "update YIJDF_TX set DFJS=$DFJS,YJDF=$YJDF,YJDFQZ=$YJDFQZ,JFYS=$JFYS,JFZE=$JFZE where NAME=$NAME and JFQZYF=$JFQZYF";

            using (SQLiteCommand myCommand = sqLiteTransaction.Connection.CreateCommand())
            {
                myCommand.CommandText = mySqlString;
                myCommand.Parameters.Add(new SQLiteParameter("NAME", pDataObject.Name));
                myCommand.Parameters.Add(new SQLiteParameter("DFJS", pDataObject.DFJS));
                myCommand.Parameters.Add(new SQLiteParameter("YJDF", pDataObject.YJDF));
                myCommand.Parameters.Add(new SQLiteParameter("YJDFQZ", pDataObject.YJDFQZ));
                myCommand.Parameters.Add(new SQLiteParameter("JFQZYF", pDataObject.JFQZYF));
                myCommand.Parameters.Add(new SQLiteParameter("JFYS", pDataObject.JFYS));
                myCommand.Parameters.Add(new SQLiteParameter("JFZE", pDataObject.JFZE));

                myCommand.ExecuteNonQuery();
            }
        }

        public void DeleteAll(SQLiteTransaction sqLiteTransaction)
        {
            const string mySqlString = "delete from YIJDF_TX";

            using (var myCommand = sqLiteTransaction.Connection.CreateCommand())
            {
                myCommand.CommandText = mySqlString;

                myCommand.ExecuteNonQuery();
            }
        }
    }
}
