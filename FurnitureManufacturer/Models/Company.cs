using FurnitureManufacturer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FurnitureManufacturer.Models
{
    public class Company : ICompany
    {
        private string name;
        private string registrationNumber;
        private ICollection<IFurniture> furnitures; // TODO interface in field hmm WTF??

        public Company(string name, string regNum)
        {
            this.Name = name;
            this.RegistrationNumber = regNum;
            this.Furnitures = new List<IFurniture>();
        }

        public string Name
        {
            get { return this.name; }
            private set 
            {
                if (value.Length < 5 || string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Name cannot be empty, null or with less than 5 symbols.");
                }
                this.name = value;
            }
        }

        public string RegistrationNumber
        {
            get { return this.registrationNumber; }
            private set // IDEA: CAST TO INT, or simplea foreach with IsDigit
            {
                if (value.Length != 10 || value.Any(c => c < '0' || c > '9'))
                {
                    throw new ArgumentException("Registration number must be exactly 10 symbols and must contain only digits.");
                }
                this.registrationNumber = value;
            }
        }

        public ICollection<IFurniture> Furnitures
        {
            get
            {
                //if (this.furnitures == null)
                //{
                //    this.furnitures = new Collection<Furniture>() as ICollection<IFurniture>;
                //    //throw new ArgumentNullException("no furnitures!!!!!");
                //}
                return this.furnitures;
            }
            set
            {
                this.furnitures = value;
            }
        }

        public void Add(IFurniture furniture)
        {
            this.Furnitures.Add(furniture);
            this.Furnitures = this.Furnitures.OrderBy(f => f.Price).ThenBy(f => f.Model).ToList();
        }

        public void Remove(IFurniture furniture)
        {
            this.Furnitures.Remove(furniture); // returns false if not found
        }

        public IFurniture Find(string model) // keep an eye on this....
        {
            IFurniture foundFurniture;
            if (this.Furnitures.Any(f => f.Model.ToLowerInvariant() == model.ToLowerInvariant()))
            {
                foundFurniture = this.Furnitures.First(f => f.Model.ToLowerInvariant() == model.ToLowerInvariant());
                return foundFurniture;
            }
            else
                return null;
        }

        public string Catalog()
        {
            var sb = new StringBuilder();

            sb.AppendFormat("{0} - {1} - {2} {3}",
                    this.Name,
                    this.RegistrationNumber,
                    this.Furnitures.Count != 0 ? this.Furnitures.Count.ToString() : "no",
                    this.Furnitures.Count != 1 ? "furnitures" : "furniture");
            if (this.Furnitures.Count > 0)
            {
                foreach (var furn in this.Furnitures)
                {
                    sb.Append("\n");
                    sb.Append(furn.ToString()); 
                }
            }

            return sb.ToString();
        }
    }
}
