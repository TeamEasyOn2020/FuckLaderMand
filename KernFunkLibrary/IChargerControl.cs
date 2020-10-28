namespace KernFunkLibrary
{
    public interface IChargerControl
    {
        public bool IsConnected();
        public void StartCharge();
        public void StopCharge();
    }
}