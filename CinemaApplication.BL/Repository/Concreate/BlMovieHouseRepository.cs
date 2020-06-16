using AutoMapper;
using CinemaApplication.BL.Repository.Interface;
using CinemaApplication.DAL.Contexts;
using CinemaApplication.Entity.Entities;
using CinemaApplication.Entity.ViewModels;
using CinemaApplication.Service;
using Microsoft.EntityFrameworkCore;
using System;

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

        public override bool Remove<TDeleteVM>(TDeleteVM model)
        {
            var deleteMovieHouse = GetSingle(a => a.Id == Convert.ToInt64(model));
            return base.Remove(deleteMovieHouse);
        }

        //public override bool Remove(long id)
        //{
        //    MovieHouse deleteMovieHouse = _blMovieHouseRepository.GetSingle(a => a.Id == id);
        //    return base.Remove(deleteMovieHouse);
        //}



    }

}
