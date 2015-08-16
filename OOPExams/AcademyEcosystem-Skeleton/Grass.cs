namespace AcademyEcosystem
{
    public class Grass: Plant
    {
        public Grass(Point position)
            :base(position, 2)
        {

        }

        public override void Update(int time)
        {
            if (this.IsAlive == true)
            {
                this.Size += 1;
            }
        }

        public int GetEatenQuantity(int biteSize)
        {
            if (biteSize > this.Size)
            {
                this.IsAlive = false;
                this.Size = 0;
                return this.Size;
            }
            else
            {
                this.Size -= biteSize;
                return biteSize;
            }
        }
    }
}
