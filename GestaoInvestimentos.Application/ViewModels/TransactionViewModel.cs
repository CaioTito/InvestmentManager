namespace GestaoInvestimentos.Application.ViewModels
{
    public class TransactionViewModel
    {
        public TransactionViewModel(Guid id, Guid operationId, Guid productId, Guid userId, DateTime createdAt)
        {
            Id = id;
            OperationId = operationId;
            ProductId = productId;
            UserId = userId;
            CreatedAt = createdAt;
        }

        public Guid Id { get; private set; }
        public Guid OperationId { get; private set; }
        public Guid ProductId { get; private set; }
        public Guid UserId { get; private set; }
        public DateTime CreatedAt { get; private set; }
    }
}
