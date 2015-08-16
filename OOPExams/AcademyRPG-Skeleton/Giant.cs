namespace AcademyRPG
{
    class Giant: Character, IFighter, IGatherer
    {
        private bool hasStone;
        private int attackPoints;
        private int defensePoints;
        public Giant(string name, Point position)
            :base(name, position, 0)
        {
            this.HitPoints = 200;
            this.AttackPoints = 150;
        }
        public int AttackPoints
        {
            get 
            {
                return this.attackPoints;
            }
            private set
            {
                this.AttackPoints = value;
            }
        }

        public int DefensePoints
        {
            get { return 80; }
        }

        public int GetTargetIndex(System.Collections.Generic.List<WorldObject> availableTargets)
        {
            for (int i = 0; i < availableTargets.Count; i++)
            {
                if (availableTargets[i].Owner != 0)
                {
                    return i;
                }
            }

            return -1;
        }

        public bool TryGather(IResource resource)
        {
            if (resource.Type == ResourceType.Stone)
            {
                if (this.hasStone == false)
                {
                    this.AttackPoints += 100;
                    this.hasStone = true;
                }

                return true;
            }

            return false;
        }
    }
}
