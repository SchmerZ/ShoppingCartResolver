using System.Collections.Generic;

namespace ShoppingCart.Core.ResolverStrategy
{
    public interface IResolverStrategy
    {
        IEnumerable<Product> ResolveSuitableProducts(IEnumerable<Product> source, double weightLimit);
    }
}