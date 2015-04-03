namespace FurnitureManufacturer.Models
{
    using FurnitureManufacturer.Interfaces;

    public class Table : Furniture, ITable, IFurniture
    {
        private decimal length;
        private decimal width;

        public Table(string model, string material, decimal price, decimal height, decimal length, decimal width)
            : base(model, material, price, height)
        {
            this.Length = length;
            this.Width = width;
        }

        public decimal Width
        {
            get { return this.width; }
            private set { this.width = value; }
        }

        public decimal Length
        {
            get { return this.length; }
            private set { this.length = value; }
        }

        public decimal Area // TODO field?
        {
            get { return (this.Length * this.Width); }
        }

        public override string ToString()
        {
            return string.Format("Type: {0}, Model: {1}, Material: {2}, Price: {3}, Height: {4}, Length: {5}, Width: {6}, Area: {7}", 
            this.GetType().Name, this.Model, this.Material, this.Price, this.Height,  this.Length, this.Width, this.Area);
        }

    }
}
