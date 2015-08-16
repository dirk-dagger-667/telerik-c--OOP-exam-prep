namespace Infestation
{
    public class Weapon: Supplement
    {
        public Weapon()
        {

        }

        public override void ReactTo(ISupplement otherSupplement)
        {
            if (otherSupplement.GetType().Name == "WeaponrySkill")
            {
                this.AggressionEffect = 3;
                this.PowerEffect = 10;
            }
        }
    }
}
