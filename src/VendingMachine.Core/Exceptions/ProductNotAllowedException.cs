using System;

namespace VendingMachine.Core.Exceptions
{
    public class ProductNotAllowedException : Exception
    {
        public ProductNotAllowedException(string message) : base(message)
        {

        }
    }
}
