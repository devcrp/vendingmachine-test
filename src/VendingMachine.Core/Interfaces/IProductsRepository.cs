using System;
using System.Collections.Generic;
using System.Text;
using VendingMachine.Domain.Entities;

namespace VendingMachine.Core.Interfaces
{
    public interface IProductsRepository
    {
        IEnumerable<Product> GetList();

        Product GetSingle(int id);
    }
}
