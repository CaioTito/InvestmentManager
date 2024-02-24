using GestaoInvestimentos.Domain.Entities;
using GestaoInvestimentos.Domain.Interfaces.Repositories;
using GestaoInvestimentos.Domain.Interfaces.Services;
using MediatR;

namespace GestaoInvestimentos.Application.Commands
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, Guid>
    {
        private readonly IUsersRepository _usersRepository;
        private readonly IAuthService _authService;

        public CreateUserCommandHandler(IUsersRepository usersRepository, IAuthService authService)
        {
            _usersRepository = usersRepository;
            _authService = authService;
        }

        public async Task<Guid> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var passwordHash = _authService.GeneratePasswordHash(request.Password);

            var user = new Users(request.Name, request.Email, request.Role, request.Balance, request.Cpf, passwordHash);

            await _usersRepository.AddAsync(user);

            return user.Id;
        }
    }
}
