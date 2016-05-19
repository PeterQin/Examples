using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace UpdateAssemblyInfo
{
    public class AssemblyInfoHelper
    {
        private readonly Version FVersion;
        private readonly string FSolutionFolder;
        private readonly List<TAssemblyInfo> AssemblyInfoSource;

        public AssemblyInfoHelper(Version aVersion, string aSolutionFolder)
        {
            FVersion = aVersion;
            FSolutionFolder = aSolutionFolder;
            AssemblyInfoSource = new List<TAssemblyInfo>();

            TAssemblyInfo assembly;

            assembly = new TAssemblyInfo();
            assembly.InfoName = "AssemblyVersion";
            assembly.InfoValue = FVersion.ToString();
            AssemblyInfoSource.Add(assembly);

            assembly = new TAssemblyInfo();
            assembly.InfoName = "AssemblyFileVersion";
            assembly.InfoValue = FVersion.ToString();
            AssemblyInfoSource.Add(assembly);
        }

        public void UpdateFiles()
        {
            string[] FileArray = Directory.GetFiles(FSolutionFolder, "AssemblyInfo.cs", SearchOption.AllDirectories);
            if (FileArray.Length > 0)
            {
                int index = 1;
                foreach (string file in FileArray)
                {
                    Output("Processing " + index + "/" + FileArray.Length + " :" + file);
                    ProcessFile(file);
                    index++;
                }
            }
        }

        private void ProcessFile(string aFile)
        {            
            StringBuilder sb = new StringBuilder();
            StreamReader reader = new StreamReader(aFile);
            try
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    sb.Append(ProcessLine(line));
                    sb.Append(Environment.NewLine);
                }
            }
            finally
            {
                reader.Close();
            }
            File.WriteAllText(aFile, sb.ToString(), Encoding.Unicode);
        }

        private string ProcessLine(string aLine)
        {
            string result = aLine;
            foreach (TAssemblyInfo item in AssemblyInfoSource)
            {
                int start = aLine.IndexOf(item.IdentyString);
                if (start >= 0)
                {
                    int end = aLine.IndexOf(AssemblyString.C_Identify_End, start);
                    string original = aLine.Substring(start, end + AssemblyString.C_Identify_End.Length - start);
                    result = aLine.Replace(original, item.DisplayInfo);
                    break;
                }
            }
            return result;
        }

        private void Output(string aMsg)
        {
            Log.Instance.Output(aMsg);
        }
    }
}
