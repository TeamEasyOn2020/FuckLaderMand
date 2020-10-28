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
        private DoorEventArgs _receivedEventArgs;
        [SetUp]
        public void Setup()
        {
            _uut = new DoorSimulator();
            _receivedEventArgs = null;


            _uut.DoorOpenEvent += ReceivedEventArgs;
            _uut.DoorCloseEvent += ReceivedEventArgs;

        }

        private void ReceivedEventArgs(object o, DoorEventArgs a)
        {
            _receivedEventArgs = a;
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
            
            _uut.UnlockDoor();
            _uut.OnDoorOpened();

            Assert.That(_receivedEventArgs.DoorOpen == true && _receivedEventArgs.DoorClosed == false);

        }

        [Test]
        public void OnDoorClosed_EventInvoked_EventArgsDoorOpenFalseDoorClosedTrue()
        {
            _uut.LockDoor();
            _uut.OnDoorClosed();

            Assert.That(_receivedEventArgs.DoorOpen == false && _receivedEventArgs.DoorClosed == true);

        }



    }


}
