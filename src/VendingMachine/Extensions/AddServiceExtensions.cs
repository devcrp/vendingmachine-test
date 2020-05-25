using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;
using System.Linq;
using VendingMachine.Core;
using VendingMachine.Core.Interfaces;
using VendingMachine.Domain.ValueObjects;
using VendingMachine.Domain.ValueObjects.Options;
using VendingMachine.Persistence;

namespace VendingMachine.Extensions
{
    public static class AddServiceExtensions
    {
        /// <summary>
        /// Adds the Singleton needed services.
        /// </summary>
        /// <param name="services"></param>
        public static void AddSingletonServices(this IServiceCollection services)
        {
            services.AddSingleton<IProductsRepository, ProductsRepository>();

            services.AddSingleton<UserWalletService>();
            services.AddSingleton<MachineWalletService>();
            services.AddSingleton<ProductsService>();

            services.AddSingleton<UserWallet>();
            services.AddSingleton<MachineWallet>(s => new MachineWallet().Options(o =>
            {
                o.Coins = GetMachineInitialCoins();
            }));

        }

        private static List<decimal> GetMachineInitialCoins()
        {
            List<decimal> coins = new List<decimal>();

            Enumerable.Range(1, 100).ToList().ForEach(i => coins.Add(0.10m));
            Enumerable.Range(1, 100).ToList().ForEach(i => coins.Add(0.20m));
            Enumerable.Range(1, 100).ToList().ForEach(i => coins.Add(0.50m));
            Enumerable.Range(1, 100).ToList().ForEach(i => coins.Add(1));

            return coins;
        }
    }
}
