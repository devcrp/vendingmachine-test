using VendingMachine.Core.Base;
using VendingMachine.Domain.ValueObjects;

namespace VendingMachine.Core
{
    /// <summary>
    /// This class represents the wallet service for the user.
    /// </summary>
    public class UserWalletService : BaseWalletService
    {
        public UserWalletService(UserWallet userWallet) : base(userWallet)
        {

        }
    }
}
