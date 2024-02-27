using InvestmentManager.Domain.Interfaces.Repositories;
using InvestmentManager.Domain.Interfaces.Services;
using Microsoft.Extensions.Logging;
using Quartz;
using System.Text.Json;

namespace InvestmentManager.Infra.Email
{
    [DisallowConcurrentExecution]
    public class EmailBackgoundJob : IJob
    {
        private readonly ILogger<EmailBackgoundJob> _logger;
        private readonly IEmailService _emailService;
        private readonly IProductsRepository _productsRepository;

        public EmailBackgoundJob(ILogger<EmailBackgoundJob> logger, IEmailService emailService, IProductsRepository productsRepository)
        {
            _logger = logger;
            _emailService = emailService;
            _productsRepository = productsRepository;
        }

        public Task Execute(IJobExecutionContext context)
        {
            _logger.LogInformation("Job de verificação de vencimentos iniciada");

            var productsNearExpiration = _productsRepository.CheckProductExpiration();
            var productsNearExpirationConverted = JsonSerializer.Serialize(productsNearExpiration);

            if (productsNearExpiration.Count != 0)
                _emailService.SendEmail("caio_tito@hotmail.com", $"Produtos próximos ao vencimento - {DateTime.Now.ToString("dd/MM/yyyy")}", productsNearExpirationConverted);

            return Task.CompletedTask;
        }
    }
}
