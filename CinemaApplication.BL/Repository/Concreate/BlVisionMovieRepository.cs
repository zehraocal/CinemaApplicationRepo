using AutoMapper;
using CinemaApplication.BL.Repository.Interface;
using CinemaApplication.Entity.Entities;
using CinemaApplication.Entity.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CinemaApplication.BL.Repository.Concreate
{
    public class BlVisionMovieRepository : BlRepository<VisionMovie>, IBlVisionMovieRepository
    {
        public BlVisionMovieRepository(IMapper mappingProfile) : base(mappingProfile)
        {
        }

        public List<VisionMovieListVM> GetVisionMovieList(VisionMovieGetVM model)
        {
            var movies = GetAllWithType<VisionMovieListVM>();
            if (model.MovieId.HasValue)
            {
                movies = GetWhereWithType<VisionMovieListVM>(y => y.MovieId == model.MovieId).ToList();
            }
            if (model.MovieHouseId.HasValue)
            {
                movies = GetWhereWithType<VisionMovieListVM>(y => y.MovieHouseId == model.MovieHouseId).ToList();
            }

            if (model.SessionId.HasValue)
            {
                movies = GetWhereWithType<VisionMovieListVM>(y => y.SessionId == model.SessionId).ToList();
            }
            if (model.DisplayDate.HasValue)
            {
                movies = GetWhereWithType<VisionMovieListVM>(y => y.DisplayDate == model.DisplayDate.Value.AddDays(1)).ToList();
            }
            return movies;
        }

    }
}
