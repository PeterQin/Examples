using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace TestSQLParameter
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {               
                this.ReadOrderData();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ReadOrderData()
        {
            label3.Text = string.Empty;
            textBox1.Text = string.Empty;
            string connectionString = @"Data Source=ZHUVMSTDSQL2008R2;Initial Catalog=sqlexp;User Id=sqlexp;Password=sqlexp;";
            string queryString = richTextBox1.Text;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(queryString, connection);
                command.CommandTimeout = 0;

                SqlParameter parameter1 = new SqlParameter();
                parameter1.ParameterName = "@a";
                object objPara = new object();
                objPara = textBox2.Text;
                parameter1.Value = objPara;
                parameter1.SqlDbType = SqlDbType.NVarChar;



                SqlParameter parameter2 = new SqlParameter();
                parameter2.ParameterName = "@b";
                object objPara2 = new object();
                objPara2 = textBox2.Text;
                parameter2.Value = objPara;
                parameter2.SqlDbType = SqlDbType.NVarChar;

                List<SqlParameter> sqlPara = new List<SqlParameter>();

                sqlPara.Add(parameter1);
                sqlPara.Add(parameter2);


                command.Parameters.AddRange(sqlPara.ToArray());

                //command.ExecuteNonQuery();

                SqlDataReader reader = command.ExecuteReader();
                try
                {
                    while (reader.Read())
                    {
                        textBox1.Text = reader[0].ToString();
                        break;
                    }
                }
                finally
                {
                    // Always call Close when done reading.
                    reader.Close();
                }
                label3.Text = "Done !";
            }

        }

        private void test(params SqlParameter[] p)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = string.Empty;
            label3.Text = string.Empty;
        }

    }
}