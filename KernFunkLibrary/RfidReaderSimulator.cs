using System;
using System.Collections.Generic;
using System.Text;

namespace KernFunkLibrary
{
    public class RfidReaderSimulator : IRfidReader
    {
        private int Id { get; set; }

        public event EventHandler<RfidEventArgs> IdRegisteredEvent;

        public void IdRegistered()
        {
            IdRegisteredEvent?.Invoke(this, new RfidEventArgs() { Id = Id });
        }
    }
}
