using System;

namespace KernFunkLibrary
{
    public class DoorSimulator : IDoor
    {
        public event EventHandler<DoorEventArgs> DoorOpenEvent;
        public event EventHandler<DoorEventArgs> DoorCloseEvent;

        private DoorEventArgs door;
        public bool DoorOpen { get; private set; }
        public bool DoorClosed { get; private set; }
        public void OnDoorOpened()
        {
            DoorOpenEvent?.Invoke(this, new DoorEventArgs() {DoorOpen = DoorOpen, DoorClosed = DoorClosed});
        }

        public void OnDoorClosed()
        {
            DoorCloseEvent?.Invoke(this, new DoorEventArgs() { DoorOpen = DoorOpen, DoorClosed = DoorClosed });
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