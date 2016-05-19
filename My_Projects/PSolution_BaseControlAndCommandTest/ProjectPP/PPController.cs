using System;
using System.Collections.Generic;
using System.Text;
using PSolution.Common;

namespace PSolution.ProjectPP
{
    public class PPController : BaseController
    {
        public override object ProcessUIRequest(object aCommand, object aMessage)
        {
            throw new Exception(this.GetType()+"\r\n"+"Command: "+aCommand.ToString()+"\r\n"+"Message: "+ aMessage.ToString());            
        }
    }
}
