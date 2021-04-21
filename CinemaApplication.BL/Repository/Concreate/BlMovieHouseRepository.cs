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
        private readonly CinemaApplicationContext _context;
        public BlMovieHouseRepository(IMapper mappingProfile) : base(mappingProfile)
        {
            _context = DbContextService.GetDbContext();
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
        public List<DropDownListVM> GetMovieHouseDropDownList(MovieTicketGetSession model)
        {
            var visionMovie = _context.Set<VisionMovie>().FirstOrDefault(x=>x.Id == model.VisionMovieId).DisplayDate;
            var result = GetAllWithType<DropDownListVM>().Where(p =>  _context.Set<VisionMovie>().Where(a => a.DisplayDate == visionMovie && a.MovieId == model.MovieId).ToList().Any(p2 => p2.MovieHouseId == p.Value)).ToList();

            return result;
        }
    }

}
