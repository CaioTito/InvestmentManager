namespace InvestmentManager.Domain.Entities
{
    public class OperationType : BaseEntity
    {
        public OperationType()
        {
        }
        public OperationType(string name)
        {
            Name = name;
        }

        public string Name { get; set; } = string.Empty;
        public List<Transactions> Transactions { get; private set; } = [];

        public void Update(string name)
        {
            Name = name;
            UpdatedAt = DateTime.Now;
        }
    }
}
