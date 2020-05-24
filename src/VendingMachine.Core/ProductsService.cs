using System.Collections.Generic;
using System.Linq;
using VendingMachine.Core.Interfaces;
using VendingMachine.Domain.Entities;
using VendingMachine.Domain.Exceptions;

namespace VendingMachine.Core
{
    public class ProductsService
    {
        private readonly IProductsRepository _productsRepository;
        private readonly UserWalletService _userWalletService;

        public ProductsService(IProductsRepository productsRepository, UserWalletService userWalletService)
        {
            this._productsRepository = productsRepository;
            this._userWalletService = userWalletService;
        }

        /// <summary>
        /// Gets the current list of products.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Product> GetList()
        {
            return _productsRepository.GetList();
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
            Product product = _productsRepository.GetSingle(productId);
            return product.TakeOne(amount);
        }
    }
}
