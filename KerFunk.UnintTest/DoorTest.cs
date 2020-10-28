using System;
using System.Collections.Generic;
using System.Text;
using KernFunkLibrary;
using NSubstitute;
using NUnit.Framework;

namespace KerFunk.UnintTest
{
    [TestFixture]
    class DoorTest
    {
        private IDoor _uut;
        [SetUp]
        public void Setup()
        {
            _uut = new DoorSimulator();
        }

        [Test]
        public void LockDoor_DoorClosedTrueDoorOpenFalse()
        {
            _uut.LockDoor();
            Assert.That(_uut.DoorOpen==false && _uut.DoorClosed==true);
            
        }

        [Test]
        public void UnlockDoor_DoorClosedFalseDoorOpenTrue()
        {
            _uut.UnlockDoor();
            Assert.That(_uut.DoorOpen == true && _uut.DoorClosed == false);

        }
         
        [Test]
        public void OnDoorOpened_EventInvoked_EventArgsDoorOpenTrueDoorClosedFalse()
        {
            var control = new ControlDoorEvents(_uut);

            _uut.UnlockDoor();
            _uut.OnDoorOpened();

            Assert.That(control.DoorOpen == true && control.DoorClosed == false);

        }

        [Test]
        public void OnDoorClosed_EventInvoked_EventArgsDoorOpenFalseDoorClosedTrue()
        {
            var control = new ControlDoorEvents(_uut);

            _uut.LockDoor();
            _uut.OnDoorClosed();

            Assert.That(control.DoorOpen == false && control.DoorClosed == true);

        }



    }

    public class ControlDoorEvents
    {
        public bool DoorOpen { get; set; }
        public bool DoorClosed { get; set; }
        public ControlDoorEvents(IDoor door)
        {
            door.DoorOpenEvent+= HandleDoorEvent;
            door.DoorCloseEvent+= HandleDoorEvent;
        }

        private void HandleDoorEvent(object door, DoorEventArgs e)
        {
            DoorOpen = e.DoorOpen;
            DoorClosed = e.DoorClosed;
        }
    }
}
