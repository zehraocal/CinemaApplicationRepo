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

        
    }

}
