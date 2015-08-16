namespace AcademyRPG
{
    using System.Linq;
    class Ninja: Character, IFighter, IGatherer
    {
        private int attackPoints;
        public Ninja(string name, Point position, int owner)
            :base(name, position, owner)
        {
            this.AttackPoints = 0;
            this.HitPoints = 1;
        }
        public int AttackPoints
        {
            get
            {
                return this.attackPoints;
            }
            private set
            {
                this.attackPoints = value;
            }
        }
        public int DefensePoints
        {
            get { return 0; }
        }
        public int GetTargetIndex(System.Collections.Generic.List<WorldObject> availableTargets)
        {
            int targetHitPoints = availableTargets.Where(x => x.Owner != 0 && x.Owner != this.Owner).Max(x => x.HitPoints);

            for (int i = 0; i < availableTargets.Count; i++)
            {
                if (availableTargets[i].HitPoints == targetHitPoints)
                {
                    return i;
                }
            }

            return -1;
        }
        public bool TryGather(IResource resource)
        {
            if (resource.Type == ResourceType.Lumber)
            {
                this.AttackPoints += resource.Quantity;
                return true;
            }
            else if (resource.Type == ResourceType.Stone)
            {
                this.AttackPoints += 2 * resource.Quantity;
                return true;
            }

            return false;
        }
    }
}
