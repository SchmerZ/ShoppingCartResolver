using System.Collections.Generic;
using System.Linq;

namespace ShoppingCart.Core.ResolverStrategy
{
    public class HeaviestFirstResolverStrategy : IResolverStrategy
    {
        public IEnumerable<Product> ResolveSuitableProducts(IEnumerable<Product> source, double weightLimit)
        {
            var freeSpace = weightLimit;
            var items = source.OrderByDescending(o => o.Weight);
            
            foreach (var item in items)
            {
                if (freeSpace <= 0)
                    yield break;

                if (item.Weight <= freeSpace)
                {
                    freeSpace -= item.Weight;

                    yield return item;
                }
            }
        }
    }
}