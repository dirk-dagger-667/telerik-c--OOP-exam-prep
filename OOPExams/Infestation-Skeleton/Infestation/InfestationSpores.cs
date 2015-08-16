namespace Infestation
{
    public class InfestationSpores: Supplement
    {
        public InfestationSpores()
        {
            this.AggressionEffect = 20;
            this.PowerEffect = -1;
        }
        public override void ReactTo(ISupplement otherSupplement)
        {
            if (otherSupplement.GetType().Name == "InfestationSpores")
            {
                this.AggressionEffect = 0;
                this.PowerEffect = 0;
            }
        }
    }
}
