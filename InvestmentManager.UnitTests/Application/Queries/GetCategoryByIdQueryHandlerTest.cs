using InvestmentManager.Application.Commands;
using InvestmentManager.Domain.Interfaces.Repositories;
using InvestmentManager.UnitTests.Mocks;
using Moq.AutoMock;
using Moq;
using InvestmentManager.Application.Queries;
using InvestmentManager.Domain.Entities;
using InvestmentManager.Application.ViewModels;

namespace InvestmentManager.UnitTests.Application.Queries
{
    public class GetCategoryByIdQueryHandlerTest
    {
        private readonly AutoMocker _mocker;
        private readonly GetCategoryByIdQueryHandler _getCategoryByIdQueryHandler;

        public GetCategoryByIdQueryHandlerTest()
        {
            _mocker = new AutoMocker();
            _getCategoryByIdQueryHandler = new GetCategoryByIdQueryHandler(_mocker.GetMock<ICategoriesRepository>().Object);
        }

        [Fact]
        public async Task InputDataIsOK_Executed_ReturnCategoryViewModel()
        {
            //Arrange
            var getCategoryByIdQuery = CategoryMock.GetCategoryByIdQueryFaker.Generate();

            _mocker.GetMock<ICategoriesRepository>().Setup(c => c.GetCategoryByIdAsync(It.IsAny<Guid>())).ReturnsAsync(CategoryMock.CategoryFaker.Generate());

            //Act
            var category = await _getCategoryByIdQueryHandler.Handle(getCategoryByIdQuery, new CancellationToken());

            //Assert
            Assert.IsType<CategoryViewModel>(category);

            _mocker.GetMock<ICategoriesRepository>().Verify(c => c.GetCategoryByIdAsync(It.IsAny<Guid>()), Times.Once);
        }

        [Fact]
        public async Task InputDataIsNotOK_Executed_ReturnNull()
        {
            //Arrange
            var getCategoryByIdQuery = CategoryMock.GetCategoryByIdQueryFaker.Generate();

            //Act
            var category = await _getCategoryByIdQueryHandler.Handle(getCategoryByIdQuery, new CancellationToken());

            //Assert
            Assert.Null(category);
        }
    }
}
