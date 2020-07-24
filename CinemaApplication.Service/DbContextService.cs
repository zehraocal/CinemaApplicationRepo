using CinemaApplication.DAL.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace CinemaApplication.Service
{
    public static class DbContextService
    {
        // DAL katmanında context yaratıldıktan sonra static bir şekilde servis oluşturulur.
        public static IServiceCollection AddDbContextService(this IServiceCollection services)

        // This ile IServise classına eklenti yapabiliriz böylelikle startupta tekrardan yapmamıza gerek kalmaz
        {
            services.AddDbContext<CinemaApplicationContext>(option => option.UseSqlServer("Server=.;Database=CinemaDb;Trusted_Connection=True;"), ServiceLifetime.Transient);
            return services;
        }

        public static CinemaApplicationContext GetDbContext()
        {
            IServiceCollection services = new ServiceCollection();
            services.AddDbContextService();
            ServiceProvider serviceProvider = services.BuildServiceProvider();
            return serviceProvider.GetService<CinemaApplicationContext>();
        }
    }
}
