namespace GestaoInvestimentos.Domain.Entities
{
    public class OperationType : BaseEntity
    {
        public OperationType()
        {
            Transactions = [];
        }
        public OperationType(string name)
        {
            Name = name;

            Transactions = [];
        }

        public string Name { get; set; } = string.Empty;
        public List<Transactions> Transactions { get; private set; }
    }
}
