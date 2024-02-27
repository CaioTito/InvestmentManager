namespace InvestmentManager.Domain.Entities
{
    public class UserProducts : BaseEntity
    {
        public UserProducts()
        {

        }
        public UserProducts(decimal quantity, decimal value, Users user, Products product)
        {
            Quantity = quantity;
            Value = value;
            User = user;
            Product = product;
        }
        public decimal Quantity { get; private set; }
        public decimal Value { get; private set; }
        public Users User { get; private set; } = new();
        public Products Product { get; private set; } = new();

        public void UpdateQuantityBuy(decimal quantity, decimal value)
        {
            Quantity += quantity;
            Value += value;
            UpdatedAt = DateTime.Now;
        }

        public void UpdateQuantitySell(decimal quantity, decimal value)
        {
            Quantity -= quantity;
            Value -= value;
            UpdatedAt = DateTime.Now;
        }
    }
}
