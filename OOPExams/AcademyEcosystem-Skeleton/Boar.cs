namespace AcademyEcosystem
{
    public class Boar: Animal, ICarnivore, IHerbivore
    {
        private readonly int biteSize = 2;
        public Boar(string name, Point posistion)
            :base(name, posistion, 4)
        {
            
        }
        public override void Update(int timeElapsed)
        {
            if (this.State == AnimalState.Sleeping)
            {
                if (timeElapsed >= sleepRemaining)
                {
                    this.Awake();
                }
                else
                {
                    this.sleepRemaining -= timeElapsed;
                }
            }

            base.Update(timeElapsed);
        }
        public int EatPlant(Plant plant)
        {
            if (plant != null)
            {
                this.Size += 1;
                return plant.GetEatenQuantity(this.biteSize);
            }

            return 0;
        }
        public int TryEatAnimal(Animal animal)
        {
            if (animal != null)
            {
                if (this.Size >= animal.Size || animal.State == AnimalState.Sleeping)
                {
                    return animal.GetMeatFromKillQuantity();
                }
            }
            
            return 0;
        }
    }
}
