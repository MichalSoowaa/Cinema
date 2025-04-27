using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SzkolenieTechniczne2.Cinema.Domain.Command.Movie.Delete
{
    public sealed record DeleteMovieCommand(long Id) : IRequest<Result>;
}
