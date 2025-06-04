using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SzkolenieTechniczne2.Cinema.Domain.Entities;

namespace SzkolenieTechniczne2.Cinema.Infrastucture
{
    public class CinemaTicketDbContext : DbContext
    {
        public CinemaTicketDbContext(DbContextOptions<CinemaTicketDbContext> options) : base(options)
        {}

        public DbSet<Movie> Movies { get; set; }
        public DbSet<Seance> Seances { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<MovieCategory> MovieCategories { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost\\SQLEXPRESS;Database=cinema;Trusted_Connection=True;TrustServerCertificate=True;",
                x => x.MigrationsHistoryTable("__EFMigrationsHistory", "Cinema"));
        }
    }
}
