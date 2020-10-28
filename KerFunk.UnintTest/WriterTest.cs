//using System;
//using System.IO;
//using System.Linq;
//using System.Text;
//using KernFunkLibrary;
//using NSubstitute;
//using NUnit.Framework;

//namespace KerFunk.UnintTest
//{
//    public class WriterTest
//    {
//        private WriterSimulator _uut;

//        [SetUp]
//        public void Setup()
//        {
//            _uut = new WriterSimulator();
            
//        }


//        [TestCase(null)]
//        [TestCase("")]
//        [TestCase("Door Locked")]
//        [Test]
//        public void WriteLine_message_WrittenOutputWasMessage(string message)
//        {
//            //Setup
//            var writer = Substitute.ForPartsOf<WriterSimulator>();
//            var strem = new MemoryStream();
//            StreamWriter streamWriterTest = new StreamWriter(strem);
//            writer.LogFile = "LogFile.txt";
//            writer.GetLogFile().Returns(streamWriterTest);
//            string expected = message + "\r\n";
            
//            //Act
//            writer.WriteLine(message);

//            //Assert
//            string actualOutput = Encoding.UTF8.GetString(strem.ToArray());
//            Assert.AreEqual(expected, actualOutput);
//        }
//    }

    
//}