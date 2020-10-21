using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using System.Text;

namespace KernFunkLibrary
{
    public interface IDoor
    {
        public event EventHandler<DoorEventArgs> DoorEvent;
        public void LockDoor();
        public void UnlockDoor();
        public void OnDoorOpened();
        public void OnDoorClosed();
        public bool DoorOpen { get;  }
        public bool DoorClosed { get; }
    }
}
