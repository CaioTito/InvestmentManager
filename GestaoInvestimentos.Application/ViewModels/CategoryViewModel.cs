namespace InvestmentManager.Application.ViewModels
{
    public class CategoryViewModel
    {
        public CategoryViewModel(Guid id, string name)
        {
            Id = id;
            Name = name;
        }

        public Guid Id { get; private set; }
        public string Name { get; private set; } = string.Empty;
    }
}
