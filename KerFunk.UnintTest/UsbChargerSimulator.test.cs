using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using KernFunkLibrary;
using KernFunkLibrary.UsbSimulator;

namespace KerFunk.UnintTest
{
    [TestFixture]
    public class UsbChargerSimulatorTest
    {
        private UsbChargerSimulator _uut;
        [SetUp]
        public void SetUp()
        {
            _uut = new UsbChargerSimulator();

        }


    }
}
