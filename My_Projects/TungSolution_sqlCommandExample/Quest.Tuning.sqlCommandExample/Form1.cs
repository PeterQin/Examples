using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Quest.Tuning.sqlCommandExample
{
    public partial class frmDatabaseBrowser : Form
    {
        public frmDatabaseBrowser()
        {
            InitializeComponent();
        }

        private void btnBrowser_Click(object sender, EventArgs e)
        {
            try
            {
                string connectionString = @"Data Source=ZHUVMSTDSQL2008R2;Initial Catalog=sqlexp;User Id=sqlexp;Password=sqlexp;";
                this.ReadOrderData(connectionString);
            }
            catch (Exception ex)
            {

                rchDataWindow.Text = ex.Message;
            }
        }
        private void ReadOrderData(string connectionString)
        {
            string queryString = "select * from grade where grd_desc = 'Defective'";
            object temp1 = new object();
            temp1 = "Defective";
            object temp2 = new object();
            temp2 = "11-12-12";
            
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(queryString, connection);
                command.CommandTimeout = 0;
                SqlParameter parameter1 = new SqlParameter();
                parameter1.ParameterName = "@a";
                parameter1.Value = temp1;
                parameter1.SqlDbType = SqlDbType.NVarChar;
                
                command.Parameters.Add(parameter1);

                //SqlParameter parameter2 = new SqlParameter();
                //parameter2.ParameterName = "@B";
                //string tt = "12";
             
                //parameter2.Value = Convert.FromBase64String("11-12-12");
                //parameter2.SqlDbType = SqlDbType.Timestamp;

                //command.Parameters.Add(parameter1);

                SqlDataReader reader = command.ExecuteReader();
                try
                {
                    while (reader.Read())
                    {
                        rchDataWindow.Text += reader[0] + "    " + reader[1] + "    " + reader[2] + "\r\n";
                    }
                }
                finally
                {
                    // Always call Close when done reading.
                    reader.Close();
                }
            }

        }

        private void RenameDataBase(string connectionString)
        {

            string queryString = "select * from ptest where 1 = 2";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(queryString, connection);


                SqlDataReader reader = command.ExecuteReader();
                DataTable dt = reader.GetSchemaTable();
                if (dt != null && dt.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        if (dr["ColumnName"].ToString().Equals("data"))
                        {
                            string a = dr["DataTypeName"].ToString();
                            string b = dr["ColumnSize"].ToString();
                        }
                    }
                }
                gridControl1.DataSource = dt;

                try
                {
                    //while (reader.Read())
                    //{
                    //    rchDataWindow.Text += reader[0] + "    " + reader["JobName"] + "    " + reader["TestingResult"] + "\r\n";
                    //}
                }
                finally
                {
                    // Always call Close when done reading.
                    reader.Close();
                }
                
            }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            try
            {
                string connectionString = @"Data Source=ZHUVMSTDSQL2008R2; Initial Catalog=AJMSDATA;Persist Security Info=false;User ID=sqlexp;Password=sqlexp;";
                this.RenameDataBase(connectionString);
            }
            catch (Exception ex)
            {

                rchDataWindow.Text = ex.Message;
            }
        }

        private void frmDatabaseBrowser_Load(object sender, EventArgs e)
        {

        }

    }
}