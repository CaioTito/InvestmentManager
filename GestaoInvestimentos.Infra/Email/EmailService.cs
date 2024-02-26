using GestaoInvestimentos.Domain.Interfaces.Services;
using System.Net.Mail;
using System.Net;

namespace GestaoInvestimentos.Infra.Email
{
    public class EmailService : IEmailService
    {
        public void SendEmail(string email, string subject, string message)
        {
            var client = new SmtpClient("smtp.gmail.com", 587)
            {
                EnableSsl = true,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential("caiotiito@gmail.com", "dykx swzl yrss doxq")
            };

            client.Send(
                new MailMessage(from: "caiotiito@gmail.com",
                                to: email,
                                subject,
                                message
                                ));
        }
    }
}
