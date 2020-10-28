using System;
using System.Collections.Generic;
using System.Text;

namespace KernFunkLibrary
{
    public class DisplaySimulator : IDisplay
    {
        public void ShowStationMessage(string message)
        {
            //Test Console write
            Console.WriteLine(message);
        }
        public void ShowChargingMessage(string message)
        {
            Console.WriteLine(message);
        }
    }
}
