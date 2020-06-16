using AutoMapper;
using CinemaApplication.BL.Repository.Interface;
using CinemaApplication.Entity.Entities;
using CinemaApplication.Entity.ViewModels;

namespace CinemaApplication.BL.Repository.Concreate
{
    public class BlMovieHouseRepository : BlRepository<MovieHouse>, IBlMovieHouseRepository
    {
        public BlMovieHouseRepository(IMapper mappingProfile) : base(mappingProfile)
        {
        }
        public override bool Add<TAddVM>(TAddVM model)
        {
            MovieHouse movieHouse = _mappingProfile.Map<MovieHouse>(model);
            return base.Add(movieHouse);
        }
    }

}
