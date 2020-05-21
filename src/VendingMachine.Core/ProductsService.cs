using System.Collections.Generic;
using System.Linq;
using VendingMachine.Core.Options;
using VendingMachine.Domain.Exceptions;
using VendingMachine.Domain.Interfaces;
using VendingMachine.Domain.Models;

namespace VendingMachine.Core
{
    public class ProductsService : IProductsService
    {
        private readonly UserWalletService _userWalletService;
        private List<Product> _products;

        public ProductsService(ProductDefaultOptions options, UserWalletService userWalletService)
        {
            _products = options.Products;
            this._userWalletService = userWalletService;
        }

        /// <summary>
        /// Gets the current list of products.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Product> GetList()
        {
            return _products;
        }

        /// <summary>
        /// Takes one unit of the given product. It validates if there's at least one unit available and if the current user's wallet amount is enough to buy it.
        /// It also removes one unit from the quantity.
        /// </summary>
        /// <param name="productId"></param>
        /// <param name="amount"></param>
        /// <returns></returns>
        public decimal Take(int productId, decimal amount)
        {
            Product product = _products.Single(product => product.Id == productId);

            if (product.Quantity <= 0)
                throw new ProductNotAllowedException("Product not available.");

            if (product.Price > amount)
                throw new ProductNotAllowedException($"Insufficient amount. The price for {product.Name} is {product.Price}€");

            product.Quantity--;

            return amount - product.Price;
        }
    }
}
