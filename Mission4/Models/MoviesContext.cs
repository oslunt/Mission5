using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mission4.Models
{
    public class MoviesContext : DbContext
    {
        public MoviesContext (DbContextOptions<MoviesContext> options) : base(options)
        {
            // Nothing as of right now
        }
        public DbSet<MovieForm> Responses { get; set; }
        protected override void OnModelCreating(ModelBuilder mb)
        {
            mb.Entity<MovieForm>().HasData(
                    new MovieForm
                    {
                        movieId = 1,
                        category = "Action/Adventure",
                        title = "Inception",
                        year = 2010,
                        director = "Christopher Nolan",
                        rating = "PG-13"
                    },
                    new MovieForm
                    {
                        movieId = 2,
                        category = "Fantasy/Action",
                        title = "Demon Slayer: Kimetsu no Yaiba – The Movie: Mugen Train",
                        year = 2020,
                        director = "Haruo Sotozaki",
                        rating = "R",
                        note = "Watch TV show first"
                    },
                    new MovieForm
                    {
                        movieId = 3,
                        category = "Sci-fi",
                        title = "Star Wars: Episode IV - A New Hope",
                        year = 1977,
                        director = "George Lucas",
                        rating = "PG",
                        lentTo = "Mom"
                    }
                );
        }
    }
}
