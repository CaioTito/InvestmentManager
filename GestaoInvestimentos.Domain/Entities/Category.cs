namespace GestaoInvestimentos.Domain.Entities
{
    public class Category : BaseEntity
    {
        public Category()
        {
            
        }
        public Category(string name)
        {
            Name = name;

            Products = new List<Products>();
        }

        public List<Products> Products { get; private set; }
    }
}
