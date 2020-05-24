using System;

namespace VendingMachine.Domain.Exceptions
{
    public class NoChangeException : Exception
    {
        public NoChangeException() : base("There are not enough coins for your change.")
        {

        }
    }
}
