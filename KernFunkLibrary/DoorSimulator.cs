using System;

namespace KernFunkLibrary
{
    public class DoorSimulator:IDoor
    {
        public event EventHandler<DoorEventArgs> DoorEvent;
        public bool DoorOpen { get; private set; }
        public bool DoorClosed { get; private set; }
        public void OnDoorOpened()
        {
            DoorEvent?.Invoke(this, new DoorEventArgs() {DoorOpen = DoorOpen, DoorClosed = DoorClosed});
        }

        public void OnDoorClosed()
        {
            DoorEvent?.Invoke(this, new DoorEventArgs() { DoorOpen = DoorOpen, DoorClosed = DoorClosed });
        }

        public void LockDoor()
        {
            DoorOpen = false;
            DoorClosed = true;
        }

        public void UnlockDoor()
        {
            DoorOpen = true;
            DoorClosed = false;
        }
    }

    

}