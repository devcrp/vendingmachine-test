using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using VendingMachine.Core;
using VendingMachine.Domain.Entities;
using VendingMachine.Domain.Exceptions;

namespace VendingMachine.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly ProductsService _productsService;
        private readonly UserWalletService _userWalletService;
        private readonly MachineWalletService _machineWalletService;

        public ProductsController(ProductsService productsService, UserWalletService userWalletService, MachineWalletService machineWalletService)
        {
            this._productsService = productsService;
            this._userWalletService = userWalletService;
            this._machineWalletService = machineWalletService;
        }

        /// <summary>
        /// Gets a list of all the stock products.
        /// </summary>
        /// <returns></returns>
        // GET: api/Products
        [HttpGet]
        public IEnumerable<Product> Get()
        {
            return _productsService.GetList();
        }

        /// <summary>
        /// Takes on unit of a given product. I also validates if the product is available and if the user amount is enough.
        /// </summary>
        /// <param name="id">Id of the product</param>
        /// <returns></returns>
        // POST: api/Products/1 [body: 1,80]
        [HttpPost("take/{id}")]
        public ActionResult<List<decimal>> Take(int id)
        {
            try
            {
                return _productsService.Take(id);
            }
            catch (ProductNotAllowedException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (NoChangeException ex)
            {
                _userWalletService.GetCoins().ForEach(coin => _machineWalletService.RemoveCoin(coin));
                _userWalletService.RemoveAllCoins();

                return BadRequest(ex.Message);
            }
        }
    }
}
