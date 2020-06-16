using AutoMapper;
using CinemaApplication.BL.Repository.Interface;
using CinemaApplication.DAL.Contexts;
using CinemaApplication.Entity.Entities;
using CinemaApplication.Entity.ViewModels;
using CinemaApplication.Service;
using Microsoft.EntityFrameworkCore;

namespace CinemaApplication.BL.Repository.Concreate
{
    public class BlMovieHouseRepository : BlRepository<MovieHouse>, IBlMovieHouseRepository
    {
        IBlMovieHouseRepository _blMovieHouseRepository;
        public BlMovieHouseRepository(IMapper mappingProfile, IBlMovieHouseRepository blMovieHouseRepository) : base(mappingProfile)
        {
            _blMovieHouseRepository = blMovieHouseRepository;
        }
        public override bool Add<TAddVM>(TAddVM model)
        {
            MovieHouse movieHouse = _mappingProfile.Map<MovieHouse>(model);

            return base.Add(movieHouse);
        }
        public override bool Remove(long id)
        {
            MovieHouse deleteMovieHouse = _blMovieHouseRepository.GetSingle(a => a.Id == id);
            return base.Remove(deleteMovieHouse);
        }
        


    }

}
