using GestaoInvestimentos.Domain.Entities;
using MediatR;

namespace GestaoInvestimentos.Application.Commands
{
    public class CreateProductCommand : IRequest<Guid>
    {
        public string Name { get; set; } = string.Empty;
        public Category Category { get; set; } = new();
        public string Liquidity { get; set; } = string.Empty;
        public decimal AnnualRate { get; set; }
        public decimal MinimumInvestment { get; set; }
        public DateTime ExpirationDate { get; set; }
    }
}
