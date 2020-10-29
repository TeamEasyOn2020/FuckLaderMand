using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using System.Text;

namespace KernFunkLibrary
{
    public class RfidReaderSimulator : IRfidReader
    {
        private int Id;
        private int oldId = -100;

        public void SetId(int id)
        {

            IdRegistered(new RfidEventArgs { Id = id });
            oldId = id;

        }

        public event EventHandler<RfidEventArgs> IdRegisteredEvent;

        public void IdRegistered(RfidEventArgs e)
        {
            IdRegisteredEvent?.Invoke(this, e);
        }
    }
}
