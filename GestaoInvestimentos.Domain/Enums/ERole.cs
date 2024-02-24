using System.ComponentModel;

namespace GestaoInvestimentos.Domain.Enums
{
    public enum ERole
    {
        [Description("Administrator")]
        Administrator = 1,
        [Description("Customer")]
        Customer = 2
    }
}
