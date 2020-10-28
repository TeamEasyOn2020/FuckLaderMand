using System;
using KernFunkLibrary;
using NUnit.Framework;
using NSubstitute;
using NSubstitute.ReceivedExtensions;

namespace KerFunk.UnintTest
{
    public class DisplayTest
    {

        private IDisplay uut;
        private IStationControlOutput _output;
        [SetUp]
        public void Setup()
        {
            _output = Substitute.For<IStationControlOutput>();
            uut = new DisplaySimulator(_output);
        }

        [TestCase(null)]
        [TestCase("")]
        [TestCase("Skabet er låst og din telefon lades. Brug dit RFID tag til at låse op.")]
        [Test]
        public void ShowStationsMessage_message_messageWritten(string message)
        {
            
            // Act
            uut.ShowStationMessage(message);
            //Assert
            _output.Received(1).WriteLine(message);
        }

        [TestCase(null)]
        [TestCase("")]
        [TestCase("Current is: 500")]
        [Test]
        public void ShowsChargingMessage_message_messageWritten(string message)
        {
            //Arange setup
            
            // Act
            uut.ShowChargingMessage(message);
            //Assert
            _output.Received(1).WriteLine(message);
        }
    }
}