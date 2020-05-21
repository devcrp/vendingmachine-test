using System.Collections.Generic;
using VendingMachine.Domain.Models;

namespace VendingMachine.Domain.Interfaces
{
    public interface IProductsService
    {
        IEnumerable<Product> GetList();
        decimal Take(int productId, decimal amount);
    }
}
