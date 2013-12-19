using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ShoppingCart.Core;

namespace ShoppingCartUnitTests
{
    [TestClass]
    public class ProductUnitTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Create_NegativeWeight_Exception()
        {
            new Product("test", -100);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Create_ZeroWeight_Exception()
        {
            new Product("test", 0);
        }

        [TestMethod]
        public void Create_CorrectValues_Created()
        {
            var product = new Product("test", 0.0001);

            Assert.AreEqual("test", product.Name);
            Assert.AreEqual(0.0001, product.Weight);
        }
    }
}