﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Waf.Writer.Applications.Controllers;
using System.ComponentModel.Composition;
using Waf.Writer.Applications.Services;

namespace Waf.Writer.Applications.Test.Services
{
    [Export(typeof(IPresentationService))]
    public class MockPresentationService : IPresentationService
    {
        public bool InitializeCulturesCalled { get; set; }
        
        public double VirtualScreenWidth { get; set; }

        public double VirtualScreenHeight { get; set; }
        

        public void InitializeCultures()
        {
            InitializeCulturesCalled = true;
        }
    }
}
