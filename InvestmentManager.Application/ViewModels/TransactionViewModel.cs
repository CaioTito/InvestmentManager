﻿namespace InvestmentManager.Application.ViewModels
{
    public class TransactionViewModel
    {
        public TransactionViewModel(Guid id, string productName, decimal quantity, string operationType, string userName)
        {
            Id = id;
            ProductName = productName;
            Quantity = quantity;
            OperationType = operationType;
            UserName = userName;
        }

        public Guid Id { get; private set; }
        public string ProductName { get; private set; }
        public decimal Quantity { get; private set; }
        public string OperationType { get; private set; }
        public string UserName { get; private set; }
    }
}
