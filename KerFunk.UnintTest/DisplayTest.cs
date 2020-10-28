using System;
using KernFunkLibrary;
using NUnit.Framework;
using NSubstitute;

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
        [TestCase("Door Locked")]
        [Test]
        public void ShowStationsMessage_message_messageWritten(string message)
        {
            //Arange setup

            // Act
            
            //Assert
            
        }
    }
}