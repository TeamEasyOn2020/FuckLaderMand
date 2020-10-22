using System;
using System.Collections.Generic;
using System.Text;

namespace KernFunkLibrary
{
    public class RfidEventArgs : EventArgs
    {
        public int Id { get; set; }
    }

    public interface IRfidReader
    {
        event EventHandler<RfidEventArgs> IdRegisteredEvent;

        void IdRegistered();
    }
}
