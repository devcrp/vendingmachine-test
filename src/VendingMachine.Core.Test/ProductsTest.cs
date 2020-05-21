using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using VendingMachine.Core.Options;
using VendingMachine.Domain.Exceptions;
using VendingMachine.Domain.Models;

namespace VendingMachine.Core.Test
{
    public class ProductsTest
    {
        ProductsService _productsService;

        [SetUp]
        public void Setup()
        {

        }

        private ProductsService GetService(List<Product> products) => new ProductsService(new ProductDefaultOptions
        {
            Products = products
        }, new UserWalletService());

        [Test]
        public void GetList_ReturnsSameCount()
        {
            var products = new List<Product>();
            products.Add(new Product(1, "Tea", 1.30m, 10));
            products.Add(new Product(2, "Espresso", 1.80m, 20));
            products.Add(new Product(3, "Juice", 1.80m, 20));
            products.Add(new Product(4, "Chicken soup", 1.80m, 15));

            _productsService = GetService(products);
            IEnumerable<Product> list = _productsService.GetList();

            Assert.AreEqual(expected: products.Count, list.Count());
        }

        [Test]
        public void TakeProduct_SubstractsQuantity()
        {
            const int INITIAL_QUANTITY = 10;
            const decimal PRICE = 1.30M;
            var products = new List<Product>();
            products.Add(new Product(1, "Tea", PRICE, INITIAL_QUANTITY));

            _productsService = GetService(products);
            _productsService.Take(1, PRICE);

            Assert.AreEqual(expected: INITIAL_QUANTITY - 1, products.First().Quantity);
        }

        [Test]
        public void TakeProduct_NotAvailableBecauseOfQuantity()
        {
            const decimal PRICE = 1.30M;
            var products = new List<Product>();
            products.Add(new Product(1, "Tea", PRICE, 0));

            _productsService = GetService(products);
            try
            {
                _productsService.Take(1, PRICE);
                Assert.Fail($"It was expected for the product to do not be available.");
            }
            catch (ProductNotAllowedException)
            {
                Assert.Pass();
            }
        }

        [Test]
        public void TakeProduct_NotAvailableBecauseOfPrice()
        {
            const decimal PRICE = 1.30M;
            var products = new List<Product>();
            products.Add(new Product(1, "Tea", PRICE, 0));

            _productsService = GetService(products);
            try
            {
                _productsService.Take(1, PRICE / 2);
                Assert.Fail($"It was expected for the product to do not be available.");
            }
            catch (ProductNotAllowedException)
            {
                Assert.Pass();
            }
        }
    }
}
