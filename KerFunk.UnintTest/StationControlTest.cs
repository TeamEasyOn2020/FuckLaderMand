using KernFunkLibrary;
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

        private StationControl uut;

        [SetUp]
        public void Setup()
        {
            _door = Substitute.For<IDoor>();
            _display = Substitute.For<IDisplay>();
            _rfidReader = Substitute.For<IRfidReader>();
            _chargerControl = Substitute.For<IChargerControl>();

            uut = new StationControl(_door, _chargerControl, _display, _rfidReader);
        }

        [Test]
        public void HandleDoorOpenEvent_EventFired_DoorOpenState()
        {
            //Setup
            _door.DoorOpenEvent += Raise.EventWith(new DoorEventArgs() {DoorOpen = true, DoorClosed = false});

            //Assert
            //Assert.That(uut.);
        }
    }
}