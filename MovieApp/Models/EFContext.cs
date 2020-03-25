using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace MovieApp.Models
{
    class EFContext : DbContext
    {
        private const string connctionString = "server=localhost\\SQLEXPRESS;Database=MoviesDb;Trusted_Connection=True;";

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(connctionString);
        }

        public DbSet<Movie> Movies { get; set; }
        public DbSet<Actor> Actors { get; set; }
        public DbSet<MovActRelationship> MovActRelationships { get; set; }
    }
}
