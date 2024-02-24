using GestaoInvestimentos.Application.ViewModels;
using MediatR;

namespace GestaoInvestimentos.Application.Queries
{
    public class GetUserByIdCommand : IRequest<UserViewModel>
    {
        public GetUserByIdCommand(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; private set; }
    }
}
