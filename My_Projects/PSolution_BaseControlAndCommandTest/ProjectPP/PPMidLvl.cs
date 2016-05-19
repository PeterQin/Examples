using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using PSolution.Common;

namespace PSolution.ProjectPP
{
    public partial class PPMidLvl : CommonMidLvl<ucPPBase, PPControl, Command, UIToUI>
    {
        public PPMidLvl()
        {
            InitializeComponent();
        }
    }
}
