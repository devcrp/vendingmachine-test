using System;
using System.Collections.Generic;
using System.Text;
using VendingMachine.Domain.ValueObjects.Base;
using VendingMachine.Domain.ValueObjects.Interfaces;
using VendingMachine.Domain.ValueObjects.Options;

namespace VendingMachine.Domain.ValueObjects
{
    /// <summary>
    /// This class represents the wallet for the vending machine.
    /// </summary>
    public class MachineWallet : BaseWallet, IWallet
    {
        public MachineWallet Options(Action<WalletDefaultOptions> action)
        {
            WalletDefaultOptions options = new WalletDefaultOptions();
            action.Invoke(options);

            if (options != null && options.Coins != null) Coins = options.Coins;

            return this;
        }
    }
}
