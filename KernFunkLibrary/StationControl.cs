using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KernFunkLibrary;



namespace KernFunkLibrary

{
    public class StationControl
    {
        // Enum med tilstande ("states") svarende til tilstandsdiagrammet for klassen
        public enum LadeskabState
        {
            Available,
            Locked,
            DoorOpen
        };

        // Her mangler flere member variable
        private LadeskabState _state;
        private IChargerControl _chargeControl;
        private int _oldId;
        private IDoor _door;
        private IDisplay _display;
        private IRfidReader _rfidReader;
        private IWriter _writer;


        // Her mangler constructor
        public StationControl (IDoor door, IChargerControl chargerControl, IDisplay display, IRfidReader rfidReader, IWriter writer)
        {
            _door = door;
            _chargeControl = chargerControl;
            _display = display;
            _rfidReader = rfidReader;
            _writer = writer;

            _door.DoorCloseEvent += HandleDoorClosedEvent;
            _door.DoorOpenEvent += HandleDoorOpenEvent;
            _rfidReader.IdRegisteredEvent += HandleRfidRegisteretEvent;
        }

        public int OldId { get; set; }
        public LadeskabState State { get; set; }

        // Eksempel på event handler for eventet "RFID Detected" fra tilstandsdiagrammet for klassen
        private void RfidDetected(int id)
        {
            switch (_state)
            {
                case LadeskabState.Available:
                    // Check for ladeforbindelse
                    if (_chargeControl.IsConnected)
                    {
                        _door.LockDoor();
                        _chargeControl.StartCharge();
                        _oldId = id;
                        
                        _writer.WriteLine(DateTime.Now + $": Skab låst med RFID: {id}");
                        

                        _display.ShowStationMessage("Skabet er låst og din telefon lades. Brug dit RFID tag til at låse op.");
                        _state = LadeskabState.Locked;
                    }
                    else
                    {
                        _display.ShowStationMessage("Din telefon er ikke ordentlig tilsluttet. Prøv igen.");
                    }

                    break;

                case LadeskabState.DoorOpen:
                    // Ignore
                    break;

                case LadeskabState.Locked:
                    // Check for correct ID
                    if (id == _oldId)
                    {
                        _chargeControl.StopCharge();
                        _door.UnlockDoor();

                        _writer.WriteLine(DateTime.Now + $": Skab låst op med RFID: {id}");
                        

                        _display.ShowStationMessage("Tag din telefon ud af skabet og luk døren");
                        _state = LadeskabState.Available;
                    }
                    else
                    {
                        _display.ShowStationMessage("Forkert RFID tag");
                    }

                    break;
            }
        }

        // Her mangler de andre trigger handlere
        private void HandleRfidRegisteretEvent(object sender, RfidEventArgs e)
        {
            RfidDetected(e.Id);
        }

        private void HandleDoorOpenEvent(object sender, DoorEventArgs e)
        {
            if (e.DoorOpen)
            {
                _display.ShowStationMessage("Tilslut Telefon");
                _state = LadeskabState.DoorOpen;
            }
        }

        private void HandleDoorClosedEvent(object sender, DoorEventArgs e)
        {
            if(e.DoorClosed)
            {
                _display.ShowStationMessage("Indlæs Rfid");
                _state = LadeskabState.Locked;
            }

        }
        
    }
}
