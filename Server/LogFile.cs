using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Server
{
    public class LogFile
    {
        private string fileName;
        StreamWriter streamWriter;
        public string FileName
        {
            get { return fileName; }
            private set { fileName = value; }
        }
        public LogFile(string fileName)
        {
            
        }
        public LogFile()
        {
            string now = DateTime.Now.ToString();
            now.Replace(' ', '_');
            FileName = "Log_" + now + ".txt";
            if (!File.Exists(FileName))
                File.Create(FileName);
        }
        public void WriteLog(string content)
        {
            streamWriter = File.AppendText(FileName);
            streamWriter.WriteLine(DateTime.Now.ToString() + " : " + content);
            streamWriter.Flush();
            streamWriter.Close();
        }
    }
}
