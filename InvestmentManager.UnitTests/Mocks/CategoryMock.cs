using Bogus;
using InvestmentManager.Application.Commands;
using InvestmentManager.Domain.Entities;

namespace InvestmentManager.UnitTests.Mocks
{
    public static class CategoryMock
    {
        public static Faker<Category> CategoryFaker => new Faker<Category>()
            .CustomInstantiator(f => (
                new Category(f.Random.Word())
            ));

        public static Faker<CreateCategoryCommand> CreateProjectCommandFaker =>
                new Faker<CreateCategoryCommand>()
                    .RuleFor(x => x.Name, f => f.Random.Word());
    }
}
