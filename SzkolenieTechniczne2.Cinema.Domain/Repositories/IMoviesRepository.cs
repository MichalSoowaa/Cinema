using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SzkolenieTechniczne2.Cinema.Domain.Entities;

namespace SzkolenieTechniczne2.Cinema.Domain.Repositories
{
    public interface IMoviesRepository
    {
        Movie GetById(long id);
        IEnumerable<Movie> GetAll();
        IEnumerable<MovieCategory> GetMovieCategories();
        bool IsMovieExist(string name, int year);
        bool IsSeanceExist(DateTime seanceDate);
        void Add(Movie movie);
        void Update(Movie movie);
        Movie GetSeanceDetails(long movieId);
        List<Seance> GetSeancesByMoveId(long moveId);
        void Remove(Movie movie);
    }
}
