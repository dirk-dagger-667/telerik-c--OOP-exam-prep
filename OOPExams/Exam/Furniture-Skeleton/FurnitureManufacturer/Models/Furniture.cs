namespace FurnitureManufacturer.Models
{
    using FurnitureManufacturer.Interfaces;
    using System;
    using System.Text;
    public class Furniture: IFurniture
    {
        private decimal price;
        private decimal height;
        private MaterialType material;
        private string model;
        internal Furniture(string model, string material, decimal price, decimal height)
        {
            this.Model = model;
            this.Material = material;
            this.Price = price;
            this.Height = height;
        }
        public string Model
        {
            get
            {
                return this.model;
            }
            protected set
            {
                if (value == null || value == string.Empty || value.Length < 3)
                {
                    throw new ArgumentException("the model of the furniture cannot be null, empty or less than 3 symbols");
                }

                this.model = value;
            }
        }

        public string Material
        {
            get
            {
                return this.material.ToString();
            }
            protected set
            {
                switch (value)
                {
                    case "wooden":
                        this.material = MaterialType.Wooden;
                        break;
                    case "plastic":
                        this.material = MaterialType.Plastic;
                        break;
                    case "leather":
                        this.material = MaterialType.Leather;
                        break;
                    default:
                        break;
                }
            }
        }

        public decimal Price
        {
            get
            {
                return this.price;
            }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException("the price cannot be less, nor equal to 0.00");
                }

                this.price = value;
            }
        }

        public decimal Height
        {
            get
            {
                return this.height;
            }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException("the height cannot be less, nor equal 0");
                }
            }
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("Type: " + this.GetType().Name + ", Molel: " + this.Model + ", Material: " + this.Material.ToString() + ", Price: " + this.Price +
                ", Hieght: " + this.Height);

            return sb.ToString();
        }
    }
}
