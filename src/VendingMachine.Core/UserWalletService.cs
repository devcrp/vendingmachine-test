using VendingMachine.Core.Base;
using VendingMachine.Domain.ValueObjects;

namespace VendingMachine.Core
{
    /// <summary>
    /// Class to hold the instance for the user's wallet. This instance will NOT have a default initial list of coins.
    /// </summary>
    public class UserWalletService : BaseWalletService
    {
        public UserWalletService(UserWallet userWallet) : base(userWallet)
        {

        }
    }
}
