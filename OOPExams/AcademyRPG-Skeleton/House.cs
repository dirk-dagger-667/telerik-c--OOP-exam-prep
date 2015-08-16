namespace AcademyRPG
{
    public class House: StaticObject
    {
        private readonly int initialHitPoints = 500;
        public House(Point position, int owner)
            :base(position, owner)
        {
            this.HitPoints = this.initialHitPoints;
        }
    }
}
