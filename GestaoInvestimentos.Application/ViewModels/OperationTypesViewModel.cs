namespace InvestmentManager.Application.ViewModels
{
    public class OperationTypesViewModel
    {
        public OperationTypesViewModel(Guid id, string name)
        {
            Id = id;
            Name = name;
        }

        public Guid Id { get; private set; }
        public string Name { get; private set; } = string.Empty;
    }
}
