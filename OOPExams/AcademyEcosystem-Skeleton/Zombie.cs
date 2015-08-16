namespace AcademyEcosystem
{
    public class Zombie: Animal
    {
        public Zombie(string name, Point position)
            :base(name, position, 1)
        {

        }
        public override int GetMeatFromKillQuantity()
        {
            return 10;
        }
    }
}
