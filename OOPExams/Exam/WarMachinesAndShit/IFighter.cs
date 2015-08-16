namespace WarMachinesAndShit
{
    public interface IFighter : IMachine
    {
        bool StealthMode { get; }
        void ToggleStealthMode();
    }

}
