using InvestmentManager.Domain.Enums;
using InvestmentManager.Domain.Interfaces.Repositories;
using MediatR;

namespace InvestmentManager.Application.Commands
{
    public class PromoteUserCommandHandler : IRequestHandler<PromoteUserCommand, Unit>
    {
        private readonly IUsersRepository _usersRepository;

        public PromoteUserCommandHandler(IUsersRepository usersRepository)
        {
            _usersRepository = usersRepository;
        }

        public async Task<Unit> Handle(PromoteUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _usersRepository.GetUserByIdAsync(request.Id);

            user.Update(user.Email, (int)ERole.Administrator);
            _usersRepository.Update(user);

            return Unit.Value;
        }
    }
}
