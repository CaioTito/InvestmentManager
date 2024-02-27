using InvestmentManager.Application.ViewModels;
using InvestmentManager.Domain.Enums;
using InvestmentManager.Domain.Interfaces.Repositories;
using MediatR;

namespace InvestmentManager.Application.Queries.Users.GetAllUsers
{
    public class GetAllUsersQueryHandler : IRequestHandler<GetAllUsersQuery, List<UserViewModel>>
    {
        private readonly IUsersRepository _usersRepository;

        public GetAllUsersQueryHandler(IUsersRepository usersRepository)
        {
            _usersRepository = usersRepository;
        }

        public async Task<List<UserViewModel>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
        {
            var users = await _usersRepository.GetAllUsers(request.Query);

            return users
            .Select(u => new UserViewModel(u.Id, u.Name, u.Email, Enum.GetName(typeof(ERole), u.Role)))
            .ToList();
        }
    }
}
