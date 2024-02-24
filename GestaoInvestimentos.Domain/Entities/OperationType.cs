namespace GestaoInvestimentos.Domain.Entities
{
    public class OperationType : BaseEntity
    {
        public OperationType()
        {
            Users = [];
            Products = [];
        }
        public OperationType(string name)
        {
            Name = name;

            Users = [];
            Products = [];
        }

        public List<Users> Users { get; private set; }
        public List<Products> Products { get; private set; }
    }
}
