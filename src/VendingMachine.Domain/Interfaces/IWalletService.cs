using System.Collections.Generic;

namespace VendingMachine.Domain.Interfaces
{
    public interface IWalletService
    {
        decimal AddCoin(decimal coin);
        decimal RemoveAllCoins();
        decimal GetAmount();
        List<decimal> GetCoins();
        decimal RemoveCoin(decimal coin);
    }
}
