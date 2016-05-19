using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WindowsApplication3
{
    public partial class Form1 : Form
    {
        Data FData;
        public Form1()
        {
            InitializeComponent();
            FData = new Data();
            FData[0] = "d";
            this.DataBindings.Add("Text", FData, "Text");
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            FData.Text = textEdit1.Text;
            
        }
    }

    public class Data : INotifyPropertyChanged
    {

        private string FText;

        public string Text
        {
            get { return FText; }
            set 
            { 
                FText = value;
                RaisePropertyChanged("Text");
            }
        }

        public string Text2;

        private List<string> FList;

        public string this[int index]
        {
            get { return FList[index]; }
            set { FList[index] = value; }
        }



        #region INotifyPropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged;

        public void RaisePropertyChanged(string aPropName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(aPropName));
            }
        }

        #endregion
    }
}