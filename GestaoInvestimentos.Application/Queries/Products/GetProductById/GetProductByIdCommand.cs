using GestaoInvestimentos.Application.ViewModels;
using MediatR;

namespace GestaoInvestimentos.Application.Queries
{
    public class GetProductByIdCommand : IRequest<ProductViewModel>
    {
        public GetProductByIdCommand(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; private set; }
    }
}
