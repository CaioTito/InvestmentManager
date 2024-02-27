INSERT INTO [InvestmentManager].[dbo].[Categories] ([Id], [Name], [CreatedAt], [UpdatedAt], [DeletedAt])
VALUES ('ec49479d-eaf0-441b-945c-cc79adaab24e', 'Renda Fixa', GETDATE(), GETDATE(), Null);
INSERT INTO [InvestmentManager].[dbo].[Categories] ([Id], [Name], [CreatedAt], [UpdatedAt], [DeletedAt])
VALUES ('ebbda9e7-bb57-4c07-8aa1-55fcb33a1a60', 'Renda Variavel', GETDATE(), GETDATE(), Null);

INSERT INTO [InvestmentManager].[dbo].[Products] ([Id],[CategoryId], [Liquidity], [AnnualRate], [MinimumInvestment], [ExpirationDate], [Name], [CreatedAt], [UpdatedAt], [DeletedAt])
VALUES ('1d8e834b-caaa-471b-a796-a6e87561616e','ec49479d-eaf0-441b-945c-cc79adaab24e', 'No Vencimento', 12.15, 1206.61, '2029-05-15 16:25:57.7170000', 'DEB AEGEA - MAI/2029', GETDATE(), GETDATE(), Null);
INSERT INTO [InvestmentManager].[dbo].[Products] ([Id],[CategoryId], [Liquidity], [AnnualRate], [MinimumInvestment], [ExpirationDate], [Name], [CreatedAt], [UpdatedAt], [DeletedAt])
VALUES ('449962d0-9b17-483a-b705-f452bd685431','ebbda9e7-bb57-4c07-8aa1-55fcb33a1a60', 'D+1', 7.12, 5000, '2029-05-15 16:25:57.7170000', 'XP Macro Instituicional FIC FIM', GETDATE(), GETDATE(), Null);

INSERT INTO [InvestmentManager].[dbo].[OperationTypes] ([Id], [Name], [CreatedAt], [UpdatedAt], [DeletedAt])
VALUES ('124d14b5-ae87-43cc-bdf5-22964006a65c', 'Compra', GETDATE(), GETDATE(), Null);
INSERT INTO [InvestmentManager].[dbo].[OperationTypes] ([Id], [Name], [CreatedAt], [UpdatedAt], [DeletedAt])
VALUES ('1253f346-8daa-46d2-9323-693d2ec96229', 'Venda', GETDATE(), GETDATE(), Null);