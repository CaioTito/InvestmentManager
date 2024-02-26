namespace GestaoInvestimentos.Application.ViewModels
{
    public class ProductBalanceViewModel
    {
        public ProductBalanceViewModel(string productName, decimal quantity, decimal value)
        {
            ProductName = productName;
            Quantity = quantity;
            Value = value;
        }

        public string ProductName { get; private set; }
        public decimal Quantity { get; private set; }
        public decimal Value { get; private set; }
    }
}
