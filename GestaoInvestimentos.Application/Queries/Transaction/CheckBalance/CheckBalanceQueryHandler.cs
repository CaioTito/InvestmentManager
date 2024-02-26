using GestaoInvestimentos.Application.ViewModels;
using GestaoInvestimentos.Domain.Interfaces.Repositories;
using GestaoInvestimentos.Domain.Interfaces.Services;
using MediatR;
using System.Transactions;

namespace GestaoInvestimentos.Application.Queries
{
    public class CheckBalanceQueryHandler : IRequestHandler<CheckBalanceQuery, CheckBalanceViewModel>
    {
        private readonly IUsersRepository _userRepository;
        private readonly IUserProductsRepository _userProductsRepository;
        private readonly IEmailService _emailService;

        public CheckBalanceQueryHandler(IUsersRepository userRepository, IUserProductsRepository userProductsRepository, IEmailService emailService)
        {
            _userRepository = userRepository;
            _userProductsRepository = userProductsRepository;
            _emailService = emailService;
        }

        public async Task<CheckBalanceViewModel> Handle(CheckBalanceQuery request, CancellationToken cancellationToken)
        {
            var userProducts = await _userProductsRepository.GetUserProductsByUserId(request.UserId);
            var user = await _userRepository.GetUserByIdAsync(request.UserId);

            if (userProducts == null)
                return null;

            var productsBalanceList = new List<ProductBalanceViewModel>();

            foreach (var userProduct in userProducts)
            {
                var productsBalanceViewModel = new ProductBalanceViewModel(
                userProduct.Product.Name,
                userProduct.Quantity,
                userProduct.Value);

                productsBalanceList.Add(productsBalanceViewModel);
            }

            var checkBalanceViewModel =  new CheckBalanceViewModel(user.Name, user.Balance , productsBalanceList);

            await _emailService.SendEmailAsync("caio_tito@hotmail.com", "Teste", "Este é um e-mail de testes");

            return checkBalanceViewModel;
        }
    }
}
