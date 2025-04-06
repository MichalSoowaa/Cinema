using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SzkolenieTechniczne2.Cinema.Domain.Command.Movie.Create
{
    public record CreateMovieCommand(string Name, int Year, int SeanceTime, long MovieCategoryId) : ICommand<Result>;   
}
