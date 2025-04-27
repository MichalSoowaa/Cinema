using MediatR;
using SzkolenieTechniczne2.Cinema.Domain.Query.Dtos;
using SzkolenieTechniczne2.Cinema.Domain.Repositories;

namespace SzkolenieTechniczne2.Cinema.Domain.Query.Movie.GetMovieQuery
{
    public sealed class GetMovieQueryHandler : IRequestHandler<GetMovieQuery, MovieDetailsDTO>
    {
        private readonly IMoviesRepository repository;

        public GetMovieQueryHandler(IMoviesRepository repository)
        {
            this.repository = repository;
        }

        public async Task<MovieDetailsDTO> Handle(GetMovieQuery query, CancellationToken cancellationToken)
        {
            var movie = await repository.GetByIdAsync(query.MovieId);

            if (movie == null)
                throw new NullReferenceException("Given movie doesn't exist.");

            var seances = movie.Seances?
                .Select(seance => new SeanceDTO(seance.Id, seance.Date))
                .ToList() ?? new List<SeanceDTO>();

            return new MovieDetailsDTO(movie.Id, movie.Name, movie.Year, movie.SeanceTime, seances);
        }
    }
}
