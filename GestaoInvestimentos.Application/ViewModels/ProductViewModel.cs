using GestaoInvestimentos.Domain.Entities;

namespace GestaoInvestimentos.Application.ViewModels
{
    public class ProductViewModel
    {
        public ProductViewModel(Guid id, string name, Guid categoryId, string liquidity, decimal annualRate, decimal minimumInvestment, DateTime expirationDate)
        {
            Id = id;
            Name = name;
            CategoryId = categoryId;
            Liquidity = liquidity;
            AnnualRate = annualRate;
            MinimumInvestment = minimumInvestment;
            ExpirationDate = expirationDate;
        }

        public Guid Id { get; private set; }
        public string Name { get; private set; } = string.Empty;
        public Guid CategoryId { get; set; } = new();
        public string Liquidity { get; private set; } = string.Empty;
        public decimal AnnualRate { get; private set; }
        public decimal MinimumInvestment { get; private set; }
        public DateTime ExpirationDate { get; private set; }
    }
}
