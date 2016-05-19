using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AJMS
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                PreTaskAndPostProcess taskProc = new PreTaskAndPostProcess();
                taskProc.Start();
                Console.Read();
            }
            catch (Exception ex)
            {
                Output.WriteLine(ex.Message + "\r\n" + ex.StackTrace);
                Console.Read();
            }
            
        }
       
    }

   
}
