using System.ComponentModel.DataAnnotations;

namespace InvestmentManager.Domain.Entities
{
    public class Transactions : BaseEntity
    {
        public Transactions()
        {
            
        }
        public Transactions(decimal quantity, decimal value, OperationType operationType, Products product, Users user)
        {
            Quantity = quantity;
            Value = value;
            OperationType = operationType;
            Product = product;
            User = user;
        }
        public decimal Quantity { get; private set; }
        public decimal Value { get; private set; }
        public OperationType OperationType { get; private set; } = new();
        public Products Product { get; private set; } = new();
        public Users User { get; private set; } = new();

        public void UpdateQuantityBuy(decimal quantity, decimal value)
        {
            Quantity += quantity;
            Value += value;
            UpdatedAt = DateTime.Now;
        }

        public void UpdateQuantitySell(decimal quantity, decimal value)
        {
            Quantity += quantity;
            Value += value;
            UpdatedAt = DateTime.Now;
        }
    }
}
