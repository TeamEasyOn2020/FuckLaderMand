using System;
using System.IO;
using KernFunkLibrary;
using NUnit.Framework;

namespace KerFunk.UnintTest
{
    public class OutputTest
    {
        private IStationControlOutput uut;

        [SetUp]
        public void Setup()
        {
            uut = new Output();
        }


        [TestCase(null)]
        [TestCase("")]
        [TestCase("Door Locked")]
        [Test]
        public void WriteLine_message_WrittenOutputWasMessage(string message)
        {
            //Setup
            string expected = message + "\r\n";
            StringWriter sw = new StringWriter();
            Console.SetOut(sw);

            //Act
            uut.WriteLine(message);
            
            //Assert
            Assert.AreEqual(expected, sw.ToString());
        }
    }
}