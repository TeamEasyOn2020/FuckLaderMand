using KernFunkLibrary.UsbSimulator;

namespace KernFunkLibrary
{
    public class ChargerControlSimulator : IChargerControl
    {
        private IDisplay _display;
        private IUsbCharger _iUsbCharger;
        public bool IsConnected { get; }
        public void StartCharge()
        {
            throw new System.NotImplementedException();
        }

        public void StopCharge()
        {
            throw new System.NotImplementedException();
        }

        public void HandleCurrentEvent(object sender, CurrentEventArgs e)
        {

        }
    }
}