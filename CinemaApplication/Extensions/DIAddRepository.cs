using CinemaApplication.BL.Repository.Concreate;
using CinemaApplication.BL.Repository.Interface;
using Microsoft.Extensions.DependencyInjection;

namespace CinemaApplication.Extensions
{
    static public class DIAddRepository
    {
        public static IServiceCollection AddRepository(this IServiceCollection services)
        {
            services.AddSingleton<IBlMovieHouseRepository, BlMovieHouseRepository>();
            services.AddSingleton<IBIMovieRepository, BlMovieRepository>();
            return services;
        }
    }
}
