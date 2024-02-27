using InvestmentManager.Application.ViewModels;
using MediatR;

namespace InvestmentManager.Application.Queries
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
