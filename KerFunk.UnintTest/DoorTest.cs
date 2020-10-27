using System;
using System.Collections.Generic;
using System.Text;
using KernFunkLibrary;
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
        public void LockDoorDoorClosedTrueDoorOpenFalse()
        {
            _uut.LockDoor();
            Assert.That(_uut.DoorOpen==false && _uut.DoorClosed==true);
            
        }

        [Test]
        public void UnlockDoorDoorClosedFalseDoorOpenTrue()
        {
            _uut.UnlockDoor();
            Assert.That(_uut.DoorOpen == true && _uut.DoorClosed == false);

        }


    }
}
