using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using VendingMachine.Core.Base;
using VendingMachine.Core.Exceptions;

namespace VendingMachine.Core.Test
{
    public class WalletTest
    {
        BaseWallet _walletService;

        [SetUp]
        public void Setup()
        {
            _walletService = new BaseWallet();
        }

        [Test]
        public void AddCoins_ReturnTotalAmount()
        {
            const decimal TOTAL_AMOUNT = 18;

            Enumerable.Range(1, 10).ToList().ForEach(i => _walletService.AddCoin(0.10m));
            Enumerable.Range(1, 10).ToList().ForEach(i => _walletService.AddCoin(0.20m));
            Enumerable.Range(1, 10).ToList().ForEach(i => _walletService.AddCoin(0.50m));
            Enumerable.Range(1, 10).ToList().ForEach(i => _walletService.AddCoin(1));

            Assert.AreEqual(TOTAL_AMOUNT, _walletService.GetAmount());
        }

        [Test]
        public void AddCoin_IsNotValid([Values(0.02, 0.06, 3)] decimal invalidCoin)
        {
            try
            {
                _walletService.AddCoin(invalidCoin);
                Assert.Fail($"It was expected for the coin {invalidCoin} to be invalid.");
            }
            catch (InvalidCoinException)
            {
                Assert.Pass();
            }
        }

        [Test]
        public void AddCoin_IsValid([Values(0.05, 0.1, 0.2, 0.5, 1, 2)] decimal validCoin)
        {
            try
            {
                _walletService.AddCoin(validCoin);
                Assert.Pass();
            }
            catch (InvalidCoinException)
            {
                Assert.Fail($"It was expected for the coin {validCoin} to be valid.");
            }
        }

        [Test]
        public void RemoveCoins_ReturnZero()
        {
            Enumerable.Range(1, 10).ToList().ForEach(i => _walletService.AddCoin(0.10m));
            Enumerable.Range(1, 10).ToList().ForEach(i => _walletService.AddCoin(0.20m));
            Enumerable.Range(1, 10).ToList().ForEach(i => _walletService.AddCoin(0.50m));
            Enumerable.Range(1, 10).ToList().ForEach(i => _walletService.AddCoin(1));

            _walletService.RemoveAllCoins();

            Assert.AreEqual(expected: 0, _walletService.GetAmount());
        }

        [Test]
        public void RemoveCoin_ReturnZero([Values(2, 0.5, 0.2, 0.1)] decimal value)
        {
            const decimal ADDITIONAL_COIN = 1;
            _walletService.AddCoin(value);
            _walletService.AddCoin(ADDITIONAL_COIN);

            _walletService.RemoveCoin(value);

            Assert.AreEqual(expected: ADDITIONAL_COIN, _walletService.GetAmount());
        }

        [Test]
        public void RetrieveCoins_ReturnSumOfValue([Values(0.3, 1.5, 2.80, 0.1, 10)] decimal value)
        {
            Enumerable.Range(1, 10).ToList().ForEach(i => _walletService.AddCoin(0.10m));
            Enumerable.Range(1, 10).ToList().ForEach(i => _walletService.AddCoin(0.20m));
            Enumerable.Range(1, 10).ToList().ForEach(i => _walletService.AddCoin(0.50m));
            Enumerable.Range(1, 10).ToList().ForEach(i => _walletService.AddCoin(1));

            List<decimal> coins = _walletService.RetrieveCoinsFor(value);

            Assert.AreEqual(value, coins.Sum());
        }

        [Test]
        public void RetrieveCoins_RemoveCoinFromWallet()
        {
            const decimal VALUE = 0.10m;

            _walletService.AddCoin(VALUE);

            _walletService.RetrieveCoinsFor(VALUE);

            Assert.AreEqual(expected: 0, _walletService.GetCoins().Count);
        }

        [Test]
        public void RetrieveCoins_ReturnNoChangeAvailable()
        {
            const decimal VALUE = 0.10m;

            _walletService.AddCoin(VALUE);

            try
            {
                _walletService.RetrieveCoinsFor(VALUE * 2);
                Assert.Fail($"It was expected to do not have enough change for {VALUE * 2}");
            }
            catch (NoChangeException)
            {
                Assert.Pass();
            }
        }
    }
}