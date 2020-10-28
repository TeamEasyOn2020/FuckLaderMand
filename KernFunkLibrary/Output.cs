using System;

namespace KernFunkLibrary
{
    public class Output : IStationControlOutput
    {
        public void WriteLine(string msg)
        {
           Console.WriteLine(msg);
        }
    }
}