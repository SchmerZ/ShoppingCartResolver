using System;
using System.Collections.Generic;

using ShoppingCart.Core;
using ShoppingCart.Core.ResolverStrategy;

namespace ShoppingCartResolverDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            var cart = InputShoppingCartItems();

            Console.WriteLine("your shopping cart:");
            DumpProducts(cart.Items);

            var weightLimit = InputWeightLimitValue();

            Console.WriteLine("\nApplying shopping cart items resolver strategy...");
            ResolveShoppingCartItems(cart, weightLimit);

            Console.ReadKey();
        }

        private static void ResolveShoppingCartItems(ShoppingCart.Core.ShoppingCart cart, double limit)
        {
            var result = cart.ResolveSuitableProducts(new HeaviestFirstResolverStrategy(), limit);

            Console.WriteLine("Result:");
            DumpProducts(result);
        }

        private static void DumpProducts(IEnumerable<Product> products)
        {
            foreach (var product in products)
            {
                Console.WriteLine(product.ToString());
            }
        }

        private static ShoppingCart.Core.ShoppingCart InputShoppingCartItems()
        {
            Console.WriteLine("Please enter products (in name (string) - weight (double) format)..");

            var shoppingCart = new ShoppingCart.Core.ShoppingCart();

            while (true)
            {
                var consoleLine = Console.ReadLine();

                if (string.IsNullOrEmpty(consoleLine))
                    break;

                var product = ParseInputToProduct(consoleLine);
                if (product != null)
                    shoppingCart.Items.Add(product);
            }

            return shoppingCart;
        }

        private static Product ParseInputToProduct(string line)
        {
            var values = line.Split('-');

            if (values.Length != 2)
            {
                Console.WriteLine("Incorrect product format. Try again please.");
                return null;
            }

            var weight = 0.0;
            if (TryParseDouble(values[1], out weight))
                return new Product(values[0].Trim(), weight);

            Console.WriteLine("incorrect weight value.");

            return null;
        }

        private static double InputWeightLimitValue()
        {
            Console.WriteLine("\nPlease enter the weight limit:");

            while (true)
            {
                var line = Console.ReadLine();

                if (string.IsNullOrEmpty(line))
                {
                    Console.WriteLine("Empty line. Try again please.");
                }
                else
                {
                    double inputWeightLimitValue;
                    if (TryParseDouble(line, out inputWeightLimitValue))
                        return inputWeightLimitValue;
                }
            }
        }

        private static bool TryParseDouble(string line, out double result)
        {
            if (double.TryParse(line, out result))
            {
                if (result <= 0)
                    Console.WriteLine("Values should be positive.");
                else
                    return true;
            }
            else
                Console.WriteLine("Invalid value.");

            return false;
        }
    }
}