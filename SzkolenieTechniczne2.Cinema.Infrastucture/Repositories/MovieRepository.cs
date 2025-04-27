using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SzkolenieTechniczne2.Cinema.Domain.Entities;
using SzkolenieTechniczne2.Cinema.Domain.Repositories;

namespace SzkolenieTechniczne2.Cinema.Infrastucture.Repositories
{
    internal class MovieRepository : IMoviesRepository
    {
        private readonly CinemaTicketDbContext context;

        public MovieRepository(CinemaTicketDbContext context)
        {
            this.context = context;
        }

        public async Task AddAsync(Movie movie)
        {
            context.Movies.Add(movie);
        }

        public async Task<IEnumerable<Movie>> GetAllAsync()
        {
            return await context.Movies.ToListAsync();
        }

        public async Task<Movie> GetByIdAsync(long id)
        {
            return await context.Movies
                .Include(c => c.Seances)
                .ThenInclude(c => c.Tickets)
                .SingleOrDefaultAsync(x => x.Id == id);
        }

        public async Task<IEnumerable<MovieCategory>> GetMovieCategoriesAsync()
        {
            return await context.MovieCategories.ToListAsync();
        }

        public async Task<Movie> GetSeanceDetailsAsync(long movieId)
        {
            return await context.Movies.Where(x => x.Id == movieId).Include(t => t.Seances).FirstOrDefaultAsync();
        }

        public async Task<List<Seance>> GetSeancesByMoveIdAsync(long moveId)
        {
            return await context.Seances.Where(x => x.MovieId == moveId).ToListAsync();
        }

        public async Task<bool> IsMovieExistAsync(string name, int year)
        {
            return await context.Movies.AnyAsync(x => x.Name == name && x.Year == year);
        }

        public async Task<bool> IsSeanceExistAsync(DateTime seanceDate)
        {
            return await context.Seances.AnyAsync(x => x.Date == seanceDate);
        }

        public async Task RemoveAsync(Movie movie)
        {
            context.Movies.Remove(movie);
            await context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Movie movie)
        {
            context.Movies.Update(movie);
            await context.SaveChangesAsync();
        }
    }
}
