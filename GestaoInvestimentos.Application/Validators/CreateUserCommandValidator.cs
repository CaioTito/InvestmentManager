using FluentValidation;
using GestaoInvestimentos.Application.Commands;
using System.Text.RegularExpressions;

namespace GestaoInvestimentos.Application.Validators
{
    public class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
    {
        public CreateUserCommandValidator()
        {
            RuleFor(p => p.Email)
                .EmailAddress()
                .WithMessage("E-mail não válido");

            RuleFor(p => p.Password)
                .Must(ValidPassword)
                .WithMessage("Senha deve conter pelo menos 8 caracteres, um número, uma letra maiúscula, uma letra minpuscula e um caractere especial");

            RuleFor(p => p.Name)
                .NotEmpty()
                .NotNull()
                .WithMessage("Nome é obrigatório!");

            RuleFor(p => p.Role)
                .NotEmpty()
                .NotNull()
                .Must(ValidRole)
                .WithMessage(@"Role é obrigatória. Utilize 1 para ""Administrador"" e 2 para ""Cliente""");
        }

        public bool ValidPassword(string password)
        {
            var regex = new Regex(@"^.*(?=.{8,})(?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[!*@#$%&+=]).*$");

            return regex.IsMatch(password);
        }

        public bool ValidRole(int role)
        {
            if (role != 1 && role != 2)
                return false;

            return true;
        }
    }
}
