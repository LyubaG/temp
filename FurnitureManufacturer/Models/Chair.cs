
namespace FurnitureManufacturer.Models
{
    using FurnitureManufacturer.Interfaces;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Chair : Furniture, IChair, IFurniture
    {
        private int numOfLegs;

        public Chair(string model, string material, decimal price, decimal height, int numLegs)
            : base(model, material, price, height)
        {
            this.NumberOfLegs = numLegs;
        }

        public int NumberOfLegs
        {
            get { return this.numOfLegs; }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("You can't sit in negative space.");
                }
                this.numOfLegs = value;
            }
        }

        public override string ToString()
        {
            return string.Format("Type: {0}, Model: {1}, Material: {2}, Price: {3}, Height: {4}, Legs: {5}", 
                this.GetType().Name, this.Model, this.Material, this.Price, this.Height, this.NumberOfLegs);
        }
    }
}
