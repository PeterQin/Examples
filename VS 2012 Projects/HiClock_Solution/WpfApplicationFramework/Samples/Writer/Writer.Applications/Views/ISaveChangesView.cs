﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Waf.Applications;

namespace Waf.Writer.Applications.Views
{
    public interface ISaveChangesView : IView
    {
        void ShowDialog(object owner);

        void Close();
    }
}
