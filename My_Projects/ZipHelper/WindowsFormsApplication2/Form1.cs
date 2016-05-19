using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ICSharpCode.SharpZipLib.Zip;
using System.IO;
using ICSharpCode.SharpZipLib.Checksums;

namespace WindowsFormsApplication2
{
    public partial class Form1 : Form
    {


        string zipFileName = @"D:\New1.zip";
        string fileNeedZip = @"D:\New1\1.doc";
        string folderNeedZip1 = @"D:\New1\vm1\case2";
        string folderNeedZip2 = @"D:\New1\vm2";
        string rootDictionary = @"D:\New1\";

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ZipTest2();
        }



      


        private void ZipTest2()
        {
            List<string> PathWantZipList = new List<string>();
            PathWantZipList.Add(fileNeedZip);
            PathWantZipList.Add(folderNeedZip1);
            PathWantZipList.Add(folderNeedZip2);
            // Zip up the files - From SharpZipLib Demo Code
            using (ZipOutputStream s = new ZipOutputStream(File.Create(zipFileName)))
            {
                s.SetLevel(9); // 0-9, 9 being the highest compression
                try
                {

                    foreach (string path in PathWantZipList)
                    {
                        ZipFiles(s, path, rootDictionary);
                    }
                }
                finally
                {
                    s.Finish();
                    s.Close();
                }
            }
        }

        private void ZipFiles(ZipOutputStream aZipStream, string aPathWantToZip, string aRootDictionary)
        {

            List<string> filenames = new List<string>();
            if (File.Exists(aPathWantToZip))
            {
                filenames.Add(aPathWantToZip);
            }
            else if (Directory.Exists(aPathWantToZip))
            {
                filenames.AddRange(Directory.GetFileSystemEntries(aPathWantToZip));
            }

            if (filenames.Count == 0)
            {
                return;
            }


            byte[] buffer = new byte[4096];

            foreach (string file in filenames)
            {
                if (Directory.Exists(file))
                {
                    ZipFiles(aZipStream, file, aRootDictionary);
                }
                else
                {
                    string strEntryName = Path.GetFileName(file);
                    if (aRootDictionary.EndsWith(Path.DirectorySeparatorChar.ToString()) == false)
                    {
                        aRootDictionary = aRootDictionary + Path.DirectorySeparatorChar;
                    }
                    if (file.IndexOf(aRootDictionary) == 0)
                    {
                        strEntryName = file.Substring(aRootDictionary.Length);
                    }

                    ZipEntry entry = new ZipEntry(strEntryName);

                    entry.DateTime = DateTime.Now;
                    aZipStream.PutNextEntry(entry);

                    using (FileStream fs = File.OpenRead(file))
                    {
                        int sourceBytes;
                        do
                        {
                            sourceBytes = fs.Read(buffer, 0,
                            buffer.Length);

                            aZipStream.Write(buffer, 0, sourceBytes);

                        } while (sourceBytes > 0);
                    }
                }
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show(Path.GetDirectoryName(textBox1.Text));
        }

        public string GetHyperLinkRelativePath(string aPath)
        {
            if (aPath == "")
            {
                return "";
            }

            string[] strPath = aPath.Split('\\');

            if (strPath.Length < 5)
            {
                return "";
            }

            string strGetPath = "";

            for (int i = strPath.Length - 1; i > strPath.Length - 5; i--)
            {
                strGetPath = "/" + strPath[i] + strGetPath;
            }

            return strGetPath.Substring(1);
        }
    }

    
}
