using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using GZXPartyMembershipDues.Reference.Base;
using GZXPartyMembershipDues.Reference.DAL;

namespace GZXPartyMembershipDues.Reference
{
    public class SqlLiteCommon
    {
        private readonly SQLiteConnectionStringBuilder _SQLiteConnectionStringBuilder =
            new SQLiteConnectionStringBuilder();
        private string _sqliteDBFilePath = @"D:\VSWorkSpace\GZXPartyMembershipDues\GZX.db";

        public SqlLiteCommon()
        {
            _SQLiteConnectionStringBuilder.DataSource = _sqliteDBFilePath;
        }
        public SqlLiteCommon(string sqliteDBFilePath)
        {
            _sqliteDBFilePath = sqliteDBFilePath;
            _SQLiteConnectionStringBuilder.DataSource = _sqliteDBFilePath;
        }
        public string SqliteDbFilePath
        {
            get
            {
                return _sqliteDBFilePath;
            }
            set
            {
                _sqliteDBFilePath = value;
                _SQLiteConnectionStringBuilder.DataSource = _sqliteDBFilePath;
            }
        }

        /// <summary>
        ///     添加
        /// </summary>
        /// <param name="pDataObject"></param>
        public void Add(Object pDataObject)
        {
            using (SQLiteConnection mySQLiteConnection = new SQLiteConnection(_SQLiteConnectionStringBuilder.ConnectionString))
            {
                mySQLiteConnection.Open();
                SQLiteTransaction mySQLiteTransaction = mySQLiteConnection.BeginTransaction();

                try
                {
                    if (pDataObject is Obj_YINGJDF)
                    {
                        DataObjectYINGJDFDAL objYINGJDFDAL = new DataObjectYINGJDFDAL();
                        objYINGJDFDAL.Add(pDataObject as Obj_YINGJDF, mySQLiteTransaction);
                    }
                    else if (pDataObject is Obj_YIJDF_ZZ)
                    {

                    }
                    else if (pDataObject is Obj_YIJDF_TX)
                    {

                    }
                    else if (pDataObject is Obj_YIJDF_ZZ_2)
                    {
                        DataObjectYIJDFZZ_2DAL objYIJDFZZ_2DAL = new DataObjectYIJDFZZ_2DAL();
                        objYIJDFZZ_2DAL.Add(pDataObject as Obj_YIJDF_ZZ_2, mySQLiteTransaction);
                    }
                    else if (pDataObject is Obj_YIJDF_TX_2)
                    {
                        DataObjectYIJDFTX_2DAL objYIJDFTX_2DAL = new DataObjectYIJDFTX_2DAL();
                        objYIJDFTX_2DAL.Add(pDataObject as Obj_YIJDF_TX_2, mySQLiteTransaction);
                    }
                    else
                    {

                    }
                    mySQLiteTransaction.Commit();
                }
                catch (Exception ex)
                {
                    mySQLiteTransaction.Rollback();
                    //throw ex;
                }
                finally
                {
                    mySQLiteConnection.Close();
                }
            }             
        }

        public void Add(ArrayList pDataObjectArr)
        {
            using (SQLiteConnection mySQLiteConnection = new SQLiteConnection(_SQLiteConnectionStringBuilder.ConnectionString))
            {
                mySQLiteConnection.Open();
                SQLiteTransaction mySQLiteTransaction = mySQLiteConnection.BeginTransaction();

                try
                {
                    foreach (Object pDataObject in pDataObjectArr)
                    {
                        if (pDataObject is Obj_YINGJDF)
                        {
                            DataObjectYINGJDFDAL objYINGJDFDAL = new DataObjectYINGJDFDAL();
                            objYINGJDFDAL.Add(pDataObject as Obj_YINGJDF, mySQLiteTransaction);
                        }
                        else if (pDataObject is Obj_YIJDF_ZZ)
                        {

                        }
                        else if (pDataObject is Obj_YIJDF_TX)
                        {

                        }
                        else if (pDataObject is Obj_YIJDF_ZZ_2)
                        {
                            DataObjectYIJDFZZ_2DAL objYIJDFZZ_2DAL = new DataObjectYIJDFZZ_2DAL();
                            objYIJDFZZ_2DAL.Add(pDataObject as Obj_YIJDF_ZZ_2, mySQLiteTransaction);
                        }
                        else if (pDataObject is Obj_YIJDF_TX_2)
                        {
                            DataObjectYIJDFTX_2DAL objYIJDFTX_2DAL = new DataObjectYIJDFTX_2DAL();
                            objYIJDFTX_2DAL.Add(pDataObject as Obj_YIJDF_TX_2, mySQLiteTransaction);
                        }
                        else
                        {

                        }
                    }
                    mySQLiteTransaction.Commit();
                }
                catch (Exception ex)
                {
                    mySQLiteTransaction.Rollback();
                    //throw ex;
                }
                finally
                {
                    mySQLiteConnection.Close();
                }
            }
        }


        /// <summary>
        ///     删除
        /// </summary>
        /// <param name="pDataObject"></param>
        public void Delete(Object pDataObject)
        {
            using (
                SQLiteConnection mySQLiteConnection =
                    new SQLiteConnection(_SQLiteConnectionStringBuilder.ConnectionString))
            {
                mySQLiteConnection.Open();
                SQLiteTransaction mySQLiteTransaction = mySQLiteConnection.BeginTransaction();

                try
                {
                    //TODO

                    mySQLiteTransaction.Commit();
                }
                catch (Exception ex)
                {
                    mySQLiteTransaction.Rollback();
                }
                finally
                {
                    mySQLiteConnection.Close();
                }
            }
                
        }

        public bool Clear(string objtype)
        {
            bool done = false;
            using (
                SQLiteConnection mySQLiteConnection =
                    new SQLiteConnection(_SQLiteConnectionStringBuilder.ConnectionString))
            {
                mySQLiteConnection.Open();
                SQLiteTransaction mySQLiteTransaction = mySQLiteConnection.BeginTransaction();

                try
                {
                    switch (objtype)
                    {
                        case "YINGJDF":
                            DataObjectYINGJDFDAL objYingJDFDAL = new DataObjectYINGJDFDAL();
                            objYingJDFDAL.DeleteAll(mySQLiteTransaction);
                            break;
                        case "YIJDFZZ_2":
                            DataObjectYIJDFZZ_2DAL objYIJDFZZ_2DAL = new DataObjectYIJDFZZ_2DAL();
                            objYIJDFZZ_2DAL.DeleteAll(mySQLiteTransaction);
                            break;
                        case "YIJDFTX_2":
                            DataObjectYIJDFTX_2DAL objYIJDFTX_2DAL = new DataObjectYIJDFTX_2DAL();
                            objYIJDFTX_2DAL.DeleteAll(mySQLiteTransaction);
                            break;
                        case "YIJDFZZ":
                            DataObjectYIJDFZZDAL objYIJDFZZDAL = new DataObjectYIJDFZZDAL();
                            objYIJDFZZDAL.DeleteAll(mySQLiteTransaction);
                            break;
                        case "YIJDFTX":
                            DataObjectYIJDFTXDAL objYIJDFTXDAL = new DataObjectYIJDFTXDAL();
                            objYIJDFTXDAL.DeleteAll(mySQLiteTransaction);
                            break;
                    }
                    mySQLiteTransaction.Commit();
                    done = !done;
                }
                catch (Exception ex)
                {
                    mySQLiteTransaction.Rollback();
                    //throw ex;
                }
                finally
                {
                    mySQLiteConnection.Close();
                }
                return done;
            }
        }

        #region BulkCopyInsert只对SqlServer有效
        public void BulkCopyAdd(DataTable dt, string tableType)
        {
            using (
                SQLiteConnection mySQLiteConnection =
                    new SQLiteConnection(_SQLiteConnectionStringBuilder.ConnectionString))
            {
                mySQLiteConnection.Open();
                SQLiteTransaction mySQLiteTransaction = mySQLiteConnection.BeginTransaction();
                try
                {
                    if (tableType == "Obj_YINGJDF")
                    {
                        DataObjectYINGJDFDAL objYINGJDFDAL = new DataObjectYINGJDFDAL();

                    }
                    else if (tableType == "Obj_YIJDF_ZZ")
                    {
                        DataObjectYIJDFZZDAL objYIJDFZZDAL = new DataObjectYIJDFZZDAL();
                        objYIJDFZZDAL.BulkCopyInsert(dt, mySQLiteTransaction);
                    }
                    else if (tableType == "Obj_YIJDF_TX")
                    {

                    }
                    else
                    {

                    }
                    mySQLiteTransaction.Commit();
                }
                catch (Exception ex)
                {
                    mySQLiteTransaction.Rollback();
                    //throw ex;
                }
                finally
                {
                    mySQLiteConnection.Close();
                }
            }
        }

        #endregion

        public DataTable Select(string type)
        {
            using (
                SQLiteConnection mySQLiteConnection =
                    new SQLiteConnection(_SQLiteConnectionStringBuilder.ConnectionString))
            {
                string mySqlString =
                    "select t2.NAME,t2.DATE,t2.YINGJDFQZ,t1.YJDFQZ,t2.YINGJDFQZ-t1.YJDFQZ from YIJDF_ZZ_2 t1, YINGJDF t2 where t1.DATE = t2.DATE and t1.NAME = t2.NAME";
                SQLiteDataAdapter adptr = new SQLiteDataAdapter(mySqlString, mySQLiteConnection);
                DataTable data = new DataTable();
                adptr.Fill(data);
                return data;
            }
        }
    }

}
