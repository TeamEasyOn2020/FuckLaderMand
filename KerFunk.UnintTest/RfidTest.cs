using KernFunkLibrary;
using NUnit.Framework;
using NSubstitute;
using NSubstitute.Core;

namespace KerFunk.UnintTest
{
    class RfidTest
    {
        IRfidReader _uut;
        RfidEventArgs _recievedEventArgs;
        int _numberOfEvents;

        [SetUp]
        public void Setup()
        {
            _recievedEventArgs = null;
            _uut = new RfidReaderSimulator();
            _numberOfEvents = 0;
            _uut.IdRegisteredEvent += (o, a) =>
            {
                _recievedEventArgs = a;
                _numberOfEvents++;
            };

        }

        [Test]
        public void ctor_SetId_EventTriggered()
        {
            _uut.SetId(1);
            Assert.That(_recievedEventArgs, Is.Not.Null);
        }

        [TestCase(0)]
        [TestCase(1)]
        [TestCase(-1)]
        [TestCase(-10)]
        [TestCase(10)]
        public void ctor_SetId_CorrectData(int newId)
        {
            _uut.SetId(newId);
            Assert.That(_recievedEventArgs.Id, Is.EqualTo(newId));
        }

        [Test]
        public void SetId_SameValue_OneEventTriggered()
        {
            _uut.SetId(1);
            _uut.SetId(1);

            Assert.That(_numberOfEvents, Is.EqualTo(1));
        }

        [Test]
        public void SetId_ValueChanges_TwoEventsTriggered()
        {
            _uut.SetId(1);
            _uut.SetId(2);

            Assert.That(_numberOfEvents, Is.EqualTo(2));
        }

        [Test]
        public void SetId_ValueChanges_CorrectNewValue()
        {
            _uut.SetId(1);
            _uut.SetId(15);

            Assert.That(_recievedEventArgs.Id, Is.EqualTo(15));
        }

    }
}
