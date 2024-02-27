namespace InvestmentManager.Domain.Entities
{
    public class Category : BaseEntity
    {
        public Category()
        {
        }
        public Category(string name)
        {
            Name = name;
        }

        public string Name { get; set; } = string.Empty;
        public List<Products> Products { get; private set; } = [];

        public void Update(string name)
        {
            Name = name;
            UpdatedAt = DateTime.Now;
        }
    }
}
