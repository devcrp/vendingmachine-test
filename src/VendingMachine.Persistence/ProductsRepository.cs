using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VendingMachine.Core.Interfaces;
using VendingMachine.Domain.Entities;

namespace VendingMachine.Persistence
{
    public class ProductsRepository : IProductsRepository
    {
        static List<Product> _products = new List<Product>();

        public ProductsRepository()
        {
            if (!_products.Any())
            {
                _products.Add(new Product(1, "Tea", 1.30m, 10));
                _products.Add(new Product(2, "Espresso", 1.80m, 20));
                _products.Add(new Product(3, "Juice", 1.80m, 20));
                _products.Add(new Product(4, "Chicken soup", 1.80m, 15));
            }
        }
        

        public IEnumerable<Product> GetList()
        {
            return _products;
        }

        public Product GetSingle(int id)
        {
            return _products.Single(product => product.Id == id);
        }
    }
}
