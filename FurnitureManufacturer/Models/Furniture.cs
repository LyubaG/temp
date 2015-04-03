namespace FurnitureManufacturer.Models
{
    using FurnitureManufacturer.Interfaces;
    using System;

    public abstract class Furniture : IFurniture
    {
        private string model;
        private string material;
        private decimal price;
        private decimal height;

        protected Furniture(string model, string material, decimal price, decimal height)
        {
            this.Model = model;
            this.Material = material;
            this.Price = price;
            this.Height = height;        
        }

        public decimal Height
        {
            get { return this.height; }
            set
            {
                if (value <= 0.00m)
                {
                    throw new ArgumentOutOfRangeException("The height can't be 0 or negative.");
                }
                this.height = value;
            }
        }

        public decimal Price
        {
            get { return this.price; }
            set
            {
                if (value <= 0.00m)
                {
                    throw new ArgumentOutOfRangeException("The price can't be 0 or negative.");
                }
                this.price = value;
            }
        }

        public string Material
        {
            get { return this.material; }
            protected set { this.material = value; }
        }

        public string Model
        {
            get { return this.model; }
            protected set
            {
                if (value.Length < 3 || string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Model has to have more than 3 symbols.");
                }
                this.model = value;
            }
        }
    }
}
