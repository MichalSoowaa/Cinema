using MediatR;
using SzkolenieTechniczne2.Cinema.Domain.Repositories;

namespace SzkolenieTechniczne2.Cinema.Domain.Command.Movie.Delete
{
    class DeleteMovieCommandHandler : IRequestHandler<DeleteMovieCommand, Result>
    {
        private readonly IMoviesRepository moviesRepository;

        public DeleteMovieCommandHandler(IMoviesRepository repository)
        {
            moviesRepository = repository;
        }

        public async Task<Result> Handle(DeleteMovieCommand request, CancellationToken cancellationToken)
        {
            var movie = await moviesRepository.GetByIdAsync(request.Id);

            if (movie == null)
                return Result.Fail("Movie doesn't exist.");

            await moviesRepository.RemoveAsync(movie);

            return Result.Ok();
        }
    }
}
