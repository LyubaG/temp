using FurnitureManufacturer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FurnitureManufacturer.Models
{
    public class AdjustableChair : Chair, IFurniture, IChair, IAdjustableChair
    {
        public AdjustableChair(string model, string material, decimal price, decimal height, int numLegs)
            : base(model, material, price, height, numLegs)
        {
        } // TODO better inheritance for constructor?

        public void SetHeight(decimal height)
        {
            this.Height = height;
        }
        // tostring - from Chair inheritance..so ok?
    }
}
