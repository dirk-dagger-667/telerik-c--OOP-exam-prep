namespace WarMachinesAndShit
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    public abstract class WarMachine : IMachine
    {
        private string name;
        private double healthPoints;
        private IPilot pilot;
        public WarMachine(string name)
        {
            this.Name = name;
        }
        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                if (value == null || value == string.Empty)
                {
                    throw new ArgumentNullException("The name of the war machine cannot be null or empty");
                }

                this.name = value;
            }
        }

        public IPilot Pilot
        {
            get
            {
                return this.pilot;
            }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("The pilot of the machine cannot be null");
                }

                this.pilot = value;
            }
        }

        public double HealthPoints
        {
            get
            {
                return this.healthPoints;
            }
            set
            {
                this.healthPoints = value;
            }
        }

        public double AttackPoints
        {
            get;
            protected set;
        }

        public double DefensePoints
        {
            get;
            protected set;
        }

        public IList<string> Targets
        {
            get;
            protected set;
        }

        public void Attack(string target)
        {
            this.Targets.Add(target);
        }

        public override string ToString()
        {
            var resultAsStringBuilder = new StringBuilder();
            resultAsStringBuilder.Append(" *Health: " + this.HealthPoints + "/r/n *Attack: " + this.AttackPoints +
                "/r/n *Defense: " + this.DefensePoints + "/r/n *Targets: ");

            if (this.Targets.Count == 0)
            {
                resultAsStringBuilder.Append("None");
            }
            else
            {
                for (int i = 0; i < this.Targets.Count - 1; i++)
                {
                    resultAsStringBuilder.Append(this.Targets[i] + ", ");
                }

                resultAsStringBuilder.Append(this.Targets[this.Targets.Count - 1]);
            }

            return resultAsStringBuilder.ToString();
        }
    }
}
