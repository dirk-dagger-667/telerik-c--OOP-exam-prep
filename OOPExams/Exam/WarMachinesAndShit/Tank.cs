namespace WarMachinesAndShit
{
    using System.Text;
    public class Tank: WarMachine, ITank
    {
        private readonly double initialHealth = 100;
        private readonly bool initialDefenseMode = true;
        public Tank(string name, double attackPoints, double defensePoints)
            :base(name)
        {
            this.HealthPoints = initialHealth;
            this.DefenseMode = initialDefenseMode;
            this.AttackPoints = attackPoints - 40;
            this.DefensePoints = defensePoints + 30;
        }
        public bool DefenseMode
        {
            get;
            private set;
        }

        public void ToggleDefenseMode()
        {
            if (this.DefenseMode == true)
            {
                this.DefenseMode = false;
                this.AttackPoints += 40;
                this.DefensePoints -= 30;
            }
            else
            {
                this.DefenseMode = true;
                this.DefensePoints += 30;
                this.AttackPoints -= 40;
            }
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("- " + this.Name + "/r/n *Type: " + this.GetType().Name + "/r/n" + base.ToString() + "/r/n *Defense: ");

            if (this.DefenseMode == true)
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
