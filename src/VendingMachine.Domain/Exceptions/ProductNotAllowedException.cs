using System;

namespace VendingMachine.Domain.Exceptions
{
    public class ProductNotAllowedException : Exception
    {
        public ProductNotAllowedException(string message) : base(message)
        {

        }
    }
}
