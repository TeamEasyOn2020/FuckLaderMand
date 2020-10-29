using KernFunkLibrary;

namespace KernFunkLibrary
{
    public class ChargerControlSimulator : IChargerControl
    {
        private IDisplay _display;
        private IUsbCharger _iUsbCharger;
        public bool IsConnected()
        { return _iUsbCharger.Connected; }
        

        public ChargerControlSimulator(IDisplay display, IUsbCharger usbCharger)
        {
            _display = display;
            _iUsbCharger = usbCharger;

            _iUsbCharger.CurrentValueEvent += HandleCurrentEvent;
        }
        public void StartCharge()
        {
            _iUsbCharger.StartCharge();
        }

        public void StopCharge()
        {
           _iUsbCharger.StopCharge();
        }

        public void HandleCurrentEvent(object sender, CurrentEventArgs e)
        {
            if(e.Current == 2.5)
                StopCharge();
            //else if (e.Current ==)

            _display.ShowChargingMessage($"Current is: {e.Current}");
        }
    }
}