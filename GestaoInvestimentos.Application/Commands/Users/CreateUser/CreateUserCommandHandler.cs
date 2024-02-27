using InvestmentManager.Domain.Entities;
using InvestmentManager.Domain.Enums;
using InvestmentManager.Domain.Interfaces.Repositories;
using InvestmentManager.Domain.Interfaces.Services;
using MediatR;

namespace InvestmentManager.Application.Commands
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

            var user = new Users(request.Name, request.Email, (int)ERole.Customer, request.Balance, request.Cpf, passwordHash);

            await _usersRepository.AddAsync(user);

            return user.Id;
        }
    }
}
