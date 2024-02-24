using GestaoInvestimentos.Domain.Interfaces.Repositories;
using MediatR;

namespace GestaoInvestimentos.Application.Commands
{
    public class RemoveUserCommandHandler : IRequestHandler<RemoveUserCommand, Unit>
    {
        private readonly IUsersRepository _usersRepository;

        public RemoveUserCommandHandler(IUsersRepository usersRepository)
        {
            _usersRepository = usersRepository;
        }

        public async Task<Unit> Handle(RemoveUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _usersRepository.GetUserByIdAsync(request.Id);

            user.Delete();
            _usersRepository.Update(user);

            return Unit.Value;
        }
    }
}
