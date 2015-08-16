namespace FurnitureManufacturer.Models
{
    using FurnitureManufacturer.Interfaces;
    using System;
    using System.Text;

    public class Table: Furniture, ITable
    {
        private decimal length;
        private decimal width;
        public Table(string model, string material, decimal price, decimal height, decimal length, decimal width)
            :base(model, material, price, height)
        {
            this.Length = length;
            this.Width = width;
        }
        public decimal Length
        {
            get
            {
                return this.length;
            }
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException("the length cannot be less, nor equal to 0");
                }
            }
        }

        public decimal Width
        {
            get
            {
                return this.width;
            }
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException("the width cannot be less, nor equal to 0");
                }
            }
        }

        public decimal Area
        {
            get
            {
                return this.Width * this.Length;
            }
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append(base.ToString() + ", Length: " + this.Length + ", Width: " + this.Width + ", Area: " + this.Area);

            return sb.ToString();
        }
    }
}
