using KernFunkLibrary;
using Microsoft.VisualStudio.TestPlatform.Utilities;
using NSubstitute;
using NUnit.Framework;

namespace KerFunk.UnintTest
{
    public class StationControlTest
    {
        private IDoor _door;
        private IDisplay _display;
        private IRfidReader _rfidReader;
        private IChargerControl _chargerControl;
        private IWriter _writer;
        private IStationControlOutput _output;

        private StationControl uut;

        [SetUp]
        public void Setup()
        {
            _output = Substitute.For<IStationControlOutput>();
            _door = Substitute.For<IDoor>();
            _display = Substitute.For<IDisplay>();
            _rfidReader = Substitute.For<IRfidReader>();
            _chargerControl = Substitute.For<IChargerControl>();
            _writer = Substitute.For<IWriter>();
            _writer.LogFile = "LogFile.txt";
            uut = new StationControl(_door, _chargerControl, _display, _rfidReader, _writer);
        }

        [Test]
        public void HandleDoorOpenEvent_EventFired_DoorOpenState()
        {
            //Setup
            _door.DoorOpenEvent += Raise.EventWith(new DoorEventArgs() {DoorOpen = true, DoorClosed = false});

            //Assert
            Assert.That(uut.State == StationControl.LadeskabState.DoorOpen);
        }
        [Test]
        public void HandleDoorCloseEvent_EventFired_DoorCloseState()
        {
            //Setup
            _door.DoorCloseEvent += Raise.EventWith(new DoorEventArgs() { DoorOpen = false, DoorClosed = true});

            //Assert
            Assert.That(uut.State == StationControl.LadeskabState.Locked);
        } 
        [Test]
        public void HandleDoorOpenEvent_EventFired_DoorCloseState()
        {
            //Setup
            _door.DoorOpenEvent += Raise.EventWith(new DoorEventArgs() {DoorOpen = false, DoorClosed = true});

            //Assert
            Assert.That(uut.State != StationControl.LadeskabState.Locked);
        }
        [Test]
        public void HandleDoorCloseEvent_EventFired_DoorOpenState()
        {
            //Setup
            _door.DoorCloseEvent += Raise.EventWith(new DoorEventArgs() { DoorOpen = true, DoorClosed = false});

            //Assert
            Assert.That(uut.State != StationControl.LadeskabState.DoorOpen);
        } 
        
        [Test]
        public void HandleDoorOpenEvent_EventFired_TilslutMessageDisplayed()
        {
            //Setup
            _door.DoorOpenEvent += Raise.EventWith(new DoorEventArgs() {DoorOpen = true, DoorClosed = false});

            //Assert
            _display.Received().ShowStationMessage("Tilslut Telefon");
        }
        [Test]
        public void HandleDoorCloseEvent_EventFired_IndlaesMessageDisplayed()
        {
            //Setup
            _door.DoorCloseEvent += Raise.EventWith(new DoorEventArgs() { DoorOpen = false, DoorClosed = true});

            //Assert
            _display.Received().ShowStationMessage("Indlæs Rfid");
        }

        [Test]
        public void HandleRfidDetectedWhileDoorOpen_EventFired_NothingHappened()
        {
            //Setup
            uut.State = StationControl.LadeskabState.DoorOpen;
            _rfidReader.IdRegisteredEvent += Raise.EventWith(new RfidEventArgs() {Id = 4});


            //Assert
            _output.DidNotReceive();
            _writer.DidNotReceive();
            _display.DidNotReceive();
            _chargerControl.DidNotReceive();
            _door.DidNotReceive();

        }        
        
        [Test]
        public void HandleRfidDetectedWhileAvailable_EventFiredIsConnectedTrue_Locked()
        {
            //Setup
            uut.State = StationControl.LadeskabState.Available;
            _chargerControl.IsConnected().Returns(true);
            _rfidReader.IdRegisteredEvent += Raise.EventWith(new RfidEventArgs() {Id = 4});


            //Assert
            Assert.AreEqual(uut.State, StationControl.LadeskabState.Locked); 

        }        
        
        [Test]
        public void HandleRfidDetectedWhileAvailable_EventFiredIsConnectedFalse_AvailableDisplayErrorMessage()
        {
            //Setup
            uut.State = StationControl.LadeskabState.Available;
            _chargerControl.IsConnected().Returns(false);
            _rfidReader.IdRegisteredEvent += Raise.EventWith(new RfidEventArgs() {Id = 4});


            //Assert
            _display.Received().ShowStationMessage("Din telefon er ikke ordentlig tilsluttet. Prøv igen.");
            Assert.AreEqual(uut.State, StationControl.LadeskabState.Available);
        }  
        
        [Test]
        public void HandleRfidDetectedWhileLocked_EventFiredIdEqualsOldId_Available()
        {
            //Setup
            uut.State = StationControl.LadeskabState.Locked;
            uut.OldId = 4;
            _rfidReader.IdRegisteredEvent += Raise.EventWith(new RfidEventArgs() {Id = 4});


            //Assert
            Assert.AreEqual(uut.State, StationControl.LadeskabState.Available); 

        } 
        
        [Test]
        public void HandleRfidDetectedWhileLocked_EventFiredIdNotEqualOldId_LockedDisplayErrorMessage()
        {
            //Setup
            uut.State = StationControl.LadeskabState.Locked;
            uut.OldId = 3;
            _rfidReader.IdRegisteredEvent += Raise.EventWith(new RfidEventArgs() {Id = 4});


            //Assert
            _display.Received().ShowStationMessage("Forkert RFID tag");
            Assert.AreEqual(uut.State, StationControl.LadeskabState.Locked);

        }


    }
}