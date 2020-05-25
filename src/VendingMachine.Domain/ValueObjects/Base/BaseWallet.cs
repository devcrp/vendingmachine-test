using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VendingMachine.Domain.Exceptions;
using VendingMachine.Domain.ValueObjects.Interfaces;
using VendingMachine.Domain.ValueObjects.Options;

namespace VendingMachine.Domain.ValueObjects.Base
{
    /// <summary>
    /// Base wallet object to contain all the shared logic between wallets.
    /// </summary>
    public class BaseWallet
    {
        private static decimal[] VALID_COINS = new decimal[] { 2, 1, 0.5m, 0.2m, 0.1m, 0.05m };
        public List<decimal> Coins { get; protected set; } = new List<decimal>();

        /// <summary>
        /// Adds a coin of the given value into the current wallet.
        /// </summary>
        /// <param name="coin"></param>
        /// <returns></returns>
        public decimal AddCoin(decimal coin)
        {
            if (!IsValid(coin))
                throw new InvalidCoinException(coin);

            Coins.Add(coin);
            return GetAmount();
        }

        /// <summary>
        /// Removes a coin of the given value from the wallet.
        /// </summary>
        /// <param name="coin"></param>
        /// <returns></returns>
        public decimal RemoveCoin(decimal coin)
        {
            RemoveCoin(Coins, coin);
            return GetAmount();
        }

        /// <summary>
        /// Gets the current amount in the wallet.
        /// </summary>
        /// <returns></returns>
        public decimal GetAmount() => Coins.Sum(coin => coin);

        /// <summary>
        /// Empties the wallet.
        /// </summary>
        /// <returns></returns>
        public decimal RemoveAllCoins()
        {
            Coins.Clear();
            return 0;
        }

        /// <summary>
        /// For the given value, returns the minimum amount of coins available from the wallet and removes them from it.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public List<decimal> RetrieveCoinsFor(decimal value)
        {
            List<decimal> coins = new List<decimal>();
            List<decimal> currentCoinsCopy = CloneCoinsList();

            decimal coinsAmount = 0;
            foreach (decimal coin in VALID_COINS)
            {
                if (!currentCoinsCopy.Contains(coin))
                    continue;

                int numberOfCoins = Convert.ToInt32(Math.Floor((value - coinsAmount) / coin));
                if (numberOfCoins > 0)
                {
                    int count = Math.Min(currentCoinsCopy.Count(c => c == coin), numberOfCoins);
                    Enumerable.Range(1, count)
                            .ToList()
                            .ForEach(i =>
                            {
                                coins.Add(coin);
                                RemoveCoin(currentCoinsCopy, coin);
                            });

                    coinsAmount = coins.Sum();
                    if (coinsAmount == value)
                        break;
                }
            }

            if (coins.Sum() != value)
                throw new NoChangeException();

            Coins = currentCoinsCopy;

            return coins;
        }

        /// <summary>
        /// Helper method that checks if a given coin value is valid.
        /// </summary>
        /// <param name="coin"></param>
        /// <returns></returns>
        private bool IsValid(decimal coin) => VALID_COINS.Contains(coin);

        /// <summary>
        /// Helper method to make a copy of the coins list to manipulate it.
        /// </summary>
        /// <returns></returns>
        private List<decimal> CloneCoinsList()
        {
            List<decimal> copy = new List<decimal>();
            copy.AddRange(Coins);
            return copy;
        }

        /// <summary>
        /// Helper method to remove a coin from a given list of coins.
        /// </summary>
        /// <param name="coins"></param>
        /// <param name="coin"></param>
        private void RemoveCoin(List<decimal> coins, decimal coin)
        {
            int idx = coins.IndexOf(coin);
            if (idx >= 0) coins.RemoveAt(idx);
        }
    }
}
