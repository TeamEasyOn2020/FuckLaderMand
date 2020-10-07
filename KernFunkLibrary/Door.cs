using System;

namespace KernFunkLibrary
{
    public class Door
    {
        public event EventHandler<DoorEventArgs> DoorEvent;
        private DoorEventArgs door;

        private void OnDoorOpened()
        {
            DoorEvent?.Invoke(this, new DoorEventArgs() {DoorOpen = true, DoorClosed = false});
        }

        private void OnDoorClosed()
        {
            DoorEvent?.Invoke(this, new DoorEventArgs() { DoorOpen = false, DoorClosed = true });
        }

        public void LockDoor()
        {
            
        }

        public void UnlockDoor()
        {

        }
    }

    

}