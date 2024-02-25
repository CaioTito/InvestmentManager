using GestaoInvestimentos.Domain.Entities;
using GestaoInvestimentos.Domain.Interfaces.Repositories;
using MediatR;

namespace GestaoInvestimentos.Application.Commands
{
    public class CreateCategoryCommanHandler : IRequestHandler<CreateCategoryCommand, Guid>
    {
        private readonly ICategoriesRepository _categoriesRepository;

        public CreateCategoryCommanHandler(ICategoriesRepository categoriesRepository)
        {
            _categoriesRepository = categoriesRepository;
        }

        public async Task<Guid> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
        {
            var category = new Category(request.Name);

            await _categoriesRepository.AddAsync(category);

            return category.Id;
        }
    }
}
