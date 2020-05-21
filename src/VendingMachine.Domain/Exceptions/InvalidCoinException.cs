using System;

namespace VendingMachine.Domain.Exceptions
{
    public class InvalidCoinException : Exception
    {
        public InvalidCoinException(decimal value) : base($"There is no valid coin with value {value}.")
        {

        }
    }
}
