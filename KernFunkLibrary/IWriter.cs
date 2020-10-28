using System.Globalization;

namespace KernFunkLibrary
{
    public interface IWriter
    {
        public string LogFile { get; set; }
        public void WriteLine(string msg);
    }
}