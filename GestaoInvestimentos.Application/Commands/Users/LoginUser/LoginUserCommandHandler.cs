using GestaoInvestimentos.Domain.Interfaces.Repositories;
using GestaoInvestimentos.Domain.Interfaces.Services;
using MediatR;
using System.Net;

namespace GestaoInvestimentos.Application.Commands
{
    public class LoginUserCommandHandler : IRequestHandler<LoginUserCommand, string>
    {
        private readonly IUsersRepository _usersRepository;
        private readonly IAuthService _authService;

        public LoginUserCommandHandler(IUsersRepository usersRepository, IAuthService authService)
        {
            _usersRepository = usersRepository;
            _authService = authService;
        }

        public async Task<string> Handle(LoginUserCommand request, CancellationToken cancellationToken)
        {
            var passwordHash = _authService.GeneratePasswordHash(request.Password);

            var user = await _usersRepository.GetByPasswordAndEmailAsync(request.Email, passwordHash);

            if (user == null)
            {
                return null;
            }

            return _authService.GenerateJwtToken(user.Email, user.Role, user.Id);
        }
    }
}
