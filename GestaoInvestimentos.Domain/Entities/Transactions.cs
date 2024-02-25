namespace GestaoInvestimentos.Domain.Entities
{
    public class Transactions : BaseEntity
    {
        public Transactions()
        {
            OperationType = new();
            Product = new();
            User = new();
        }
        public Guid OperationId { get; private set; }
        public Guid ProductId { get; private set; }
        public Guid UserId { get; private set; }
        public OperationType OperationType { get; private set; }
        public Products Product { get; private set; }
        public Users User { get; private set; }
    }
}
