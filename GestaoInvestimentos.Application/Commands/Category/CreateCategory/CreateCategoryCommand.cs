using MediatR;

namespace GestaoInvestimentos.Application.Commands
{
    public class CreateCategoryCommand : IRequest<Guid>
    {
        public string Name { get; set; } = string.Empty;
    }
}
