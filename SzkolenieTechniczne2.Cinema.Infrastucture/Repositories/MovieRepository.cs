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

        public void Add(Movie movie)
        {
            context.Movies.Add(movie);
        }

        public IEnumerable<Movie> GetAll()
        {
            return context.Movies.ToList();
        }

        public Movie GetById(long id)
        {
            return context.Movies.Include(c => c.Seances).ThenInclude(c => c.Tickets).SingleOrDefault(x => x.Id == id);
        }

        public IEnumerable<MovieCategory> GetMovieCategories()
        {
            return context.MovieCategories.ToList();
        }

        public Movie GetSeanceDetails(long movieId)
        {
            return context.Movies.Where(x => x.Id == movieId).Include(t => t.Seances).FirstOrDefault();
        }

        public List<Seance> GetSeancesByMoveId(long moveId)
        {
            return context.Seances.Where(x => x.MovieId == moveId).ToList();
        }

        public bool IsMovieExist(string name, int year)
        {
            return context.Movies.Any(x => x.Name == name && x.Year == year);
        }

        public bool IsSeanceExist(DateTime seanceDate)
        {
            return context.Seances.Any(x => x.Date == seanceDate);
        }

        public void Remove(Movie movie)
        {
            context.Remove(movie);
        }

        public void Update(Movie movie)
        {
            context.Update(movie);
        }
    }
}
