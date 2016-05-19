using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace UpdateAssemblyInfo
{
    public class VersionHelper
    {
        private static readonly VersionHelper FInstance = new VersionHelper();

        public static VersionHelper Instance
        {
            get { return VersionHelper.FInstance; }
        }

        private VersionHelper() { }

        public Version GetNewVersion(string aVersionFile) 
        {
            if (File.Exists(aVersionFile) == false)
            {
                throw new ArgumentException("Could not found the version file: " + aVersionFile);
            }
            else
            {
               string versionString = File.ReadAllText(aVersionFile);
               Version oldVersion = new Version(versionString);
               Version newVersion = new Version(oldVersion.Major, oldVersion.Minor, oldVersion.Build, oldVersion.Revision + 1);
               return newVersion;
            }
        }

        public bool SaveVersionToFile(Version aVersion, string aFileName)
        {
            bool result = false;
            try
            {
                File.WriteAllText(aFileName, aVersion.ToString());
            }
            catch (Exception)
            {
                result = false;
            }
            return result;
        }

    }
}
