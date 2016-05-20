using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace WPFDispatcher
{
    public partial class ucWin : UserControl
    {
        public ucWin()
        {
            InitializeComponent();
        }
        public BindingList<TData> source = new BindingList<TData>();
        private void button1_Click(object sender, EventArgs e)
        {
            listBox1.DataSource = source;
            listBox1.DisplayMember = "Data";
            TDispatherDoEvent = new delegate_void(DispatcherHelper.DoEvents);
            Thread addThread = new Thread(new ThreadStart(AddItemProc));
            addThread.Start();
        }

        delegate void delegate_void();
        delegate_void TDispatherDoEvent;
        void AddItemProc()
        {
            this.BeginInvoke(new delegate_void(AddNow));
        }

        void AddNow()
        {
            for (int i = 0; i < 10000000; i++)
            {
                source.Add(new TData(i));
                TDispatherDoEvent();
                //Application.DoEvents();
            }
        }        
    }
}
