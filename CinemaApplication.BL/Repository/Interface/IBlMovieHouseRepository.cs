using CinemaApplication.Entity.Entities;
using CinemaApplication.Entity.ViewModels;
using System.Collections.Generic;
using System.Threading;

namespace CinemaApplication.BL.Repository.Interface
{
    public interface IBlMovieHouseRepository : IBlRepository<MovieHouse>
    {
        List<MovieHouse> GetWhereMovieHouse(MovieHouseGetVM model);
    }
}
