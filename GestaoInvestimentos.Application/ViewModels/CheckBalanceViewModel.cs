namespace GestaoInvestimentos.Application.ViewModels
{
    public class CheckBalanceViewModel
    {
        public CheckBalanceViewModel(string userName, decimal balance, List<ProductBalanceViewModel> products)
        {
            UserName = userName;
            Balance = balance;
            Products = products;
        }

        public List<ProductBalanceViewModel> Products { get; private set; }
        public string UserName { get; private set; }
        public decimal Balance { get; private set; }
    }
}
