namespace WarMachinesAndShit
{
    using System.Text;
    public class Fighter: WarMachine, IFighter
    {
        private readonly double initialHealth = 200;
        public Fighter(string name, double attackPoints, double defensePoints, bool stealth)
            :base(name)
        {
            this.AttackPoints = attackPoints;
            this.DefensePoints = defensePoints;
            this.StealthMode = stealth;
            this.HealthPoints = initialHealth;
        }
        public bool StealthMode
        {
            get;
            private set;
        }

        public void ToggleStealthMode()
        {
            this.StealthMode = !(this.StealthMode);
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("- " + this.Name + "/r/n *Type: " + this.GetType().Name + "/r/n" + base.ToString() + "/r/n *Stealth: ");

            if (this.StealthMode == true)
            {
                sb.Append("ON");
            }
            else
            {
                sb.Append("OFF");
            }

            return sb.ToString();
        }
    }
}
