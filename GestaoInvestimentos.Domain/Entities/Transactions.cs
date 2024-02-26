using System.ComponentModel.DataAnnotations;

namespace GestaoInvestimentos.Domain.Entities
{
    public class Transactions : BaseEntity
    {
        public Transactions()
        {
            
        }
        public Transactions(decimal quantity, decimal value, Guid operationId, Guid productId, Guid userId, OperationType operationType, Products product, Users user)
        {
            Quantity = quantity;
            Value = value;
            OperationId = operationId;
            ProductId = productId;
            UserId = userId;
            OperationType = operationType;
            Product = product;
            User = user;
        }
        public decimal Quantity { get; private set; }
        public decimal Value { get; private set; }
        public Guid OperationId { get; private set; }
        public Guid ProductId { get; private set; }
        public Guid UserId { get; private set; }
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
            Quantity -= quantity;
            Value -= value;
            UpdatedAt = DateTime.Now;
        }
    }
}
