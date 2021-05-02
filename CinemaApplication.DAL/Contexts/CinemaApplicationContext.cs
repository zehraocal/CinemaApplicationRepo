using CinemaApplication.Entity.Entities;
using Microsoft.EntityFrameworkCore;

namespace CinemaApplication.DAL.Contexts
{
    public class CinemaApplicationContext : DbContext
    {
        //Context ve servis işlemlerinden sonra DAL klasorunde powershell açılır ve migrations işlemleri yapılır.
        public CinemaApplicationContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<MovieHouse> MovieHouses { get; set; }
        public DbSet<Session> Sessions { get; set; }
        public DbSet<VisionMovie> VisionMovies { get; set; }
        public DbSet<Casting> Castings { get; set; }
        public DbSet<MovieCasting> MovieCastings { get; set; }
        public DbSet<MovieTicket> MovieTickets { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
