using MediatR;
using SzkolenieTechniczne2.Cinema.Domain.Query.DTOs;
using SzkolenieTechniczne2.Cinema.Domain.Repositories;

namespace SzkolenieTechniczne2.Cinema.Domain.Query.Movie.GetCategories
{
    public class GetCategoriesQueryHandler : IRequestHandler<GetCategoriesQuery, List<CategoryDTO>>
    {
        private readonly IMoviesRepository _repository;

        public GetCategoriesQueryHandler(IMoviesRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<CategoryDTO>> Handle(GetCategoriesQuery query, CancellationToken cancellationToken)
        {
            var movies = await _repository.GetMovieCategoriesAsync();

            return movies.Select(movie => new CategoryDTO(movie.Id, movie.Name)).ToList();
        }
    }
}
