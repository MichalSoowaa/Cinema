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
        Task<Movie> GetByIdAsync(long id);
        Task<IEnumerable<Movie>> GetAllAsync();
        Task<IEnumerable<MovieCategory>> GetMovieCategoriesAsync();
        Task<bool> IsMovieExistAsync(string name, int year);
        Task<bool> IsSeanceExistAsync(DateTime seanceDate);
        Task AddAsync(Movie movie);
        Task UpdateAsync(Movie movie);
        Task<Movie> GetSeanceDetailsAsync(long movieId);
        Task<List<Seance>> GetSeancesByMoveIdAsync(long moveId);
        Task RemoveAsync(Movie movie);
    }
}
