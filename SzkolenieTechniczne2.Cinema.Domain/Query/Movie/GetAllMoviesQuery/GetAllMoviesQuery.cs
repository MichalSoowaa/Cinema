using MediatR;
using SzkolenieTechniczne2.Cinema.Domain.Query.Dtos;

namespace SzkolenieTechniczne2.Cinema.Domain.Query.Movie.GetAllMoviesQuery
{
    public sealed record GetAllMoviesQuery : IRequest<List<MovieDTO>>;
}
