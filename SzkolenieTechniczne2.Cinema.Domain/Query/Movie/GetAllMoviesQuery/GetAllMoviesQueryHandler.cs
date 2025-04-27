using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SzkolenieTechniczne2.Cinema.Domain.Query.Dtos;
using SzkolenieTechniczne2.Cinema.Domain.Repositories;

namespace SzkolenieTechniczne2.Cinema.Domain.Query.Movie.GetAllMoviesQuery
{
    internal sealed class GetMovieQueryHandler : IRequestHandler<GetAllMoviesQuery, List<MovieDTO>>
    {
        private readonly IMoviesRepository repository;

        public GetMovieQueryHandler(IMoviesRepository repository)
        {
            this.repository = repository;
        }

        public async Task<List<MovieDTO>> Handle(GetAllMoviesQuery query, CancellationToken cancellationToken)
        {
            var movies = await repository.GetAllAsync();

            return movies.Select(movie => new MovieDTO(movie.Id, movie.Name)).ToList();
        }
    }
}
