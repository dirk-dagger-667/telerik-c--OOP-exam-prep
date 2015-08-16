namespace Infestation
{
    public abstract class Supplement: ISupplement
    {
        public Supplement()
        {
            this.PowerEffect = 0;
            this.HealthEffect = 0;
            this.AggressionEffect = 0;
        }
        public virtual void ReactTo(ISupplement otherSupplement)
        {
            
        }
        public int PowerEffect
        {
            get;
            protected set;
        }
        public int HealthEffect
        {
            get;
            protected set;
        }
        public int AggressionEffect
        {
            get;
            protected set;
        }
    }
}
