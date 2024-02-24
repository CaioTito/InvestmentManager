namespace GestaoInvestimentos.Application.ViewModels
{
    public class UserViewModel
    {
        public UserViewModel(Guid id, string name, string email, int role)
        {
            Id = id;
            Name = name;
            Email = email;
            Role = role;
        }

        public Guid Id { get; private set; }
        public string Name { get; private set; } = string.Empty;
        public string Email { get; private set; } = string.Empty;
        public int Role { get; private set; }
    }
}
