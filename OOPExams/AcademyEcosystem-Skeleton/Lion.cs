namespace AcademyEcosystem
{
    public class Lion: Animal, ICarnivore
    {
        public Lion(string name, Point position)
            :base(name, position, 6)
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
        public int TryEatAnimal(Animal animal)
        {
            if (animal != null)
            {
                if (this.Size >= 2 * animal.Size || animal.State == AnimalState.Sleeping)
                {
                    this.Size += 1;
                    return animal.GetMeatFromKillQuantity();
                }
            }
            
            return 0;
        }
    }
}
