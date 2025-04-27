using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SzkolenieTechniczne2.Cinema.Domain.Command.Movie.Create;
using SzkolenieTechniczne2.Cinema.Domain.Repositories;

namespace SzkolenieTechniczne2.Cinema.Domain.Command.Movie.Update
{
    class UpdateMovieCommandHandler : IRequestHandler<UpdateMovieCommand, Result>
    {
        private readonly IMoviesRepository moviesRepository;

        public UpdateMovieCommandHandler(IMoviesRepository repository)
        {
            moviesRepository = repository;
        }

        public async Task<Result> Handle(UpdateMovieCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateMovieCommandValidator();
            var validationResult = await validator.ValidateAsync(request, cancellationToken);

            if (!validationResult.IsValid)
                return Result.Fail(validationResult);

            var movie = await moviesRepository.GetByIdAsync(request.Id);

            if (movie == null)
                return Result.Fail("Movie not found.");

            movie.SetName(request.Name);
            movie.SetYear(request.Year);
            movie.SetSeanceTime(request.SeanceTime);

            await moviesRepository.UpdateAsync(movie);

            return Result.Ok();
        }
    }
}
