namespace FurnitureManufacturer.Models
{
    using FurnitureManufacturer.Interfaces;
    using System.Text;
    class ConvertableChair: Chair, IConvertibleChair
    {
        private readonly decimal convertedHeight = 0.10m;
        private decimal oldHeight;
        public ConvertableChair(string model, string material, decimal price, decimal height, int numberOfLegs)
            :base(model, material, price, height, numberOfLegs)
        {

        }
        public bool IsConverted
        {
            get;
            private set;
        }
        public void Convert()
        {
            if (this.IsConverted == true)
            {
                this.IsConverted = false;
                this.Height = this.oldHeight;
            }
            else
            {
                this.IsConverted = true;
                this.oldHeight = this.Height;
                this.Height = this.convertedHeight;
            }
        }
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append(base.ToString() + ", State: ");

            if (this.IsConverted == true)
            {
                sb.Append("Converted");
            }
            else
            {
                sb.Append("Normal");
            }

            return sb.ToString();
        }
    }
}
