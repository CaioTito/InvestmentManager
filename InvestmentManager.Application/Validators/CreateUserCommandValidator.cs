using FluentValidation;
using InvestmentManager.Application.Commands;
using System.Text.RegularExpressions;

namespace InvestmentManager.Application.Validators
{
    public class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
    {
        public CreateUserCommandValidator()
        {
            RuleFor(p => p.Email)
                .EmailAddress()
                .WithMessage("E-mail is not valid");

            RuleFor(p => p.Password)
                .Must(ValidPassword)
                .WithMessage("Password needs to contain 8 charaters, 1 number, 1 capital letter, 1 lowercase letter e 1 special character");

            RuleFor(p => p.Name)
                .NotEmpty()
                .NotNull()
                .WithMessage("Name is required!");
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
