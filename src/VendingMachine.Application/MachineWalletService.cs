
using VendingMachine.Core.Base;
using VendingMachine.Domain.ValueObjects;

namespace VendingMachine.Core
{
    /// <summary>
    /// This class represents the wallet service for the vending machine.
    /// </summary>
    public class MachineWalletService : BaseWalletService
    {
        public MachineWalletService(MachineWallet machineWallet) : base(machineWallet)
        {
            
        }
    }
}
