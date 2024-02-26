using GestaoInvestimentos.Application.ViewModels;
using MediatR;

namespace GestaoInvestimentos.Application.Queries
{
    public class CheckBalanceQuery : IRequest<CheckBalanceViewModel>
    {
        public CheckBalanceQuery(Guid userId)
        {
            UserId = userId;
        }

        public Guid UserId { get; private set; }
    }
}
