using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SzkolenieTechniczne2.Cinema.Domain.Command.Seances.Register
{
    internal class RegisterSeanceCommandValidator : AbstractValidator<RegisterSeanceCommand>
    {
        public RegisterSeanceCommandValidator()
        {
            RuleFor(x => x.MovieId)
                .NotEmpty()
                .WithMessage("ID filmu jest wymagane.");

            RuleFor(x => x.SeanceDate)
                .NotEmpty()
                .WithMessage("Data seansu jest wymagana.")
                .GreaterThan(DateTime.UtcNow)
                .WithMessage("Data seansu musi być większa niż aktualna");
        }
    }
}
