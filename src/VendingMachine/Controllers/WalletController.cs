using Microsoft.AspNetCore.Mvc;
using VendingMachine.Core;

namespace VendingMachine.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WalletController : ControllerBase
    {
        private readonly UserWalletService _userWalletService;

        public WalletController(UserWalletService userWalletService)
        {
            this._userWalletService = userWalletService;
        }

        /// <summary>
        /// Gets the current amount in the user's wallet.
        /// </summary>
        /// <returns></returns>
        // GET: api/Wallet
        [HttpGet]
        public ActionResult<decimal> Get()
        {
            return _userWalletService.GetAmount();
        }

        /// <summary>
        /// Adds a coin of the given value to the user's wallet.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        // POST: api/Wallet
        [HttpPost]
        public ActionResult<decimal> Post([FromBody] decimal value)
        {
            return _userWalletService.AddCoin(value);
        }

        /// <summary>
        /// Removes and returns all the coins in the user's wallet.
        /// </summary>
        /// <returns></returns>
        // DELETE: api/Wallet
        [HttpDelete]
        public ActionResult<decimal> Delete()
        {
            return _userWalletService.RemoveAllCoins();
        }
    }
}
