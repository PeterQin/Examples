using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data.OleDb;
using System.IO;
using System.Configuration;
using System.Data;
using System.Windows.Forms;

namespace DBManagerCodeSimple
{
    public enum DBType
    {
        None,
        SQLServer,
        Access,
    }

    public class DBHelper
    {
        private static readonly string C_CurrentDB = ConfigurationManager.AppSettings["DB"];
        private static readonly string C_ConnStr_SQLServer = ConfigurationManager.ConnectionStrings["SQLServer"].ConnectionString;
        private static readonly string C_ConnStr_Access = ConfigurationManager.ConnectionStrings["Access"].ConnectionString;

        public static ITable_ptest GetTable_Ptest()
        {

            ITable_ptest Result = null;
            switch (StringToEnum(C_CurrentDB))
            {
                case DBType.SQLServer:
                    Result = new TTable_ptest_SQLServer(C_ConnStr_SQLServer);
                    break;
                case DBType.Access:
                    Result = new TTable_ptest_Access(C_ConnStr_Access);
                    break;
            }

            return Result;
        }

        public static DBType StringToEnum(string aEnumStr)
        {
            try
            {
                return (DBType)Enum.Parse(typeof(DBType), aEnumStr);
            }
            catch (Exception)
            {
                return DBType.None;
            }
        }

    }

    public class DBString
    {
        #region Const / Enum / Delegate / Event

        public const string C_TableName_Ptest = "ptest";
        public const string C_ColumnNameID = "id";
        public const string C_ColumnNameData = "data";
        public const string C_SelectAll = "select * from {0}";
        public const string C_SelectByID = "select * from {0} where id = {1}";
        public const string C_Insert = "insert into {0} values ({1}, \'{2}\')";
        public const string C_Update = "update {0} set data = \'{1}\' where id = {2}";
        public const string C_Delete = "delete from {0} where id = {1}";

        #endregion Const / Enum / Delegate / Event
    }

    public interface ITable_ptest
    {
        void Insert(string aID, string aData);
        void Update(string aID, string aData);
        void Delete(string aID);
        DataTable Select(string aID);
    }

    public class TTable_ptest_SQLServer : ITable_ptest
    {
        #region Field
        private string FConnectionStr;
        private SqlConnection FConnection;
        private SqlCommand FCommand;

        #region Property
        #endregion Property

        #endregion Field

        #region Constructor & Destroyer

        public TTable_ptest_SQLServer(string aConnStr)
        {
            Init(aConnStr);
        }

        #endregion Constructor & Destroyer

        #region Private Section

        private void Init(string aConnStr)
        {
            FConnectionStr = aConnStr;
            FConnection = new SqlConnection(FConnectionStr);
            FCommand = new SqlCommand();
            FCommand.Connection = FConnection;
        }

        #endregion Private Section

        #region ITable_ptest Members

        public void Insert(string aID, string aData)
        {
            string ID = aID;
            string Data = aData;
            if (string.IsNullOrEmpty(ID.Trim()) || string.IsNullOrEmpty(Data.Trim()))
            {
                MessageBox.Show("ID or Data could not be empty");
            }
            else
            {
                string SelectStr = string.Format(DBString.C_SelectAll, DBString.C_TableName_Ptest);
                string InsertStr = string.Format(DBString.C_Insert, DBString.C_TableName_Ptest, ID, Data);
                try
                {
                    FConnection.Open();
                    SqlDataAdapter sda = new SqlDataAdapter(SelectStr, FConnection);
                    DataSet ds = new DataSet();
                    sda.Fill(ds, DBString.C_TableName_Ptest);
                    DataTable dt = ds.Tables[DBString.C_TableName_Ptest];
                    DataRow dr = dt.NewRow();
                    dr[DBString.C_ColumnNameID] = ID;
                    dr[DBString.C_ColumnNameData] = Data;
                    dt.Rows.Add(dr);
                    sda.InsertCommand = new SqlCommand(InsertStr, FConnection);
                    sda.Update(ds, DBString.C_TableName_Ptest);

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    FConnection.Close();
                }

            }
        }

        public void Update(string aID, string aData)
        {
            string ID = aID;
            string Data = aData;
            if (string.IsNullOrEmpty(ID.Trim()) || string.IsNullOrEmpty(Data.Trim()))
            {
                MessageBox.Show("ID or Data could not be empty");
            }
            else
            {
                string UpdateStr = string.Format(DBString.C_Update, DBString.C_TableName_Ptest, Data, ID);
                string SelectStr = string.Format(DBString.C_SelectByID, DBString.C_TableName_Ptest, ID);
                SqlDataAdapter sda = new SqlDataAdapter(SelectStr, FConnection);
                DataSet ds = new DataSet();
                sda.Fill(ds, DBString.C_TableName_Ptest);
                DataTable dt = ds.Tables[DBString.C_TableName_Ptest];
                dt.Rows[0][DBString.C_ColumnNameData] = Data;
                sda.UpdateCommand = new SqlCommand(UpdateStr, FConnection);
                sda.Update(ds, DBString.C_TableName_Ptest);
            }
        }

        public void Delete(string aID)
        {
            string ID = aID;
            if (string.IsNullOrEmpty(ID.Trim()))
            {
                MessageBox.Show("ID could not be empty");
            }
            else
            {
                string SelectStr = string.Format(DBString.C_SelectByID, DBString.C_TableName_Ptest, ID);
                string DeleteStr = string.Format(DBString.C_Delete, DBString.C_TableName_Ptest, ID);
                SqlDataAdapter sda = new SqlDataAdapter(SelectStr, FConnection);
                DataSet ds = new DataSet();
                sda.Fill(ds, DBString.C_TableName_Ptest);
                DataTable dt = ds.Tables[DBString.C_TableName_Ptest];
                if (dt.Rows.Count > 0)
                {
                    dt.Rows[0].Delete();
                    sda.DeleteCommand = new SqlCommand(DeleteStr, FConnection);
                    sda.Update(ds, DBString.C_TableName_Ptest);
                }
                else
                {
                    MessageBox.Show("Doesn't exist");
                }
            }
        }

        public DataTable Select(string aID)
        {
            DataTable Result = null;
            string ID = aID;
            string SelectStr;
            if (string.IsNullOrEmpty(ID.Trim()))
            {
                SelectStr = string.Format(DBString.C_SelectAll, DBString.C_TableName_Ptest);
            }
            else
            {
                SelectStr = string.Format(DBString.C_SelectByID, DBString.C_TableName_Ptest, ID);
            }
            FCommand.CommandText = SelectStr;
            try
            {
                FConnection.Open();
                if (FCommand.ExecuteScalar() == null)
                {
                    MessageBox.Show("No data found");
                }
                else
                {
                    SqlDataAdapter sda = new SqlDataAdapter(SelectStr, FConnection);
                    DataSet ds = new DataSet();
                    sda.Fill(ds, DBString.C_TableName_Ptest);
                    Result = ds.Tables[DBString.C_TableName_Ptest];

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                FConnection.Close();
            }

            return Result;
        }

        #endregion
    }

    public class TTable_ptest_Access : ITable_ptest
    {
        #region Field
        OleDbConnection FConnection = null;

        #region Const / Enum / Delegate / Event
        #endregion Const / Enum / Delegate / Event

        #region Property
        #endregion Property

        #endregion Field

        #region Constructor & Destroyer

        public TTable_ptest_Access(string aConnStr)
        {
            Init(aConnStr);
        }

        #endregion Constructor & Destroyer

        #region Private Section

        private void Init(string aConnStr)
        {
            FConnection = new OleDbConnection(aConnStr);
        }

        #endregion Private Section

        #region ITable_ptest Members

        public void Insert(string aID, string aData)
        {
            string ID = aID;
            string Data = aData;
            if (string.IsNullOrEmpty(ID.Trim()) || string.IsNullOrEmpty(Data.Trim()))
            {
                MessageBox.Show("ID or Data could not be empty");
            }
            else
            {
                string SelectStr = string.Format(DBString.C_SelectAll, DBString.C_TableName_Ptest);
                string InsertStr = string.Format(DBString.C_Insert, DBString.C_TableName_Ptest, ID, Data);
                try
                {
                    FConnection.Open();
                    OleDbDataAdapter sda = new OleDbDataAdapter(SelectStr, FConnection);
                    DataSet ds = new DataSet();
                    sda.Fill(ds, DBString.C_TableName_Ptest);
                    DataTable dt = ds.Tables[DBString.C_TableName_Ptest];
                    DataRow dr = dt.NewRow();
                    dr[DBString.C_ColumnNameID] = ID;
                    dr[DBString.C_ColumnNameData] = Data;
                    dt.Rows.Add(dr);
                    sda.InsertCommand = new OleDbCommand(InsertStr, FConnection);
                    sda.Update(ds, DBString.C_TableName_Ptest);

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    FConnection.Close();
                }

            }
        }

        public void Update(string aID, string aData)
        {
            string ID = aID;
            string Data = aData;
            if (string.IsNullOrEmpty(ID.Trim()) || string.IsNullOrEmpty(Data.Trim()))
            {
                MessageBox.Show("ID or Data could not be empty");
            }
            else
            {
                string UpdateStr = string.Format(DBString.C_Update, DBString.C_TableName_Ptest, Data, ID);
                string SelectStr = string.Format(DBString.C_SelectByID, DBString.C_TableName_Ptest, ID);
                OleDbDataAdapter sda = new OleDbDataAdapter(SelectStr, FConnection);
                DataSet ds = new DataSet();
                sda.Fill(ds, DBString.C_TableName_Ptest);
                DataTable dt = ds.Tables[DBString.C_TableName_Ptest];
                dt.Rows[0][DBString.C_ColumnNameData] = Data;
                sda.UpdateCommand = new OleDbCommand(UpdateStr, FConnection);
                sda.Update(ds, DBString.C_TableName_Ptest);
            }
        }

        public void Delete(string aID)
        {
            string ID = aID;
            if (string.IsNullOrEmpty(ID.Trim()))
            {
                MessageBox.Show("ID could not be empty");
            }
            else
            {
                string SelectStr = string.Format(DBString.C_SelectByID, DBString.C_TableName_Ptest, ID);
                string DeleteStr = string.Format(DBString.C_Delete, DBString.C_TableName_Ptest, ID);
                OleDbDataAdapter sda = new OleDbDataAdapter(SelectStr, FConnection);
                DataSet ds = new DataSet();
                sda.Fill(ds, DBString.C_TableName_Ptest);
                DataTable dt = ds.Tables[DBString.C_TableName_Ptest];
                if (dt.Rows.Count > 0)
                {
                    dt.Rows[0].Delete();
                    sda.DeleteCommand = new OleDbCommand(DeleteStr, FConnection);
                    sda.Update(ds, DBString.C_TableName_Ptest);
                }
                else
                {
                    MessageBox.Show("Doesn't exist");
                }
            }

        }

        public DataTable Select(string aID)
        {
            DataTable Result = null;
            string sql = string.Empty;
            if (string.IsNullOrEmpty(aID.Trim()))
            {
                sql = string.Format(DBString.C_SelectAll, DBString.C_TableName_Ptest);
            }
            else
            {
                sql = string.Format(DBString.C_SelectByID, DBString.C_TableName_Ptest, aID);
            }
            try
            {

                FConnection.Open();
                OleDbDataAdapter adapter = new OleDbDataAdapter(sql, FConnection);
                DataSet ds = new DataSet();
                adapter.Fill(ds);
                Result = ds.Tables[0];
            }
            catch (Exception ex)
            {
                MessageBox.Show("Select Fail: \r\n" + ex.Message);
            }
            finally
            {
                FConnection.Close();
            }
            return Result;
        }

        #endregion
    }



    public class ProjectDBHelper
    {
        private string FConnStr = "server = ZHUVMSTDSQL2008R2;uid = sqlexp; pwd = sqlexp; database = QSOO8.6";
        public DataTable LoadAllProject()
        {
            DataTable Result = null;
            SqlConnection FConnection = new SqlConnection(FConnStr);
            try
            {
                FConnection.Open();
                SqlCommand FCommand = new SqlCommand();
                string SelectStr = "select * from dbo.TestObjective";
                SqlDataAdapter sda = new SqlDataAdapter(SelectStr, FConnection);
                DataSet ds = new DataSet();
                sda.Fill(ds, "tablename");
                Result = ds.Tables["tablename"];
            }
            finally
            {
                FConnection.Close();
            }
            return Result;
        }
    }
}
