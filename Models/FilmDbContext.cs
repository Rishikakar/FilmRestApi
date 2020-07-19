using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace assday5.Models
{
    public class FilmDbContext:DbContext
    {

        public FilmDbContext(DbContextOptions<FilmDbContext> options) : base(options)
        {

        }
    

        public DbSet<Languages> Languages { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Reviews> Review { get; set; }
        public DbContextOptions<FilmDbContext> Options { get; }
    }
}
