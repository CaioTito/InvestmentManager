using System.Data;

namespace InvestmentManager.Domain.Entities
{
    public class Products : BaseEntity
    {
        public Products()
        {
            Category = new();
        }
        public Products(string name, Category category, string liquidity, decimal annualRate, decimal minimumInvestment, DateTime expirationDate)
        {
            Name = name;
            Category = category;
            Liquidity = liquidity;
            AnnualRate = annualRate;
            MinimumInvestment = minimumInvestment;
            ExpirationDate = expirationDate;
        }

        public string Name { get; set; } = string.Empty;
        public Category Category { get; private set; }
        public string Liquidity { get; private set; } = string.Empty;
        public decimal AnnualRate { get; private set; }
        public decimal MinimumInvestment { get; private set; }
        public DateTime ExpirationDate { get; private set; }
        public List<Transactions> Transactions { get; private set; } = [];
        public List<UserProducts> UserProducts { get; private set; } = [];

        public void Update(string name, Category category, string liquidity, decimal annualRate, decimal minimumInvestment, DateTime expirationDate)
        {
            Name = name;
            Category = category;
            Liquidity = liquidity;
            AnnualRate = annualRate;
            MinimumInvestment = minimumInvestment;
            ExpirationDate = expirationDate;
            UpdatedAt = DateTime.Now;
        }
    }
}
