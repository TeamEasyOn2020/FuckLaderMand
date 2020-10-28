using System;
using System.Collections.Generic;
using System.Text;

namespace KernFunkLibrary
{
    public class DisplaySimulator : IDisplay
    {
        private IOutput _output;

        public DisplaySimulator(IOutput output)
        {
            _output = output;
        }

        public void ShowStationMessage(string message)
        {
            //Test Console write
           _output.WriteLine(message);
        }
        public void ShowChargingMessage(string message)
        {
            _output.WriteLine(message);
        }
    }
}
