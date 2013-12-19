using System.Collections.Generic;
using System.Linq;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using ShoppingCart.Core;
using ShoppingCart.Core.ResolverStrategy;

namespace ShoppingCartUnitTests.ResolverStrategyUnitTests
{
    [TestClass]
    public class HeaviestFirstResolverStrategyUnitTests
    {
        [TestMethod]
        public void ResolveSuitableProducts_EmptySource_Empty()
        {
            var products = new List<Product>();

            var strategy = new HeaviestFirstResolverStrategy();
            var result = strategy.ResolveSuitableProducts(products, 20).ToList();

            Assert.AreEqual(0, result.Count);
        }

        [TestMethod]
        public void ResolveSuitableProducts_SourceUnSorted_Correct()
        {
            var products = new[]
            {
                new Product("productA", 10.0),
                new Product("productB", 1.0),
                new Product("productA2", 3.0),
                new Product("productC", 5.0),
                new Product("productD", 17.0),
                new Product("productE", 6.0)
            };

            var strategy = new HeaviestFirstResolverStrategy();
            var result = strategy.ResolveSuitableProducts(products, 20).ToList();

            Assert.AreEqual(2, result.Count);
            Assert.AreEqual("productD", result[0].Name);
            Assert.AreEqual("productA2", result[1].Name);
        }

        [TestMethod]
        public void ResolveSuitableProducts_SourceSorted_Correct()
        {
            var products = new[]
            {
                new Product("productA", 17.0),
                new Product("productB", 1.0),
                new Product("productC", 0.2),
            };

            var strategy = new HeaviestFirstResolverStrategy();
            var result = strategy.ResolveSuitableProducts(products, 20).ToList();

            Assert.AreEqual(3, result.Count);
            Assert.AreEqual("productA", result[0].Name);
            Assert.AreEqual("productB", result[1].Name);
            Assert.AreEqual("productC", result[2].Name);
        }

        [TestMethod]
        public void ResolveSuitableProducts_AllSourceProductsAreHeavy_Empty()
        {
            var products = new[]
            {
                new Product("productA", 17.0),
                new Product("productB", 10.0),
                new Product("productC", 10.2),
            };

            var strategy = new HeaviestFirstResolverStrategy();
            var result = strategy.ResolveSuitableProducts(products, 5).ToList();

            Assert.AreEqual(0, result.Count);
        }

        [TestMethod]
        public void ResolveSuitableProducts_ProductsWithSameWeight_SaveOrder()
        {
            var products = new[]
            {
                new Product("productA", 5.0),
                new Product("productB", 5.0),
                new Product("productC", 3.2),
            };

            var strategy = new HeaviestFirstResolverStrategy();
            var result = strategy.ResolveSuitableProducts(products, 20).ToList();

            Assert.AreEqual(3, result.Count);
            Assert.AreEqual("productA", result[0].Name);
            Assert.AreEqual("productB", result[1].Name);
            Assert.AreEqual("productC", result[2].Name);
        }
    }
}