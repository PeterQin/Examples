using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace DatabaseManage
{
    public partial class frmDatabaseManage : Form
    {
        #region Field
        private string FConnectionStr;
        private SqlConnection FConnection;
        private SqlCommand FCommand;
        #region Const / Enum / Delegate / Event
        #endregion Const / Enum / Delegate / Event

        #region Property
        #endregion Property

        #endregion Field

        #region Constructor & Destroyer

        public frmDatabaseManage()
        {
            InitializeComponent();
            Init();
        }

        #endregion Constructor & Destroyer

        #region Private Section

        private void Init()
        {
            FConnectionStr = "server = 10.30.150.21,6848;uid = sqlexp; pwd = sqlexp; database = sqlexp";
            FConnection = new SqlConnection(FConnectionStr);
            FCommand = new SqlCommand();
            FCommand.Connection = FConnection;
        }

        private void QueryA(string aID)
        {
            string ID = aID;
            string SelectStr;
            if (string.IsNullOrEmpty(ID))
            {
             SelectStr = "select * from ptest";
            }
            else
            {
             SelectStr = "select * from ptest where id =" + ID;
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
                    SqlDataReader sdr = FCommand.ExecuteReader();
                    listBox1.Items.Clear();
                    while (sdr.Read())
                    {
                        listBox1.Items.Add(sdr["id"].ToString() + "   " + sdr["data"].ToString()); 
                    }
                    sdr.Close();
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

        }

        private void QueryB()
        {
            string ID = textBox1.Text.Trim();
            string SelectStr;
            if (string.IsNullOrEmpty(ID))
            {
                SelectStr = "select * from ptest";
            }
            else
            {
                SelectStr = "select * from ptest where id =" + ID;
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
                    sda.Fill(ds, "ptest");
                    DataTable dt = ds.Tables["ptest"];
                    listBox1.Items.Clear();
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                         listBox1.Items.Add(dt.Rows[i]["id"].ToString() + "   " + dt.Rows[i]["data"].ToString()); 
                    }                                       
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
        }

        private void InsertA()
        {
            string ID = textBox1.Text;
            string Data = textBox2.Text;
            if (string.IsNullOrEmpty(ID) || string.IsNullOrEmpty(Data))
            {
                MessageBox.Show("ID or Data could not be empty");
            }
            else
            {
                string InsertStr = "insert into ptest values (" + ID + ", \'" + Data + "\');";
                try
                {
                    FCommand.CommandText = InsertStr;
                    FConnection.Open();
                    FCommand.ExecuteNonQuery();
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

        private void InsertB()
        {
            string ID = textBox1.Text;
            string Data = textBox2.Text;
            if (string.IsNullOrEmpty(ID) || string.IsNullOrEmpty(Data))
            {
                MessageBox.Show("ID or Data could not be empty");
            }
            else
            {
                string SelectStr = "select * from ptest";
                string InsertStr = "insert into ptest values (" + ID + ", \'" + Data + "\');";
                try
                {
                    FConnection.Open();
                    SqlDataAdapter sda = new SqlDataAdapter(SelectStr, FConnection);
                    DataSet ds = new DataSet();
                    sda.Fill(ds, "ptest");
                    DataTable dt = ds.Tables["ptest"];
                    DataRow dr = dt.NewRow();
                    dr["id"] = ID;
                    dr["data"] = Data;
                    dt.Rows.Add(dr);
                    sda.InsertCommand = new SqlCommand(InsertStr,FConnection);
                    sda.Update(ds, "ptest");

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

        private void UpateA()
        {
            string ID = textBox1.Text;
            string Data = textBox2.Text;
            if (string.IsNullOrEmpty(ID) || string.IsNullOrEmpty(Data))
            {
                MessageBox.Show("ID or Data could not be empty");
            }
            else
            {
                string UpdateStr = "update ptest set data = \'"+Data+"\' where id = "+ID;
                FCommand.CommandText = UpdateStr;
                try
                {
                    FConnection.Open();
                    FCommand.ExecuteNonQuery();
                }
                finally
                {
                    FConnection.Close();
                }
            }
        }

        private void UpdateB()
        {
            string ID = textBox1.Text;
            string Data = textBox2.Text;
            if (string.IsNullOrEmpty(ID) || string.IsNullOrEmpty(Data))
            {
                MessageBox.Show("ID or Data could not be empty");
            }
            else
            {
                string UpdateStr = "update ptest set data = \'" + Data + "\' where id = " + ID;
                string SelectStr = "select * from ptest where id =" + ID;
                SqlDataAdapter sda = new SqlDataAdapter(SelectStr, FConnection);
                DataSet ds = new DataSet();
                sda.Fill(ds, "ptest");
                DataTable dt = ds.Tables["ptest"];
                dt.Rows[0]["data"] = Data;
                sda.UpdateCommand = new SqlCommand(UpdateStr, FConnection);
                sda.Update(ds, "ptest");
            }
        }

        private void DeleteA()
        {
            string ID = textBox1.Text;
            if (string.IsNullOrEmpty(ID))
            {
                MessageBox.Show("ID could not be empty");
            }
            else
            {
                string SelectStr = "select * from ptest where id =" + ID;
                string DeleteStr = "delete from ptest where id = "+ID;
                FCommand.CommandText = SelectStr;
                try
                {
                    FConnection.Open();
                    if (FCommand.ExecuteScalar() == null)
                    {
                        MessageBox.Show("Doesn't exist");
                    }
                    else
                    {
                        FCommand.CommandText = DeleteStr;
                        FCommand.ExecuteNonQuery();
                    }
                }
                finally
                {
                    FConnection.Close();
                }
            }
        }

        private void DeleteB()
        {
            string ID = textBox1.Text;
            if (string.IsNullOrEmpty(ID))
            {
                MessageBox.Show("ID could not be empty");
            }
            else
            {
                string SelectStr = "select * from ptest where id =" + ID;
                string DeleteStr = "delete from ptest where id = " + ID;
                SqlDataAdapter sda = new SqlDataAdapter(SelectStr, FConnection);
                DataSet ds = new DataSet();
                sda.Fill(ds, "ptest");
                DataTable dt = ds.Tables["ptest"];
                if (dt.Rows.Count > 0)
                {
                    dt.Rows[0].Delete();
                    sda.DeleteCommand = new SqlCommand(DeleteStr, FConnection);
                    sda.Update(ds,"ptest");
                }
                else
                {
                    MessageBox.Show("Doesn't exist");
                }
            }
        }

        #endregion Private Section

        #region Event

        private void button1_Click(object sender, EventArgs e)
        {
            QueryA(textBox1.Text.Trim());
        }

        private void button2_Click(object sender, EventArgs e)
        {
            QueryB();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            InsertA();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            InsertB();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            UpateA();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            UpdateB();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            DeleteA();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            DeleteB();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            QueryA(string.Empty);
        }

        private void button10_Click(object sender, EventArgs e)
        {
            string IDstr = "select @@IDENTITY";
            try
            {
                FConnection.Open();
                FCommand.CommandText = IDstr;
                object d;
                if ((d = FCommand.ExecuteScalar()) != null)
                {
                    textBox2.Text = d.ToString();
                }
            }
            finally
            {
                FConnection.Close();
            }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
        }

        #endregion Event      

       

       
    }
}