using InvestmentManager.Application.Commands;
using InvestmentManager.Domain.Entities;
using InvestmentManager.Domain.Interfaces.Repositories;
using InvestmentManager.UnitTests.Mocks;
using Moq;
using Moq.AutoMock;

namespace InvestmentManager.UnitTests.Application.Command
{
    public class CreateCategoryCommandHandlerTest
    {
        private readonly AutoMocker _mocker;
        private readonly CreateCategoryCommanHandler _createCategoryCommanHandler;

        public CreateCategoryCommandHandlerTest()
        {
            _mocker = new AutoMocker();
            _createCategoryCommanHandler = new CreateCategoryCommanHandler(_mocker.GetMock<ICategoriesRepository>().Object);
        }

        [Fact]
        public async Task InputDataIsOK_Executed_ReturnProjectId()
        {
            //Arrange
            var createCategoryCommand = CategoryMock.CreateProjectCommandFaker.Generate();

            //Act
            var id = await _createCategoryCommanHandler.Handle(createCategoryCommand, new CancellationToken());

            //Assert
            Assert.IsType<Guid>(id);

            _mocker.GetMock<ICategoriesRepository>().Verify(c => c.AddAsync(It.IsAny<Category>()), Times.Once);
        }
    }
}
