using CinemaApplication.DAL.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;


namespace CinemaApplication.DAL
{
    //Service katmanında oluşturulan provider burada belirtildi.
    class DesignTimeDbContextFactory : IDesignTimeDbContextFactory <CinemaApplicationContext>
    {
        public CinemaApplicationContext CreateDbContext(string[] args)
        {
            DbContextOptionsBuilder<CinemaApplicationContext> builder = new DbContextOptionsBuilder<CinemaApplicationContext>();
            builder.UseSqlServer("Server=.;Database=CinemaDb;Trusted_Connection=True;");
            return new CinemaApplicationContext(builder.Options);

        }
    }
}
