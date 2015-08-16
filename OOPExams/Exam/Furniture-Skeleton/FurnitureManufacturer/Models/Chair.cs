namespace FurnitureManufacturer.Models
{
    using FurnitureManufacturer.Interfaces;
    using System;
    using System.Text;
    public class Chair: Furniture, IChair
    {
        private int numberOfLegs;
        public Chair(string model, string material, decimal price, decimal height, int numberOfLegs)
            :base(model, material, price, height)
        {
            this.NumberOfLegs = numberOfLegs;
        }
        public int NumberOfLegs
        {
            get
            {
                return this.numberOfLegs;
            }
            protected set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException("the number of legs cannot be less, nor equal to 0");
                }

                this.numberOfLegs = value;
            }
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append(base.ToString() + ", Legs: " + this.NumberOfLegs);

            return sb.ToString();
        }
    }
}
