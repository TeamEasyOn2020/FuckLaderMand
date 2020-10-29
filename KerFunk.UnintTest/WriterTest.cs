using System;
using System.IO;
using System.Linq;
using System.Text;
using KernFunkLibrary;
using NSubstitute;
using NUnit.Framework;

namespace KerFunk.UnintTest
{
    public class WriterTest
    {
        private WriterSimulator _uut;

        [SetUp]
        public void Setup()
        {
            _uut = new WriterSimulator("/LogFile.txt");

        }

        [Test]
        public void WriterSimulator_ThrowsException()
        {
            Assert.Throws<ArgumentNullException>(() => _uut = new WriterSimulator(null));
        }
        
        [Test]
        public void WriteLine_FileWasCreated()
        {
            File.Delete(_uut.LogFile);
           _uut.WriteLine("Test");

           Assert.True(File.Exists(_uut.LogFile));
        }

        
        [TestCase("")]
        [TestCase("Door Locked")]
        [Test]
        public void WriteLine_message_MessageWrittenToFile(string message)
        {
            _uut.WriteLine(message);
            var lastLine = File.ReadLines(_uut.LogFile).Last();
            Assert.AreEqual(message, lastLine);
        }
    }


}