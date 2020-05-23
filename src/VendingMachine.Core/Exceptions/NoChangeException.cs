using System;

namespace VendingMachine.Core.Exceptions
{
    public class NoChangeException : Exception
    {
        public NoChangeException() : base("There are not enough coins for your change.")
        {

        }
    }
}
