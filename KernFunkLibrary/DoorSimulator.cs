using System;

namespace KernFunkLibrary
{
    public class DoorSimulator
    {
        public event EventHandler<DoorEventArgs> DoorEvent;
        private DoorEventArgs door;
        public bool DoorOpen { get; private set; }
        public bool DoorClosed { get; private set; }
        private void OnDoorOpened()
        {
            DoorEvent?.Invoke(this, new DoorEventArgs() {DoorOpen = DoorOpen, DoorClosed = DoorClosed});
        }

        private void OnDoorClosed()
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