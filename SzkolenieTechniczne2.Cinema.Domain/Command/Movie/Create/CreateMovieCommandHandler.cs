using MediatR;
using SzkolenieTechniczne2.Cinema.Domain.Repositories;
using SzkolenieTechniczne2.Cinema.Domain.Entities;
using SzkolenieTechniczne2.Cinema.Common.Entities;

namespace SzkolenieTechniczne2.Cinema.Domain.Command.Movie.Create
{
    class CreateMovieCommandHandler : IRequestHandler<CreateMovieCommand, Result>
    {
        private readonly IMoviesRepository moviesRepository;

        public CreateMovieCommandHandler(IMoviesRepository repository)
        {
            moviesRepository = repository;
        }

        public async Task<Result> Handle(CreateMovieCommand request, CancellationToken cancellationToken)
        {
            var validator = new CreateMovieCommandValidator();
            var validationResult = await validator.ValidateAsync(request, cancellationToken);

            if (!validationResult.IsValid)
                return Result.Fail(validationResult);

            if (await moviesRepository.IsMovieExistAsync(request.Name, request.Year))
                return Result.Fail("This movie already exists.");

            var movie = new SzkolenieTechniczne2.Cinema.Domain.Entities.Movie(request.Name, request.Year, request.SeanceTime, request.MovieCategoryId);
            
            await moviesRepository.AddAsync(movie);

            return Result.Ok();
        }
    }
}
