using System;

namespace ShoppingCart.Core
{
    public class Product
    {
        #region Ctors

        public Product(string name, double weight)
        {
            if (weight <= 0)
                throw new ArgumentException("Weight should be positive double number.");

            Name = name;
            Weight = weight;
        }

        #endregion
        
        public string Name
        {
            get; 
            set;
        }

        public double Weight
        {
            get; 
            set;
        }

        public override string ToString()
        {
            return string.Format("{0}; Weight: {1}", Name, Weight);
        }
    }
}