using System;
using System.Collections.Generic;
using System.Text;
using VendingMachine.Domain.ValueObjects.Interfaces;

namespace VendingMachine.Core.Base
{
    /// <summary>
    /// Base wallet service with all the common logic to contact with the domain.
    /// </summary>
    public class BaseWalletService
    {
        private readonly IWallet _wallet;

        public BaseWalletService(IWallet wallet)
        {
            this._wallet = wallet;
        }

        public decimal GetAmount() => _wallet.GetAmount();

        public decimal AddCoin(decimal value) => _wallet.AddCoin(value);

        public decimal RemoveAllCoins() => _wallet.RemoveAllCoins();

        public List<decimal> GetCoins() => _wallet.Coins;

        public decimal RemoveCoin(decimal coin) => _wallet.RemoveCoin(coin);

        public List<decimal> RetrieveCoinsFor(decimal value) => _wallet.RetrieveCoinsFor(value);
    }
}
