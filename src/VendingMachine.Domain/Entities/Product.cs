using VendingMachine.Domain.Exceptions;

namespace VendingMachine.Domain.Entities
{
    public class Product
    {
        public Product(int id, string name, decimal price, int quantity)
        {
            Id = id;
            Name = name;
            Price = price;
            Quantity = quantity;
        }

        public int Id { get; private set; }

        public string Name { get; private set; }

        public decimal Price { get; private set; }

        public int Quantity { get; private set; }

        public decimal TakeOne(decimal amount)
        {
            if (this.Quantity <= 0)
                throw new ProductNotAllowedException("Product not available.");

            if (this.Price > amount)
                throw new ProductNotAllowedException($"Insufficient amount. The price for {this.Name} is {this.Price}€");

            this.Quantity--;

            return amount - this.Price;
        }
    }
}
