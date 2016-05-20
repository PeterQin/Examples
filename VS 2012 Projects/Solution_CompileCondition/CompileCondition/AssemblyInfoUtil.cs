using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace CompileCondition
{
    public class AssemblyInfoUtil
    {
        private static readonly AssemblyInfoUtil FInstance = new AssemblyInfoUtil();

        public static AssemblyInfoUtil Instance
        {
            get { return AssemblyInfoUtil.FInstance; }
        }

        private AssemblyInfoUtil() { }

        public void UpdateCSharpVersionInfo(string aFileName, string aVersion)
        {
            StreamReader reader = new StreamReader(aFileName);
            StreamWriter writer = new StreamWriter(aFileName + ".out");
            try
            {
                string line;
                string newline;

                while ((line = reader.ReadLine()) != null)
                {
                    newline = ProcessLine(line, aVersion);
                    writer.WriteLine(newline);
                }                
            }
            finally
            {
                reader.Close();
                writer.Close();

            }            

            File.Delete(aFileName);
            File.Move(aFileName + ".out", aFileName);
        }

        private string ProcessLine(string line, string aVersion)
        {
            line = ProcessLinePart(line, "[assembly: AssemblyVersion(\"", aVersion);
            line = ProcessLinePart(line, "[assembly: AssemblyFileVersion(\"", aVersion);
            return line;
        }

        private string ProcessLinePart(string line, string part, string aVersion)
        {
            string result = line;
            if (line.StartsWith(part))
            {
                result = part + aVersion + "\")]";
            }
            return result;
        }
    }
}
