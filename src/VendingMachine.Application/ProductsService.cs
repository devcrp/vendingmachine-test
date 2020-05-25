using System.Collections.Generic;
using System.Linq;
using VendingMachine.Core.Interfaces;
using VendingMachine.Domain.Entities;
using VendingMachine.Domain.Exceptions;
using VendingMachine.Domain.ValueObjects;

namespace VendingMachine.Core
{
    public class ProductsService
    {
        private readonly IProductsRepository _productsRepository;
        private readonly UserWallet _userWallet;
        private readonly MachineWallet _machineWallet;

        public ProductsService(IProductsRepository productsRepository, UserWallet userWallet, MachineWallet machineWallet)
        {
            this._productsRepository = productsRepository;
            this._userWallet = userWallet;
            this._machineWallet = machineWallet;
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
        public List<decimal> Take(int productId)
        {
            Product product = _productsRepository.GetSingle(productId);
            decimal change = product.TakeOne(_userWallet.GetAmount());

            // Add user's coins into the machine wallet.
            _userWallet.Coins.ForEach(userCoin => _machineWallet.AddCoin(userCoin));

            List<decimal> changeCoins = _machineWallet.RetrieveCoinsFor(change);

            _userWallet.RemoveAllCoins();

            return changeCoins;
        }
    }
}
