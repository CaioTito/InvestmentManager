namespace GestaoInvestimentos.Domain.Entities
{
    public class UserProducts : BaseEntity
    {
        public UserProducts(int quantity)
        {
            Quantity = quantity;

            User = new();
            Product = new();
        }
        public int Quantity { get; private set; }
        public Guid ProductId { get; private set; }
        public Guid UserId { get; private set; }
        public Users User { get; private set; }
        public Products Product { get; private set; }
    }
}
