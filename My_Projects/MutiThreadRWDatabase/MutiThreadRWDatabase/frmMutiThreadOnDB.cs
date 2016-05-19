using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using MutiThreadRWDatabase.dtsPTestTableAdapters;
using System.Data.SqlClient;

namespace MutiThreadRWDatabase
{
    /// <summary>
    /// Testing Mutiple thread action on DB
    /// We must add a Lock to avoid execption when Mutiple Action on DB
    /// If Mutiple action have Add, Delete, Update or two of them we need Lock
    /// </summary>
    public partial class frmMutiThreadOnDB : Form
    {
        private dtsPTest PtestDataSet = new dtsPTest();
        private Thread threadRead = null;
        private Thread threadWriteAndDel = null;
        private Thread threadUpdate = null;
        private Thread threadDel = null;
        private Thread threadWrite = null;
        //private static object objActionOnDB = new object();
        private int lastid = 10000;
        private int lastdelID = 200;
        private delegate void delegate_ActionOnDB();

        public frmMutiThreadOnDB()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            using (ptestTableAdapter ptestAD = new ptestTableAdapter())
            {
                ptestAD.Fill(PtestDataSet.ptest);
            }
        }

        private void btnWrite_Click(object sender, EventArgs e)
        {
            WriteRow();
        }

        private void WriteRow()
        {
            try
            {
                using (ptestTableAdapter ptestAD = new ptestTableAdapter())
                {
                    ptestAD.Connection.Open();
                    try
                    {
                        SqlTransaction transaction = ptestAD.Connection.BeginTransaction("w");
                        dtsPTest.ptestRow row = PtestDataSet.ptest.NewptestRow();
                        if (row != null)
                        {
                            row.ID = lastid;
                            lastid++;
                            row.data = "data100";
                            PtestDataSet.ptest.AddptestRow(row);

                            try
                            {
                                ptestAD.Update(PtestDataSet.ptest);
                                transaction.Commit();
                                PtestDataSet.ptest.AcceptChanges();
                            }
                            catch (Exception)
                            {
                                transaction.Rollback("w");
                            }
                            

                        }
                    }
                    finally
                    {
                        ptestAD.Connection.Close();
                    }
                    
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }       

        private void btnRead_Click(object sender, EventArgs e)
        {
            Read();
        }

        private void Read()
        {
            try
            {
                string condition = "id = 105";//+ textBox3.Text;    //always read 105
                richTextBox1.Text = string.Empty;
                int id = Convert.ToInt32(textBox3.Text);
                //dtsPTest.ptestRow row = PtestDataSet.ptest.FindByID(id);

                DataRow[] rows = PtestDataSet.ptest.Select(condition);  //test select function
                dtsPTest.ptestRow row = null;
                if (rows.Length > 0)
                {
                    row = rows[0] as dtsPTest.ptestRow;
                }
                if (row != null)
                {

                    richTextBox1.Text += row.ID.ToString();
                    richTextBox1.Text += "\t";
                    richTextBox1.Text += row.data;
                    richTextBox1.Text += "\t";
                    richTextBox1.Text += PtestDataSet.ptest.Rows.Count.ToString();  //display total row count
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            DelRow();
        }

        private void DelRow()
        {
            try
            {
                int id = lastdelID;
                lastdelID++;
                dtsPTest.ptestRow row = null;
             
                using (ptestTableAdapter ptestAD = new ptestTableAdapter())
                {
                    ptestAD.Connection.Open();
                    try
                    {
                        SqlTransaction transaction = ptestAD.Connection.BeginTransaction("d");
                        row = PtestDataSet.ptest.FindByID(id);

                        if (row != null)
                        {
                            row.Delete();

                            try
                            {
                                ptestAD.Update(PtestDataSet.ptest);
                                transaction.Commit();
                                PtestDataSet.ptest.AcceptChanges();
                            }
                            catch (Exception)
                            {
                                transaction.Rollback("d");
                            }
                            

                        }
                    }
                    finally
                    {
                        ptestAD.Connection.Close();
                    }
                }
                

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void update()
        {
            try
            {
                //int id = Convert.ToInt32(textBox3.Text);
                int id = 105;   //always update 105
                using (ptestTableAdapter ptestAD = new ptestTableAdapter())
                {
                    ptestAD.Connection.Open();
                    try
                    {
                        SqlTransaction transaction = ptestAD.Connection.BeginTransaction("u");
                        dtsPTest.ptestRow row = PtestDataSet.ptest.FindByID(id);

                        if (row != null)
                        {
                            if (row.data == textBox1.Text)
                            {
                                row.data = "data";
                            }
                            else
                            {
                                row.data = textBox1.Text;
                            }

                            try
                            {
                                ptestAD.Update(PtestDataSet.ptest);
                                transaction.Commit();
                                PtestDataSet.ptest.AcceptChanges();
                            }
                            catch (Exception)
                            {
                                transaction.Rollback("u");
                            }
                            

                        }
                    }
                    finally
                    {
                        ptestAD.Connection.Close();
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void btnWDThread_Click(object sender, EventArgs e)
        {
            threadWriteAndDel = new Thread(new ThreadStart(WriteAndDel));
            threadWriteAndDel.Start();
        }

        private void btnStopWD_Click(object sender, EventArgs e)
        {
            if (threadWriteAndDel != null && threadWriteAndDel.ThreadState == ThreadState.Running)
            {
                threadWriteAndDel.Abort();
            }
        }

        private void WriteAndDel()
        {
            do
            {
                WriteRow();
                Thread.Sleep(1000);
                DelRow();
                Thread.Sleep(1000);
            } while (true);
        }

        private void btnReadThread_Click(object sender, EventArgs e)
        {
            threadRead = new Thread(new ThreadStart(ReadThread));
            threadRead.Start();
        }

        private void ReadThread()
        {
            do
            {
                this.Invoke(new delegate_ActionOnDB(Read));
                Thread.Sleep(1000);
            } while (true);
        }        

        private void btnStopRead_Click(object sender, EventArgs e)
        {
            if (threadRead != null && threadRead.ThreadState == ThreadState.Running)
            {
                threadRead.Abort();
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            update();
        }    

        private void btnUpdateThread_Click(object sender, EventArgs e)
        {
            threadUpdate = new Thread(new ThreadStart(updateThread));
            threadUpdate.Start();
        }

        private void updateThread()
        {
            do
            {
                this.BeginInvoke(new delegate_ActionOnDB(update));
                Thread.Sleep(90);
            } while (true);
        }

      

        private void btnStopUpdate_Click(object sender, EventArgs e)
        {
            if (threadUpdate != null && threadUpdate.ThreadState == ThreadState.Running)
            {
                threadUpdate.Abort();
            }
        }

        private void btnWriteThread_Click(object sender, EventArgs e)
        {
            threadWrite = new Thread(new ThreadStart(WriteThread));
            threadWrite.Start();
        }

        private void btnStopWrite_Click(object sender, EventArgs e)
        {
            if (threadWrite != null && threadWrite.ThreadState == ThreadState.Running)
            {
                threadWrite.Abort();
            }
        }

        private void WriteThread()
        {
            do
            {
                WriteRow();
                Thread.Sleep(100);
            } while (true);
        }

        private void btnDelThread_Click(object sender, EventArgs e)
        {
            threadDel = new Thread(new ThreadStart(DelThread));
            threadDel.Start();
        }

        private void btnStopDel_Click(object sender, EventArgs e)
        {
            if (threadDel != null && threadDel.ThreadState == ThreadState.Running)
            {
                threadDel.Abort();
            }
        }

        private void DelThread()
        {
            do
            {
                DelRow();
                Thread.Sleep(170);
            } while (true);
        }

    }
}


/* ///////// old  coding  ////////////////////////
 * 
 * using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using MutiThreadRWDatabase.dtsPTestTableAdapters;

namespace MutiThreadRWDatabase
{
    /// <summary>
    /// Testing Mutiple thread action on DB
    /// We must add a Lock to avoid execption when Mutiple Action on DB
    /// If Mutiple action have Add, Delete, Update or two of them we need Lock
    /// </summary>
    public partial class frmMutiThreadOnDB : Form
    {
        private dtsPTest PtestDataSet = new dtsPTest();
        private Thread threadRead = null;
        private Thread threadWriteAndDel = null;
        private Thread threadUpdate = null;
        private Thread threadDel = null;
        private Thread threadWrite = null;
        private static object objActionOnDB = new object();
        private int lastid = 10000;
        private int lastdelID = 200;
        private delegate void delegate_ActionOnDB();

        public frmMutiThreadOnDB()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            using (ptestTableAdapter ptestAD = new ptestTableAdapter())
            {
                ptestAD.Fill(PtestDataSet.ptest);
            }
        }

        private void btnWrite_Click(object sender, EventArgs e)
        {
            WriteRow();
        }

        private void WriteRow()
        {
            try
            {
                lock (objActionOnDB)
                {
                    dtsPTest.ptestRow row = PtestDataSet.ptest.NewptestRow();
                    if (row != null)
                    {
                        row.ID = lastid;
                        lastid++;
                        row.data = "data100";
                        PtestDataSet.ptest.AddptestRow(row);

                        using (ptestTableAdapter ptestAD = new ptestTableAdapter())
                        {
                            ptestAD.Update(PtestDataSet.ptest);
                            PtestDataSet.ptest.AcceptChanges();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }       

        private void btnRead_Click(object sender, EventArgs e)
        {
            Read();
        }

        private void Read()
        {
            try
            {
                string condition = "id = 105";//+ textBox3.Text;    //always read 105
                richTextBox1.Text = string.Empty;
                int id = Convert.ToInt32(textBox3.Text);
                //dtsPTest.ptestRow row = PtestDataSet.ptest.FindByID(id);

                DataRow[] rows = PtestDataSet.ptest.Select(condition);  //test select function
                dtsPTest.ptestRow row = null;
                if (rows.Length > 0)
                {
                    row = rows[0] as dtsPTest.ptestRow;
                }
                if (row != null)
                {

                    richTextBox1.Text += row.ID.ToString();
                    richTextBox1.Text += "\t";
                    richTextBox1.Text += row.data;
                    richTextBox1.Text += "\t";
                    richTextBox1.Text += PtestDataSet.ptest.Rows.Count.ToString();  //display total row count
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            DelRow();
        }

        private void DelRow()
        {
            try
            {
                int id = lastdelID;
                lastdelID++;
                dtsPTest.ptestRow row = null;
                lock (objActionOnDB)
                {
                    row = PtestDataSet.ptest.FindByID(id);

                    if (row != null)
                    {
                        row.Delete();

                        using (ptestTableAdapter ptestAD = new ptestTableAdapter())
                        {
                            ptestAD.Update(PtestDataSet.ptest);
                            PtestDataSet.ptest.AcceptChanges();
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void btnWDThread_Click(object sender, EventArgs e)
        {
            threadWriteAndDel = new Thread(new ThreadStart(WriteAndDel));
            threadWriteAndDel.Start();
        }

        private void btnStopWD_Click(object sender, EventArgs e)
        {
            if (threadWriteAndDel != null && threadWriteAndDel.ThreadState == ThreadState.Running)
            {
                threadWriteAndDel.Abort();
            }
        }

        private void WriteAndDel()
        {
            do
            {
                WriteRow();
                Thread.Sleep(1000);
                DelRow();
                Thread.Sleep(1000);
            } while (true);
        }

        private void btnReadThread_Click(object sender, EventArgs e)
        {
            threadRead = new Thread(new ThreadStart(ReadThread));
            threadRead.Start();
        }

        private void ReadThread()
        {
            do
            {
                this.Invoke(new delegate_ActionOnDB(Read));
                Thread.Sleep(1000);
            } while (true);
        }        

        private void btnStopRead_Click(object sender, EventArgs e)
        {
            if (threadRead != null && threadRead.ThreadState == ThreadState.Running)
            {
                threadRead.Abort();
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            update();
        }    

        private void btnUpdateThread_Click(object sender, EventArgs e)
        {
            threadUpdate = new Thread(new ThreadStart(updateThread));
            threadUpdate.Start();
        }

        private void updateThread()
        {
            do
            {
                this.BeginInvoke(new delegate_ActionOnDB(update));
                Thread.Sleep(90);
            } while (true);
        }

        private void update()
        {
            try
            {
                //int id = Convert.ToInt32(textBox3.Text);
                int id = 105;   //always update 105
                lock (objActionOnDB)
                {
                    dtsPTest.ptestRow row = PtestDataSet.ptest.FindByID(id);

                    if (row != null)
                    {
                        if (row.data == textBox1.Text)
                        {
                            row.data = "data";
                        }
                        else
                        {
                            row.data = textBox1.Text;
                        }
                        using (ptestTableAdapter ptestAD = new ptestTableAdapter())
                        {
                            ptestAD.Update(PtestDataSet.ptest);
                            PtestDataSet.ptest.AcceptChanges();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void btnStopUpdate_Click(object sender, EventArgs e)
        {
            if (threadUpdate != null && threadUpdate.ThreadState == ThreadState.Running)
            {
                threadUpdate.Abort();
            }
        }

        private void btnWriteThread_Click(object sender, EventArgs e)
        {
            threadWrite = new Thread(new ThreadStart(WriteThread));
            threadWrite.Start();
        }

        private void btnStopWrite_Click(object sender, EventArgs e)
        {
            if (threadWrite != null && threadWrite.ThreadState == ThreadState.Running)
            {
                threadWrite.Abort();
            }
        }

        private void WriteThread()
        {
            do
            {
                WriteRow();
                Thread.Sleep(100);
            } while (true);
        }

        private void btnDelThread_Click(object sender, EventArgs e)
        {
            threadDel = new Thread(new ThreadStart(DelThread));
            threadDel.Start();
        }

        private void btnStopDel_Click(object sender, EventArgs e)
        {
            if (threadDel != null && threadDel.ThreadState == ThreadState.Running)
            {
                threadDel.Abort();
            }
        }

        private void DelThread()
        {
            do
            {
                DelRow();
                Thread.Sleep(170);
            } while (true);
        }

    }
}

*/