using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Threading;

namespace ATCMDataMigrate
{
    public partial class frmMerge : Form
    {
        private static readonly string C_ConnStr_SQLServer = "server = ZHUVMSTAAJMSDATA;uid = sa; pwd = sqlexp!23; database = {0}";

        private string FConnectionStr;
        private SqlConnection FConnection;
        private SqlCommand FCommand;


        private string DestinationDB
        {
            get
            {
                return cmbProjSuite.Text;
            }
        }

        private string SourceDB
        {
            get
            {
                return cmbSourceDB.Text;
            }
        }

        public frmMerge()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            bool success = true;
            try
            {
                string msg = "Importing...";

                DisplayMsg(msg);
                btnOK.Enabled = false;
                btnCreateRelation.Enabled = false;

                //this.BeginInvoke(new delegate_migrate(Migrate));

                Thread threadMigrate = new Thread(new ThreadStart(Migrate));
                threadMigrate.Start();
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\r\n" + ex.StackTrace);
                success = false;
                btnOK.Enabled = true;
                btnCreateRelation.Enabled = true;
            }
            
        }

        private delegate void delegate_migrate();
        private delegate void delegate_msg(string aMsg);

        private void DisplayMsg(string aMsg)
        {
            if (aMsg.Equals("SUCCESS"))
            {
                btnOK.Enabled = true;
                btnCreateRelation.Enabled = true;
            }
            lblMsg.Text = aMsg;
        }

        private void Migrate()
        {
            try
            {
                string ProjectSuiteID = string.Empty;
                string ProjectID = string.Empty;
                Dictionary<string, string> ProjectSuites = GetAllProjectSuite();
                if (ProjectSuites.ContainsValue(DestinationDB) == false)
                {
                    CreateNewDB(DestinationDB);
                    InsertProjectSuite(ref ProjectSuiteID, DestinationDB);
                }
                else
                {
                    foreach (KeyValuePair<string, string> var in ProjectSuites)
                    {
                        if (var.Value.Equals(DestinationDB))
                        {
                            ProjectSuiteID = var.Key;
                            break;
                        }
                    }
                }
                if (string.Empty != ProjectSuiteID)
                {
                    InsertProject(ref ProjectID, DestinationDB, SourceDB);
                    if (string.Empty != ProjectID)
                    {
                        //ValidateWorkflowStep(SourceDB);
                        if (ProjectSuites.ContainsValue(DestinationDB) == false)
                        {
                            RunSelectIntoBatch(SourceDB, DestinationDB, ProjectID);
                        }
                        else
                        {
                            RunInsertInto(SourceDB, DestinationDB, ProjectID);
                        }

                    }
                    else
                    {
                        throw new Exception("No Project ID");
                    }
                }
                else
                {
                    throw new Exception("No Project Suite ID");
                }
                string msg = "SUCCESS";
                this.Invoke(new delegate_msg(DisplayMsg), msg);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\r\n" + ex.StackTrace);
            }
           
        }

        private void InitConn(string aConnStr)
        {
            FConnectionStr = aConnStr;
            FConnection = new SqlConnection(FConnectionStr);
            FCommand = new SqlCommand();
            FCommand.Connection = FConnection;
        }

        private const string C_SelectAll = "select * from {0}";
        private const string C_SelectMax = "select max({0}) from {1}";
        private const string C_SelectByID = "select * from {0} where id = {1}";
        private const string C_ProjectSuite = "ProjectSuites";
        private const string C_Projects = "Projects";
        private const string C_ProjectID = "ProjectID";
        private const string C_ProjectName = "ProjectName";
        private const string C_SuiteName = "SuiteName";
        private const string C_SuiteID = "SuiteID";
        public const string C_Insert_ProjectSuite = "INSERT INTO [AJMSDATA].[dbo].[ProjectSuites] ([SuiteName]) VALUES ('{0}')";
        public const string C_Insert_Projects = "set identity_insert [{0}].[dbo].[Projects] on; INSERT INTO [{0}].[dbo].[Projects] ([ProjectID],[ProjectName]) VALUES ({1},'{2}'); set identity_insert [{0}].[dbo].[Projects] off";
        private const string C_ColumnName = "ColumnName";
        private const string C_DataTypeName = "DataTypeName";
        private const string C_ColumnSize = "ColumnSize";

        private Dictionary<string, string> GetAllProjectSuite()
        {
           InitConn(string.Format(C_ConnStr_SQLServer, "AJMSDATA"));
           Dictionary<string, string> Result = new Dictionary<string, string>();
           DataTable dt = SelectProjectSuite(string.Empty);
           if (dt != null && dt.Rows.Count > 0)
           {
               foreach (DataRow dr in dt.Rows)
               {
                   Result.Add(dr[C_SuiteID].ToString(),dr[C_SuiteName].ToString());
               }
           }
           return Result;
        }

        private List <string> GetAllDBName()
        {
            List<string> Result = new List< string>();
            using (SqlConnection ServerConnection = new SqlConnection(string.Format(C_ConnStr_SQLServer, "master")))
            {
                string strCreateDB = "Create database {0}";
                SqlCommand serverCommand = new SqlCommand(rcMigrate.sql_AllDBName, ServerConnection);
                ServerConnection.Open();
                SqlDataReader reader = serverCommand.ExecuteReader();
                while (reader.Read())
                {
                    Result.Add(reader[0].ToString());
                }
                reader.Close();
            }
            return Result;
        }


        public DataTable SelectProjectSuite(string aID)
        {
            DataTable Result = null;
            string ID = aID;
            string SelectStr;
            if (string.IsNullOrEmpty(ID.Trim()))
            {
                SelectStr = string.Format(C_SelectAll, C_ProjectSuite);
            }
            else
            {
                SelectStr = string.Format(C_SelectByID, C_ProjectSuite, ID);
            }
            FCommand.CommandText = SelectStr;
            try
            {
                FConnection.Open();
                if (FCommand.ExecuteScalar() == null)
                {
                    //MessageBox.Show("No project suite found");
                }
                else
                {
                    SqlDataAdapter sda = new SqlDataAdapter(SelectStr, FConnection);
                    DataSet ds = new DataSet();
                    sda.Fill(ds, C_ProjectSuite);
                    Result = ds.Tables[C_ProjectSuite];

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

        private void frmMigrate_Load(object sender, EventArgs e)
        {
            try
            {
                
                Dictionary<string, string> ProjSuiteList = GetAllProjectSuite();
                foreach (KeyValuePair<string, string> var in ProjSuiteList)
                {
                    cmbProjSuite.Properties.Items.Add(var.Value);
                }

                List<string> dbNames = GetAllDBName();
                foreach (string name in dbNames)
                {
                    cmbSourceDB.Properties.Items.Add(name);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\r\n" + ex.StackTrace);
            }
            
        }

        private void CreateNewDB(string aName)
        {
            using (SqlConnection ServerConnection = new SqlConnection(string.Format(C_ConnStr_SQLServer, "master")))
            {
                string strCreateDB = "Create database {0}";
                SqlCommand serverCommand = new SqlCommand(string.Format(strCreateDB, aName), ServerConnection);
                ServerConnection.Open();
                serverCommand.ExecuteNonQuery();
            }
            using (SqlConnection ServerConnection = new SqlConnection(string.Format(C_ConnStr_SQLServer, aName)))
            {
                string strCreateProjectTable = string.Format(rcMigrate.CreaeteProjectTable, aName);
                SqlCommand serverCommand = new SqlCommand(strCreateProjectTable, ServerConnection);
                ServerConnection.Open();
                serverCommand.ExecuteNonQuery();
            }

        }

        public void InsertProjectSuite(ref string aID, string aDBName)
        {
            string SelectStr = string.Format(C_SelectAll, C_ProjectSuite);
            string InsertStr = string.Format(C_Insert_ProjectSuite, aDBName);
            try
            {
                FConnection.ConnectionString = string.Format(C_ConnStr_SQLServer, "AJMSDATA");
                FConnection.Open();
                SqlDataAdapter sda = new SqlDataAdapter(SelectStr, FConnection);
                DataSet ds = new DataSet();
                sda.Fill(ds, C_ProjectSuite);
                DataTable dt = ds.Tables[C_ProjectSuite];
                DataRow dr = dt.NewRow();
                dr[C_SuiteName] = aDBName;
                dt.Rows.Add(dr);
                sda.InsertCommand = new SqlCommand(InsertStr, FConnection);
                sda.Update(ds, C_ProjectSuite);
                ds.AcceptChanges();
                FCommand = new SqlCommand(string.Format(C_SelectMax, C_SuiteID, C_ProjectSuite), FConnection);
                object objID = FCommand.ExecuteScalar();
                aID = objID.ToString();
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

        public void InsertProject(ref string aID, string aDBName, string aProjectName)
        {
            string SelectStr = string.Format(C_SelectAll, C_Projects);           
            try
            {
                FConnection.ConnectionString = string.Format(C_ConnStr_SQLServer, aDBName);
                FConnection.Open();
                FCommand = new SqlCommand(string.Format(C_SelectMax, C_ProjectID, C_Projects), FConnection);
                object objID = FCommand.ExecuteScalar();
                if (objID != DBNull.Value && objID != null)
                {
                    aID = "" + (Convert.ToInt32(objID) + 1);
                }
                else
                {
                    aID = "0";
                }

                string InsertStr = string.Format(C_Insert_Projects, aDBName,aID, aProjectName);
                SqlDataAdapter sda = new SqlDataAdapter(SelectStr, FConnection);
                DataSet ds = new DataSet();
                sda.Fill(ds, C_Projects);
                DataTable dt = ds.Tables[C_Projects];
                DataRow dr = dt.NewRow();
                dr[C_ProjectName] = aDBName;
                dt.Rows.Add(dr);
                sda.InsertCommand = new SqlCommand(InsertStr, FConnection);
                sda.Update(ds, C_Projects);

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

        private void RunSelectIntoBatch(string aSourceDB, string aNewDB, string aProjectID)
        {
            using (SqlConnection ServerConnection = new SqlConnection(string.Format(C_ConnStr_SQLServer, "master")))
            {
                string strSelectInto = string.Format(rcMigrate.SelectIntoAllTable, aSourceDB, aNewDB, aProjectID);
                SqlCommand serverCommand = new SqlCommand(strSelectInto, ServerConnection);
                ServerConnection.Open();
                serverCommand.ExecuteNonQuery();
            }
        }

        private List<string> GetSourceTables(string aSourceDB, string aDestinationDB, string aProjectID)
        {
            List<string> Result = new List<string>();

            using (SqlConnection ServerConnection = new SqlConnection(string.Format(C_ConnStr_SQLServer, aSourceDB)))
            {
                string strGetTables = string.Format(rcMigrate.sql_GetAllTable, aSourceDB);
                SqlCommand serverCommand = new SqlCommand(strGetTables, ServerConnection);
                ServerConnection.Open();
                SqlDataReader reader = serverCommand.ExecuteReader();
                while (reader.Read())
                {
                    Result.Add(reader[0].ToString());
                }
                reader.Close();
                ServerConnection.Close();
            }

            return Result;
        }

        private List<string> GetExistTabls(string aSourceDB, string aDestinationDB, string aProjectID)
        {
            List<string> Result = new List<string>();

            using (SqlConnection ServerConnection = new SqlConnection(string.Format(C_ConnStr_SQLServer, aDestinationDB)))
            {
                string strGetTables = string.Format(rcMigrate.sql_GetAllTable, aDestinationDB);
                SqlCommand serverCommand = new SqlCommand(strGetTables, ServerConnection);
                ServerConnection.Open();
                SqlDataReader reader = serverCommand.ExecuteReader();
                while (reader.Read())
                {
                    Result.Add(reader[0].ToString());
                }
                reader.Close();
                ServerConnection.Close();
            }

            return Result;
        }


        private string GetColumnTypeSize(string aSourceDB, string aTableName, string aColumnName)
        {
            string Result = string.Empty;
            string colType = string.Empty;
            string colSize = string.Empty;
            using (SqlConnection ServerConnection = new SqlConnection(string.Format(C_ConnStr_SQLServer, aSourceDB)))
            {
                string strGetType = string.Format(rcMigrate.SelectNoResult, aSourceDB, aTableName);
                SqlCommand serverCommand = new SqlCommand(strGetType, ServerConnection);
                ServerConnection.Open();
                SqlDataReader reader = serverCommand.ExecuteReader();
                DataTable dt = reader.GetSchemaTable();
                if (dt != null && dt.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        if (dr[C_ColumnName].ToString().Equals(aColumnName))
                        {
                            colType = dr[C_DataTypeName].ToString();
                            colSize = dr[C_ColumnSize].ToString();
                            break;
                        }
                    }
                }
                reader.Close();
                ServerConnection.Close();
            }

            if (string.Empty != colSize && string.Empty != colType)
            {
                bool shouldAddSize = false;
                switch (colType)
                {
                    case "binary":
                    case "char":
                    case "datetime2":
                    case "nchar":
                    case "nvarchar":
                    case "time":
                    case "varbinary":
                    case "varchar":
                        shouldAddSize = true;
                        break;
                    default:
                        shouldAddSize = false;
                        break;
                }
                if (shouldAddSize)
                {
                    Result = string.Format("{0}({1})", colType, colSize);
                }
                else
                {
                    Result = colType;
                }
            }

            return Result;
        }

        private void RunInsertInto(string aSourceDB, string aDestinationDB, string aProjectID)
        {
            List<string> SourceTables = new List<string>();
            List<string> ExistTabls = new List<string>();

            SourceTables = GetSourceTables(aSourceDB, aDestinationDB, aProjectID);

            ExistTabls = GetExistTabls(aSourceDB, aDestinationDB, aProjectID);

            foreach (string tb in SourceTables)
            {
                if (ExistTabls.Contains(tb) == false)
                {                    
                    using (SqlConnection ServerConnection = new SqlConnection(string.Format(C_ConnStr_SQLServer, "master")))
                    {
                        string strSelectInto = string.Format(rcMigrate.sql_SelectInto, aDestinationDB, tb, aSourceDB, aProjectID);
                        SqlCommand serverCommand = new SqlCommand(strSelectInto, ServerConnection);
                        ServerConnection.Open();
                        serverCommand.ExecuteNonQuery();
                        ServerConnection.Close();
                    }
                }
                else
                {
                    List<string> SourceColumns = new List<string>();
                    List<string> CurrentColumns = new List<string>();
                    List<string> MergeColumns = new List<string>();
                    List<string> AddColumns = new List<string>();
                    List<string> IdentityColumns = new List<string>();


                    using (SqlConnection ServerConnection = new SqlConnection(string.Format(C_ConnStr_SQLServer, aSourceDB)))
                    {
                        string strGetColumns = string.Format(rcMigrate.sql_GetAllColumn, aSourceDB, tb);
                        SqlCommand serverCommand = new SqlCommand(strGetColumns, ServerConnection);
                        ServerConnection.Open();
                        SqlDataReader reader = serverCommand.ExecuteReader();
                        while (reader.Read())
                        {
                            SourceColumns.Add(reader[0].ToString());
                        }
                        reader.Close();
                        ServerConnection.Close();
                    }
                    using (SqlConnection ServerConnection = new SqlConnection(string.Format(C_ConnStr_SQLServer, aDestinationDB)))
                    {
                        string strGetColumns = string.Format(rcMigrate.sql_GetAllColumn, aDestinationDB, tb);
                        SqlCommand serverCommand = new SqlCommand(strGetColumns, ServerConnection);
                        ServerConnection.Open();
                        SqlDataReader reader = serverCommand.ExecuteReader();
                        while (reader.Read())
                        {
                            CurrentColumns.Add(reader[0].ToString());
                            if (reader[1].ToString().Trim().Equals("True"))
                            {
                                IdentityColumns.Add(reader[0].ToString());
                            }
                        }
                        reader.Close();
                        ServerConnection.Close();
                    }

                    foreach (string var in SourceColumns)
                    {
                        if (CurrentColumns.Contains(var))
                        {
                            MergeColumns.Add(var);
                        }
                        else
                        {
                            AddColumns.Add(var);
                        }
                    }

                    //addtional column
                    if (AddColumns.Count > 0)
                    {
                        StringBuilder sbColumns = new StringBuilder();
                        bool IsIdentityColumn = false;
                        int i = 0;

                        foreach (string colName in AddColumns)
                        {
                            string type = string.Empty;
                            type = GetColumnTypeSize(aSourceDB, tb, colName);

                            using (SqlConnection ServerConnection = new SqlConnection(string.Format(C_ConnStr_SQLServer, aDestinationDB)))
                            {
                                string strAddCol = string.Format(rcMigrate.sql_AddCol, aDestinationDB, tb, colName, type);
                                SqlCommand serverCommand = new SqlCommand(strAddCol, ServerConnection);
                                ServerConnection.Open();
                                serverCommand.ExecuteNonQuery();
                                ServerConnection.Close();
                            }                           

                        }                    

                    }

                    //merge columns
                    if (SourceColumns.Count > 0)
                    {
                        bool IsIdentityColumn = false;
                        StringBuilder sbColumns = new StringBuilder();
                        for (int i = 0; i < SourceColumns.Count; i++)
                        {
                            sbColumns.Append("[");
                            sbColumns.Append(SourceColumns[i]);
                            sbColumns.Append("]");
                            if (i != SourceColumns.Count - 1)
                            {
                                sbColumns.Append(",");
                            }

                            if (IdentityColumns.Contains(SourceColumns[i]))
                            {
                                IsIdentityColumn = true;
                            }
                        }
                        using (SqlConnection ServerConnection = new SqlConnection(string.Format(C_ConnStr_SQLServer, "master")))
                        {
                            ServerConnection.Open();
                            
                            string strInsertInto = string.Empty;
                            if (IsIdentityColumn)
                            {
                                strInsertInto = string.Format(rcMigrate.sql_InsertIntoWithIndentity, aDestinationDB, tb, sbColumns.ToString(), aProjectID, aSourceDB);
                            }
                            else
                            {
                                strInsertInto = string.Format(rcMigrate.sql_InsertInto, aDestinationDB, tb, sbColumns.ToString(), aProjectID, aSourceDB);
                            }

                            try
                            {
                                SqlCommand serverCommandInsert = new SqlCommand(strInsertInto, ServerConnection);
                                serverCommandInsert.ExecuteNonQuery();
                                ServerConnection.Close();
                            }
                            catch (Exception ex)
                            {
                                throw ex;
                            }
                            
                        }
                    }                   


                }
                
            }
        }

        private void btnCreateRelation_Click(object sender, EventArgs e)
        {
            try
            {
                DisplayMsg("Create Relationship......");
                Thread creatRelation = new Thread(new ThreadStart(CreateRelation));
                creatRelation.Start();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\r\n" + ex.StackTrace);
            }
          
        }

        private void CreateRelation()
        {
            try
            {
                CreateRelationStaticsTable();
                CreateRelationDataTable();
                this.Invoke(new delegate_msg(DisplayMsg), "SUCCESS");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\r\n" + ex.StackTrace);
            }
            
        }

        private void CreateRelationStaticsTable()
        {
            using (SqlConnection ServerConnection = new SqlConnection(string.Format(C_ConnStr_SQLServer, DestinationDB)))
            {
                string strCreateRelation = string.Format(rcMigrate.CreateRelation, DestinationDB);
                SqlCommand serverCommand = new SqlCommand(strCreateRelation, ServerConnection);
                ServerConnection.Open();
                serverCommand.ExecuteNonQuery();
                ServerConnection.Close();
            }
        }


        private void CreateRelationDataTable()
        {
            using (SqlConnection ServerConnection = new SqlConnection(string.Format(C_ConnStr_SQLServer, DestinationDB)))
            {
                string strCreateRelation = string.Format(rcMigrate.AddRelationDataTables, DestinationDB);
                SqlCommand serverCommand = new SqlCommand(strCreateRelation, ServerConnection);
                ServerConnection.Open();
                serverCommand.ExecuteNonQuery();
                ServerConnection.Close();
            }
        }

        private void btnRemoveUnused_Click(object sender, EventArgs e)
        {
             string[] StaticTables = new string[] { "Command", "WorkflowStep", "ToTest", "TestCase", "TestCaseName"};
             List<string> ValidateTables = new List<string>();
             
        }

        private void ValidateCommand(string aSourceDB)
        {
            List<string> validateContent = new List<string>();
            using (SqlConnection ServerConnection = new SqlConnection(string.Format(C_ConnStr_SQLServer, aSourceDB)))
            {
                string strSelect = "select distinct(DataTableID) from Command";
                SqlCommand serverCommand = new SqlCommand(strSelect, ServerConnection);
                ServerConnection.Open();
                SqlDataReader reader = serverCommand.ExecuteReader();
                while (reader.Read())
                {
                    validateContent.Add(reader[0].ToString());
                }
                ServerConnection.Close();
            }

            if (validateContent.Count > 0)
            {
                foreach (string var in validateContent)
                {
                    RemoveUnused(aSourceDB, "DataTable", string.Format("DataTableID = {0}", var), "Command");
                }
            }
        }

        private void ValidateWorkflowStep(string aSourceDB)
        {
            List<string> validateContent_Command = new List<string>();
            using (SqlConnection ServerConnection = new SqlConnection(string.Format(C_ConnStr_SQLServer, aSourceDB)))
            {
                string strSelect = "select distinct(CommandName) from WorkflowStep";
                SqlCommand serverCommand = new SqlCommand(strSelect, ServerConnection);
                ServerConnection.Open();
                SqlDataReader reader = serverCommand.ExecuteReader();
                while (reader.Read())
                {
                    validateContent_Command.Add(reader[0].ToString());
                }
                ServerConnection.Close();
            }

            if (validateContent_Command.Count > 0)
            {
                foreach (string var in validateContent_Command)
                {
                    RemoveUnused(aSourceDB, "Command", string.Format("CommandName = '{0}'", var), "WorkflowStep");
                }
            }


        }

        private void RemoveUnused(string aSourceDB, string aForeignTable, string aConditon, string aCurrentTable)
        {
            using (SqlConnection ServerConnection = new SqlConnection(string.Format(C_ConnStr_SQLServer, SourceDB)))
            {
                string strRemove = string.Format(rcMigrate.RemoveUnused, SourceDB, aForeignTable, aConditon, aCurrentTable);
                SqlCommand serverCommand = new SqlCommand(strRemove, ServerConnection);
                ServerConnection.Open();
                serverCommand.ExecuteNonQuery();
                ServerConnection.Close();
            }
        }



    }

}