using System.ComponentModel.DataAnnotations;

namespace GestaoInvestimentos.Domain.Entities
{
    public class UserProducts : BaseEntity
    {
        public UserProducts()
        {
            
        }
        public UserProducts(int quantity, Guid productId, Guid userId, Users user, Products product)
        {
            Quantity = quantity;
            ProductId = productId;
            UserId = userId;
            User = user;
            Product = product;
        }
        public int Quantity { get; private set; }
        public Guid ProductId { get; private set; }
        public Guid UserId { get; private set; }
        public Users User { get; private set; } = new();
        public Products Product { get; private set; } = new();

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
