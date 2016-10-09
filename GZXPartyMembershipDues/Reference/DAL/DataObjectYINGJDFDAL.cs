using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GZXPartyMembershipDues.Reference.Base;
using System.Data.SQLite;

namespace GZXPartyMembershipDues.Reference.DAL
{
    public class DataObjectYINGJDFDAL
    {
        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="pDataObject"></param>
        /// <param name="sqLiteTransaction"></param>
        public void Add(Obj_YINGJDF pDataObject, SQLiteTransaction sqLiteTransaction)
        {
            const string mySqlString =
                "insert into YINGJDF (DATE,NAME,DFJS,DFJSQZ,YINGJDF,YINGJDFQZ) values ($DATE,$NAME,$DFJS,$DFJSQZ,$YINGJDF,$YINGJDFQZ)";

            using (SQLiteCommand myCommand = sqLiteTransaction.Connection.CreateCommand())
            {
                myCommand.CommandText = mySqlString;
                myCommand.Parameters.Add(new SQLiteParameter("DATE", pDataObject.Date));
                myCommand.Parameters.Add(new SQLiteParameter("NAME", pDataObject.Name));
                myCommand.Parameters.Add(new SQLiteParameter("DFJS", pDataObject.DFJS));
                myCommand.Parameters.Add(new SQLiteParameter("DFJSQZ", pDataObject.DFJSQZ));
                myCommand.Parameters.Add(new SQLiteParameter("YINGJDF", pDataObject.YINGJDF));
                myCommand.Parameters.Add(new SQLiteParameter("YINGJDFQZ", pDataObject.YINGJDFQZ));

                myCommand.ExecuteNonQuery();
            }
        }

        public void Add(ArrayList pDataObjectArr, SQLiteTransaction sqLiteTransaction)
        {
            const string mySqlString =
                "insert into YINGJDF (DATE,NAME,DFJS,DFJSQZ,YINGJDF,YINGJDFQZ) values ($DATE,$NAME,$DFJS,$DFJSQZ,$YINGJDF,$YINGJDFQZ)";
            foreach (Obj_YINGJDF pDataObject in pDataObjectArr)
            {
                using (SQLiteCommand myCommand = sqLiteTransaction.Connection.CreateCommand())
                {
                    myCommand.CommandText = mySqlString;
                    myCommand.Parameters.Add(new SQLiteParameter("DATE", pDataObject.Date));
                    myCommand.Parameters.Add(new SQLiteParameter("NAME", pDataObject.Name));
                    myCommand.Parameters.Add(new SQLiteParameter("DFJS", pDataObject.DFJS));
                    myCommand.Parameters.Add(new SQLiteParameter("DFJSQZ", pDataObject.DFJSQZ));
                    myCommand.Parameters.Add(new SQLiteParameter("YINGJDF", pDataObject.YINGJDF));
                    myCommand.Parameters.Add(new SQLiteParameter("YINGJDFQZ", pDataObject.YINGJDFQZ));

                    myCommand.ExecuteNonQuery();
                }
            }
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="date">日期</param>
        /// <param name="name">姓名</param>
        /// <param name="sqLiteTransaction"></param>
        public void Delete(DateTime date, string name, SQLiteTransaction sqLiteTransaction)
        {
            const string mySqlString = "delete from YINGJDF where NAME=$NAME and DATE=$DATE";

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
        public void Update(Obj_YINGJDF pDataObject, SQLiteTransaction sqLiteTransaction)
        {
            const string mySqlString =
                "update YINGJDF set DFJS=$DFJS,DFJSQZ=$DFJSQZ,YINGJDF=$YINGJDF,YINGJDFQZ=$YINGJDFQZ where NAME=$NAME and DATE=$DATE";

            using (SQLiteCommand myCommand = sqLiteTransaction.Connection.CreateCommand())
            {
                myCommand.CommandText = mySqlString;
                myCommand.Parameters.Add(new SQLiteParameter("DATE", pDataObject.Date));
                myCommand.Parameters.Add(new SQLiteParameter("NAME", pDataObject.Name));
                myCommand.Parameters.Add(new SQLiteParameter("DFJS", pDataObject.DFJS));
                myCommand.Parameters.Add(new SQLiteParameter("DFJSQZ", pDataObject.DFJSQZ));
                myCommand.Parameters.Add(new SQLiteParameter("YINGJDF", pDataObject.YINGJDF));
                myCommand.Parameters.Add(new SQLiteParameter("YINGJDFQZ", pDataObject.YINGJDFQZ));

                myCommand.ExecuteNonQuery();
            }
        }

        public void DeleteAll(SQLiteTransaction sqLiteTransaction)
        {
            const string mySqlString = "delete from YINGJDF";

            using (var myCommand = sqLiteTransaction.Connection.CreateCommand())
            {
                myCommand.CommandText = mySqlString;

                myCommand.ExecuteNonQuery();
            }
        }
    }
}
