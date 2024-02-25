namespace GestaoInvestimentos.Domain.Entities
{
    public class Category : BaseEntity
    {
        public Category()
        {
            Products = [];
        }
        public Category(string name)
        {
            Name = name;

            Products = [];
        }

        public string Name { get; set; } = string.Empty;
        public List<Products> Products { get; private set; }

        public void Update(string name)
        {
            Name = name;
            UpdatedAt = DateTime.Now;
        }
    }
}
