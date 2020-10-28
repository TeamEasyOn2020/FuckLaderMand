using System;

namespace KernFunkLibrary
{
    public class Output : IOutput
    {
        public void WriteLine(string msg)
        {
           Console.WriteLine(msg);
        }
    }
}