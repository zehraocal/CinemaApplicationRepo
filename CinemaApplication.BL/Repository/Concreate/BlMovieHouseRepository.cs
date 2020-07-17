using AutoMapper;
using CinemaApplication.BL.Repository.Interface;
using CinemaApplication.DAL.Contexts;
using CinemaApplication.Entity.Entities;
using CinemaApplication.Entity.ViewModels;
using CinemaApplication.Service;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CinemaApplication.BL.Repository.Concreate
{
    public class BlMovieHouseRepository : BlRepository<MovieHouse>, IBlMovieHouseRepository
    {     
        public BlMovieHouseRepository(IMapper mappingProfile) : base(mappingProfile)
        {
        }
        public List<MovieHouse> GetWhereMovieHouseList(MovieHouseGetVM model)
        {
            var movieHouses = GetAll().OrderBy(x => x.Name).ToList();
            if (!string.IsNullOrEmpty(model.Name))
            {
                movieHouses = GetWhere(y => y.Name.ToUpper().Contains(model.Name.ToUpper())).ToList();
            }
            return movieHouses;
        }


    }

}
