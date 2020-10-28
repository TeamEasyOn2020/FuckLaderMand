using System;
using KernFunkLibrary;
using NUnit.Framework;
using NSubstitute;

namespace KerFunk.UnintTest
{
    public class DisplayTest
    {

        private IDisplay uut;
        [SetUp]
        public void Setup()
        {
            uut = new DisplaySimulator();
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