using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SzkolenieTechniczne2.Cinema.Domain.Command.Movie.Update
{
    public sealed record UpdateMovieCommand(long Id, string Name, int Year, int SeanceTime, long MovieCategoryId) : IRequest<Result>;
}
