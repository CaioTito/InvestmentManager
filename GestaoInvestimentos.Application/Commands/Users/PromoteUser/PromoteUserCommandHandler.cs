using GestaoInvestimentos.Domain.Interfaces.Repositories;
using MediatR;

namespace GestaoInvestimentos.Application.Commands
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

            user.Update(user.Email, 1);
            _usersRepository.Update(user);

            return Unit.Value;
        }
    }
}
