using System;
using System.Collections.Generic;
using System.Text;

namespace VendingMachine.Domain.ValueObjects.Interfaces
{
    public interface IWallet
    {
        decimal AddCoin(decimal coin);
        decimal GetAmount();
        List<decimal> Coins { get; }

        decimal RemoveAllCoins();
        decimal RemoveCoin(decimal coin);
        List<decimal> RetrieveCoinsFor(decimal value);
    }
}
