using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using VendingMachine.Domain.Entities;
using VendingMachine.Application.Test.Repositories;
using VendingMachine.Application.Test.ValueObjects;
using VendingMachine.Domain.ValueObjects;
using VendingMachine.Domain.Exceptions;

namespace VendingMachine.Core.Test
{
    public class ProductsTest
    {
        ProductsService _productsService;
        UserWallet _userWallet;
        MachineWallet _machineWallet;

        [SetUp]
        public void Setup()
        {
            _userWallet = new UserWallet();
            _machineWallet = new MachineWallet();
        }

        private ProductsService GetService(List<Product> products)
        {
            return new ProductsService(new ProductsTestRepository().Seed(products), _userWallet, _machineWallet);
        }

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

            _userWallet.AddCoin(1);
            _userWallet.AddCoin(0.20m);
            _userWallet.AddCoin(0.10m);
            var products = new List<Product>();
            products.Add(new Product(1, "Tea", 1.30m, INITIAL_QUANTITY));

            _productsService = GetService(products);
            _productsService.Take(1);

            Assert.AreEqual(expected: INITIAL_QUANTITY - 1, products.First().Quantity);
        }

        [Test]
        public void TakeProduct_NotAvailableBecauseOfQuantity()
        {
            _userWallet.AddCoin(1);
            _userWallet.AddCoin(0.20m);
            _userWallet.AddCoin(0.10m);
            var products = new List<Product>();
            products.Add(new Product(1, "Tea", 1.30m, 0));

            _productsService = GetService(products);
            try
            {
                _productsService.Take(1);
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
            _userWallet.AddCoin(1);
            var products = new List<Product>();
            products.Add(new Product(1, "Tea", 1.30m, 0));

            _productsService = GetService(products);
            try
            {
                _productsService.Take(1);
                Assert.Fail($"It was expected for the product to do not be available.");
            }
            catch (ProductNotAllowedException)
            {
                Assert.Pass();
            }
        }
    }
}
