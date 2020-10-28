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
        public void SetId(int id);


        event EventHandler<RfidEventArgs> IdRegisteredEvent;

        void IdRegistered(RfidEventArgs e);
    }
}
