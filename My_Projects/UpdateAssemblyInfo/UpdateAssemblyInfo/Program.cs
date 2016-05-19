using System;
using System.Collections.Generic;
using System.Text;

namespace UpdateAssemblyInfo
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
                    Version newVersion = VersionHelper.Instance.GetNewVersion(args[0]);
                    AssemblyInfoHelper assemblyHelper = new AssemblyInfoHelper(newVersion, args[1]);
                    assemblyHelper.UpdateFiles();
                    VersionHelper.Instance.SaveVersionToFile(newVersion, args[0]);
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
