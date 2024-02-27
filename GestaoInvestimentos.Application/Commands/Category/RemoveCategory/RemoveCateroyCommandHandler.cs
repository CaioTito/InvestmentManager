using InvestmentManager.Domain.Interfaces.Repositories;
using MediatR;

namespace InvestmentManager.Application.Commands
{
    public class RemoveCateroyCommandHandler : IRequestHandler<RemoveCategoryCommand, Unit>
    {
        private readonly ICategoriesRepository _categoriesRepository;

        public RemoveCateroyCommandHandler(ICategoriesRepository categoriesRepository)
        {
            _categoriesRepository = categoriesRepository;
        }

        public async Task<Unit> Handle(RemoveCategoryCommand request, CancellationToken cancellationToken)
        {
            var category = await _categoriesRepository.GetCategoryByIdAsync(request.Id);

            category.Delete();
            _categoriesRepository.Update(category);

            return Unit.Value;
        }
    }
}
