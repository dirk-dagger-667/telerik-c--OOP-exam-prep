namespace FurnitureManufacturer.Models
{
    using FurnitureManufacturer.Interfaces;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    public class Company: ICompany
    {
        private string name;
        private string registerNumberString;
        private ICollection<IFurniture> furnitures;
        public Company(string name, string registerNumber)
        {
            this.Name = name;
            this.RegistrationNumber = registerNumber;
        }
        public string Name
        {
            get
            {
                return this.name;
            }
            private set
            {
                if (value == null || value == string.Empty || value.Length < 5)
                {
                    throw new ArgumentNullException("the name of the company cannot be null, nor empty, nor less than 5 symbols");
                }

                this.name = value;
            }
        }
        public string RegistrationNumber
        {
            get
            {
                return this.registerNumberString;
            }
            private set
            {
                if (value.Length != 10)
                {
                    throw new ArgumentOutOfRangeException("the number of digits must be exactely 10");
                }
                if (this.IsNumber(value) == false)
                {
                    throw new ArgumentException("the input is not a number");
                }

                this.registerNumberString = value;
            }
        }
        public ICollection<IFurniture> Furnitures
        {
            get
            {
                return new List<IFurniture>(this.furnitures);
            }
            private set
            {
                this.furnitures = value;
            }
        }
        public void Add(IFurniture furniture)
        {
            if (furniture == null)
            {
                throw new ArgumentNullException("Furniture cannot be null");
            }

            this.Furnitures.Add(furniture);
        }
        public void Remove(IFurniture furniture)
        {
            this.Furnitures.Remove(furniture);
        }
        public IFurniture Find(string model)
        {
            foreach (var furniture in this.Furnitures)
            {
                if (furniture.Model.ToLower() == model.ToLower())
                {
                    return furniture;
                }
            }

            return new Furniture("no such thing", "plastic", 1.99m, 1.99m);
        }
        public string Catalog()
        {
            var sb = new StringBuilder();
            sb.Append(this.Name + " - " + this.RegistrationNumber + " - ");

            if (this.Furnitures.Count == 0)
            {
                sb.Append("no furnitures");
            }
            else if (this.Furnitures.Count == 1)
            {
                sb.Append("1 furniture/r/n");
            }
            else
            {
                sb.Append(this.Furnitures.Count + " furnitures/r/n");
            }

            if (this.Furnitures.Count > 0)
            {
                foreach (var furniture in this.Furnitures)
                {
                    sb.Append(furniture + "/r/n");
                }
            }

            return sb.ToString();
        }
        private bool IsDigit(char digit)
        {
            switch (digit)
            {
                case '0':
                    return true;
                case '1':
                    return true;
                case '2':
                    return true;
                case '3':
                    return true;
                case '4':
                    return true;
                case '5':
                    return true;
                case '6':
                    return true;
                case '7':
                    return true;
                case '8':
                    return true;
                case '9':
                    return true;
                default:
                    return false;
            }
        }
        private bool IsNumber(string number)
        {
            for (int i = 0; i < number.Length; i++)
            {
                if (this.IsDigit(number[i]) == false)
                {
                    return false;
                }
            }

            return true;
        }
    }
}
