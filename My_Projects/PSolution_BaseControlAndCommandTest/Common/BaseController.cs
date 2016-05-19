using System;
using System.Collections.Generic;
using System.Text;

namespace PSolution.Common
{
    public delegate object TExecuteInController(object aObject, object bObject);
    public abstract class BaseController
    {
        public abstract object ProcessUIRequest(object aCommand, object aMessage);
    }
}
