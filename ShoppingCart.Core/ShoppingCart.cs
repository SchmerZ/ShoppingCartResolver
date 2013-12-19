using System;
using System.Collections.Generic;
using ShoppingCart.Core.ResolverStrategy;

namespace ShoppingCart.Core
{
    public class ShoppingCart
    {
        #region Ctors
        
        public ShoppingCart()
        {
            Items = new List<Product>();
        } 

        #endregion

        public List<Product> Items
        {
            get; 
            private set;
        }

        public IEnumerable<Product> ResolveSuitableProducts(IResolverStrategy strategy, double weightLimit)
        {
            if (strategy == null)
                throw new ArgumentNullException("strategy");

            return strategy.ResolveSuitableProducts(Items, weightLimit);
        }
    }
}