using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data.Entity;


namespace Assesment2_Q2.Models
{
    public class MoviesDbcontext : DbContext
    {
        public DbSet<Movie> Movies { get; set; }

        public MoviesDbcontext() : base("name=MoviesDbContext")
        {
        }
    }
}