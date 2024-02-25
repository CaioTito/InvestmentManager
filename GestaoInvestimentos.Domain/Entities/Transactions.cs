using System.ComponentModel.DataAnnotations;

namespace GestaoInvestimentos.Domain.Entities
{
    public class Transactions : BaseEntity
    {
        public Transactions()
        {
            
        }
        public Transactions(int quantity, Guid operationId, Guid productId, Guid userId, OperationType operationType, Products product, Users user)
        {
            Quantity = quantity;
            OperationId = operationId;
            ProductId = productId;
            UserId = userId;
            OperationType = operationType;
            Product = product;
            User = user;
        }
        public int Quantity { get; private set; }
        public Guid OperationId { get; private set; }
        public Guid ProductId { get; private set; }
        public Guid UserId { get; private set; }
        public OperationType OperationType { get; private set; } = new();
        public Products Product { get; private set; } = new();
        public Users User { get; private set; } = new();

        public void UpdateQuantityBuy(int quantity)
        {
            Quantity += quantity;
            UpdatedAt = DateTime.Now;
        }

        public void UpdateQuantitySell(int quantity)
        {
            Quantity -= quantity;
            UpdatedAt = DateTime.Now;
        }
    }
}
