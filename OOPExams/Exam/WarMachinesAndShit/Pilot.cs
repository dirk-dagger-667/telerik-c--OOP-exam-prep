namespace WarMachinesAndShit
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    public class Pilot : IPilot
    {
        private string name;
        private IList<IMachine> listOfMachines;
        public Pilot(string name)
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
                    throw new ArgumentNullException("The name of hte pilot cannot be null or empty");
                }

                this.name = value;
            }
        }

        public void AddMachine(IMachine machine)
        {
            this.listOfMachines.Add(machine);
            machine.Pilot = this;
        }

        public string Report()
        {
            var sb = new StringBuilder();
            sb.Append(this.Name + " - ");

            if (this.listOfMachines.Count == 0)
            {
                sb.Append("no machines");
            }
            else if (this.listOfMachines.Count == 1)
            {
                sb.Append("1 machine");
            }
            else
            {
                sb.Append(this.listOfMachines.Count + " machines/r/n");
            }

            if (this.listOfMachines.Count > 0)
            {
                for (int i = 0; i < this.listOfMachines.Count - 1; i++)
                {
                    sb.Append(this.listOfMachines[i].ToString() + "/r/n");
                }

                sb.Append(this.listOfMachines[this.listOfMachines.Count - 1].ToString());
            }

            return sb.ToString();
        }
    }
}
