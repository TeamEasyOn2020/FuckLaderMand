using System;

namespace KernFunkLibrary
{
    public class Output : Ioutput
    {
        public void WriteLine(string msg)
        {
           Console.WriteLine(msg);
        }
    }
}