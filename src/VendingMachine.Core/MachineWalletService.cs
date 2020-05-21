using VendingMachine.Core.Base;
using VendingMachine.Core.Options;
using VendingMachine.Domain.Interfaces;

namespace VendingMachine.Core
{
    /// <summary>
    /// Class to hold the instance for the vending machine wallet. This instance will have a default initial list of coins.
    /// </summary>
    public class MachineWalletService : BaseWallet, IWalletService
    {
        public MachineWalletService(WalletDefaultOptions options) : base(options)
        {

        }
    }
}
