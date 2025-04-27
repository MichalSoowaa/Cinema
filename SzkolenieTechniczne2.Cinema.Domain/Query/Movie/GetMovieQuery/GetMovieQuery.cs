using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SzkolenieTechniczne2.Cinema.Domain.Query.Dtos;

namespace SzkolenieTechniczne2.Cinema.Domain.Query.Movie.GetMovieQuery
{
    public sealed record GetMovieQuery(long MovieId) : IRequest<MovieDetailsDTO>;
}
