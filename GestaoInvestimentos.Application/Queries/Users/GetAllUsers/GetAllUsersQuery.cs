using InvestmentManager.Application.ViewModels;
using MediatR;

namespace InvestmentManager.Application.Queries.Users.GetAllUsers
{
    public class GetAllUsersQuery : IRequest<List<UserViewModel>>
    {
        public string Query { get; set; } = string.Empty;
    }
}
