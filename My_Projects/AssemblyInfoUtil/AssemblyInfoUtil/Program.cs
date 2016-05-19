using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using UpdateAssemblyInfo;

namespace AssemblyInfoUtil
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                if (args.Length >= 3 && args[2].ToLower().Equals("log"))
                {
                    Log.Instance.LogToFile = true;
                }
                if (args.Length > 1)
                {
                    Log.Instance.Output("AssemblyInfoUtil argument list:");
                    Log.Instance.Output("Arg 1(Version) - " + args[0]);
                    Log.Instance.Output("Arg 2(Source Folder) - " + args[1]);
                    if (Log.Instance.LogToFile)
                    {
                        Log.Instance.Output("Arg 3(Log): will write output message to " + Log.Instance.LogFileName);
                    }
                    Version newVersion = new Version(args[0]);//VersionHelper.Instance.GetNewVersion(args[0]);
                    AssemblyInfoHelper assemblyHelper = new AssemblyInfoHelper(newVersion, args[1]);
                    assemblyHelper.UpdateFiles();
                }
            }
            catch (Exception ex)
            {
                Log.Instance.Output(ex.Message);
            }
            finally
            {
                Log.Instance.Save();
            }

        }
    }
}
