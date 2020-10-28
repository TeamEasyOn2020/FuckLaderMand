using System.IO;

namespace KernFunkLibrary
{
    public class WriterSimulator : IWriter
    {
        public string LogFile { get; set; }

        public void WriteLine(string msg)
        {
            var writer = File.AppendText(LogFile);
            writer.WriteLine(msg);
        }
    }
}