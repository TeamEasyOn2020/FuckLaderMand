using System;

namespace KernFunkLibrary
{
    public class DoorEventArgs : EventArgs
    {
        public bool DoorOpen { get; set; }
        public bool DoorClosed { get; set; }
    }
}