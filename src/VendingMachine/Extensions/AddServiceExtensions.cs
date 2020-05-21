using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;
using System.Linq;
using VendingMachine.Core;
using VendingMachine.Core.Options;
using VendingMachine.Domain.Interfaces;
using VendingMachine.Domain.Models;

namespace VendingMachine.Extensions
{
    public static class AddServiceExtensions
    {
        /// <summary>
        /// Adds the Singleton needed services that hold the data.
        /// </summary>
        /// <param name="services"></param>
        public static void AddSingletonServices(this IServiceCollection services)
        {
            services.AddSingleton<WalletDefaultOptions>(s => GetWalletDefaultOptions());
            services.AddSingleton<ProductDefaultOptions>(s => GetProductDefaultOptions());

            services.AddSingleton<UserWalletService>();
            services.AddSingleton<MachineWalletService>();
            services.AddSingleton<IProductsService, ProductsService>();
        }

        private static WalletDefaultOptions GetWalletDefaultOptions()
        {
            List<decimal> coins = new List<decimal>();

            Enumerable.Range(1, 100).ToList().ForEach(i => coins.Add(0.10m));
            Enumerable.Range(1, 100).ToList().ForEach(i => coins.Add(0.20m));
            Enumerable.Range(1, 100).ToList().ForEach(i => coins.Add(0.50m));
            Enumerable.Range(1, 100).ToList().ForEach(i => coins.Add(1));

            return new WalletDefaultOptions()
            {
                Coins = coins
            };
        }

        private static ProductDefaultOptions GetProductDefaultOptions()
        {
            List<Product> products = new List<Product>();

            products.Add(new Product(1, "Tea", 1.30m, 10));
            products.Add(new Product(2, "Espresso", 1.80m, 20));
            products.Add(new Product(3, "Juice", 1.80m, 20));
            products.Add(new Product(4, "Chicken soup", 1.80m, 15));

            return new ProductDefaultOptions
            {
                Products = products
            };
        }
    }
}
