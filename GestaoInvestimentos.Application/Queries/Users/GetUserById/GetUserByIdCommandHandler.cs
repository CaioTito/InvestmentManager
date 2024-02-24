using GestaoInvestimentos.Application.ViewModels;
using GestaoInvestimentos.Domain.Interfaces.Repositories;
using MediatR;

namespace GestaoInvestimentos.Application.Queries
{
    public class GetUserByIdCommandHandler : IRequestHandler<GetUserByIdCommand, UserViewModel>
    {
        private readonly IUsersRepository _repository;

        public GetUserByIdCommandHandler(IUsersRepository repository)
        {
            _repository = repository;
        }

        public async Task<UserViewModel> Handle(GetUserByIdCommand request, CancellationToken cancellationToken)
        {
            var user = await _repository.GetUserByIdAsync(request.Id);

            if (user == null)
                return null;

            return new UserViewModel(user.Id, user.Name, user.Email, user.Role);
        }
    }
}
