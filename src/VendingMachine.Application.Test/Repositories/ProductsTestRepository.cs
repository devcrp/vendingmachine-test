using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VendingMachine.Core.Interfaces;
using VendingMachine.Domain.Entities;

namespace VendingMachine.Application.Test.Repositories
{
    public class ProductsTestRepository : IProductsRepository
    {
        private List<Product> _products = new List<Product>();

        public IEnumerable<Product> GetList()
        {
            return _products;
        }

        public Product GetSingle(int id)
        {
            return _products.Single(product => product.Id == id);
        }

        public ProductsTestRepository Seed(List<Product> data)
        {
            _products.AddRange(data);
            return this;
        }
    }
}
