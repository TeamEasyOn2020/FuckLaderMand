using System;
using System.Collections.Generic;
using System.Text;

namespace KernFunkLibrary
{
    public interface IDisplay
    {
        public void ShowStationMessage(string message);
        public void ShowChargingMessage(string message);
    }
}
