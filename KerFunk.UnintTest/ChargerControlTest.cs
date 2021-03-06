﻿using KernFunkLibrary;
using NSubstitute;
using NSubstitute.ReceivedExtensions;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace KerFunk.UnintTest
{
    public class ChargerControlTest
    {
        //variables
        IUsbCharger UsbCharger;
        IDisplay Display;
        IChargerControl _uut;


        [SetUp]
        public void SetUp()
        {
            UsbCharger = Substitute.For<IUsbCharger>();
            Display = Substitute.For<IDisplay>();
            _uut = new ChargerControlSimulator(Display, UsbCharger);
        }

              [Test]
        public void IsConnected_IsTrue()
        {
            UsbCharger.Connected.Returns(true);

            Assert.IsTrue(_uut.IsConnected());
        }

        [Test]
        public void IsConnected_IsFalse()
        {
            UsbCharger.Connected.Returns(false);

            Assert.IsFalse(_uut.IsConnected());
        }

        [Test]
        public void StartCharge_UsbChargeStartChargeCalled()
        {
            _uut.StartCharge();

            UsbCharger.Received(1).StartCharge();
        }

        [Test]
        public void StopCharge_UsbChargeStopChargeCalled()
        {
            _uut.StopCharge();

            UsbCharger.Received(1).StopCharge();
            
        }

        [TestCase(0)]
        [TestCase(100)]
        [TestCase(500)]
        public void HandleCurrentEvent_SetValue_EventTriggered(double current)
        {
            UsbCharger.CurrentValueEvent += Raise.EventWith(new CurrentEventArgs { Current = current});

            Display.Received().ShowChargingMessage($"Current is: {current}");
        }

        [Test]
        public void HandleCurrentEvent_CurrentReachedStopCharge_StopChargeCalled()
        {
            UsbCharger.CurrentValueEvent += Raise.EventWith(new CurrentEventArgs { Current = 2.5 });

            UsbCharger.Received().StopCharge();
        }

    }
}
