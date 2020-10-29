using System;
using System.IO;

namespace KernFunkLibrary
{
    public class WriterSimulator : IWriter
    {
        public WriterSimulator(string filename)
        {
            if (filename != null)
                LogFile = filename;
            else
            {
                throw new ArgumentNullException();
            }
        }
        public string LogFile { get; set; }

        public void WriteLine(string msg)
        {
            using (StreamWriter sw = File.AppendText(LogFile))
            {
                sw.WriteLine(msg);
            }
        }
    }
}