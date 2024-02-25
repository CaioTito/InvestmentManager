namespace GestaoInvestimentos.Domain.Entities
{
    public class Users : BaseEntity
    {
        public Users()
        {
            
        }
        public Users(string name, string email, int role, decimal balance, string cpf, string password)
        {
            Name = name;
            Email = email;
            Role = role;
            Balance = balance;
            Cpf = cpf;
            Password = password;
        }

        public string Name { get; set; } = string.Empty;
        public string Cpf { get; private set; } = string.Empty;
        public string Password { get; private set; } = string.Empty;
        public string Email { get; private set; } = string.Empty;
        public int Role { get; private set; }
        public decimal Balance { get; private set; }
        public List<Transactions> Transactions { get; private set; } = [];
        public List<UserProducts> UserProducts { get; private set; } = [];

        public void Update(string email, int role)
        {
            Email = email;
            Role = role;
            UpdatedAt = DateTime.Now;
        }

        public void UpdateBalance(decimal costs)
        {
            Balance -= costs;
            UpdatedAt = DateTime.Now;
        }
    }
}
