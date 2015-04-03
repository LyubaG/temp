using FurnitureManufacturer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FurnitureManufacturer.Models
{
    public class ConvertibleChair : Chair, IFurniture, IChair, IConvertibleChair
    {       
        //•	Has two states – converted and normal. Initial state is normal.
        //•	Normal state returns the height to the initial one.
	
        private readonly decimal InitialHeight;
        private bool isConverted;

        public ConvertibleChair(string model, string material, decimal price, decimal height, int numLegs)
            : base(model, material, price, height, numLegs)
        {
            this.InitialHeight = height;  
        }         

        public bool IsConverted
        {
            get { return this.isConverted; }
            private set
            {
                this.isConverted = value;
            }
        }

        public void Convert()
        {
            this.IsConverted = !IsConverted;
            if (IsConverted == true)
            {
                this.Height = 0.10m;   
            }
            else
            {
                this.Height = this.InitialHeight;
            }
        }

        public override string ToString()
        {
            return string.Format("Type: {0}, Model: {1}, Material: {2}, Price: {3}, Height: {4}, Legs: {5}, State: {6}", 
                this.GetType().Name, this.Model, this.Material, this.Price, this.Height, this.NumberOfLegs, this.IsConverted ? "Converted" : "Normal");
        }
    }
}
