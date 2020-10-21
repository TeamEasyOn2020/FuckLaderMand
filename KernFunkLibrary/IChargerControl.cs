namespace KernFunkLibrary
{
    public interface IChargerControl
    {
        public bool IsConnected { get; }
        public void StartCharge();
        public void StopCharge();
    }
}