namespace WarMachinesAndShit
{
    public interface ITank : IMachine
    {
        bool DefenseMode { get; }
        void ToggleDefenseMode();
    }

}
