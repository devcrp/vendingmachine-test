
using VendingMachine.Core.Base;
using VendingMachine.Domain.ValueObjects;

namespace VendingMachine.Core
{
    public class MachineWalletService : BaseWalletService
    {
        public MachineWalletService(MachineWallet machineWallet) : base(machineWallet)
        {
            
        }
    }
}
