using System;
using System.Collections.Generic;
using System.Text;

namespace KernFunkLibrary
{
    public class DisplaySimulator : IDisplay
    {
        private IStationControlOutput _output;

        public DisplaySimulator(IStationControlOutput output)
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
