using InvestmentManager.Application.ViewModels;
using InvestmentManager.Domain.Enums;
using InvestmentManager.Domain.Interfaces.Repositories;
using MediatR;

namespace InvestmentManager.Application.Queries
{
    public class GetUserByIdQueryHandler : IRequestHandler<GetUserByIdQuery, UserViewModel>
    {
        private readonly IUsersRepository _repository;

        public GetUserByIdQueryHandler(IUsersRepository repository)
        {
            _repository = repository;
        }

        public async Task<UserViewModel> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            var user = await _repository.GetUserByIdAsync(request.Id);

            if (user == null)
                return null;

            return new UserViewModel(user.Id, user.Name, user.Email, Enum.GetName(typeof(ERole), user.Role));
        }
    }
}
