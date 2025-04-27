using FluentValidation;
using MediatR;
using SzkolenieTechniczne2.Cinema.Domain.Entities;
using SzkolenieTechniczne2.Cinema.Domain.Repositories;

namespace SzkolenieTechniczne2.Cinema.Domain.Command.Seances.Register
{
    internal class RegisterSeanceCommandHandler : IRequestHandler<RegisterSeanceCommand, Result>
    {
        private readonly IMoviesRepository repository;
        private readonly IValidator<RegisterSeanceCommand> validator;

        public RegisterSeanceCommandHandler(IMoviesRepository repository, IValidator<RegisterSeanceCommand> validator)
        {
            this.repository = repository;
            this.validator = validator;
        }

        public async Task<Result> Handle(RegisterSeanceCommand command, CancellationToken cancellationToken)
        {
            var validationResult = await validator.ValidateAsync(command, cancellationToken);

            if (!validationResult.IsValid)
                return Result.Fail(validationResult);

            if (await repository.IsSeanceExistAsync(command.SeanceDate))
                return Result.Fail("This seance already exists.");

            var movie = await repository.GetByIdAsync(command.MovieId);

            if (movie == null)
                return Result.Fail("This movie doesn't exist.");

            var seance = new Seance(command.SeanceDate, command.MovieId);

            movie.Seances.Add(seance);
            await repository.UpdateAsync(movie);

            return Result.Ok();
        }
    }
}
