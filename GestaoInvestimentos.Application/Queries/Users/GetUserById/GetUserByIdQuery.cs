using InvestmentManager.Application.ViewModels;
using MediatR;

namespace InvestmentManager.Application.Queries
{
    public class GetUserByIdQuery : IRequest<UserViewModel>
    {
        public GetUserByIdQuery(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; private set; }
    }
}
