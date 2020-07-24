using AutoMapper;
using CinemaApplication.BL.Repository.Interface;
using CinemaApplication.DAL.Contexts;
using CinemaApplication.Entity.Entities;
using CinemaApplication.Entity.ViewModels;
using CinemaApplication.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CinemaApplication.BL.Repository.Concreate
{
    public class BlMovieRepository : BlRepository<Movie>, IBIMovieRepository
    {
        CinemaApplicationContext _context;
        public BlMovieRepository(IMapper mappingProfile) : base(mappingProfile)
        {  //VisionMoviede movie çağrığımız için tekrardan movie visionmovieyi çağırınca hata aldık.
            _context = DbContextService.GetDbContext();
        }

        public List<Movie> GetWhereMovieList(MovieGetVM model)
        {
            var movie = GetAll().OrderBy(x => x.Name).ToList();

            if (!string.IsNullOrEmpty(model.Name))
            {
                movie = movie.Where(y => y.Name.ToUpper().Contains(model.Name.ToUpper())).ToList();
            }
            if (!string.IsNullOrEmpty(model.Genre))
            {
                movie = movie.Where(y => y.Genre.ToUpper().Contains(model.Genre.ToUpper())).ToList();
            }
            return movie;
        }

        public List<GetMovieListVM> GetVisionMovieList(GetMovieListVM model)
        {
            var result = GetAllWithType<GetMovieListVM>().Where(p => _context.Set<VisionMovie>().ToList().Any(p2 => p2.MovieId == p.Id)).ToList();
            if (!string.IsNullOrEmpty(model.Name))
            {
                result = GetAllWithType<GetMovieListVM>().Where(p => _context.Set<VisionMovie>().ToList().Any(p2 => p2.MovieId == p.Id)).ToList().Where(y => y.Name.ToUpper().Contains(model.Name.ToUpper())).ToList();
            }
            if (!string.IsNullOrEmpty(model.Genre))
            {
                result = GetAllWithType<GetMovieListVM>().Where(p => _context.Set<VisionMovie>().ToList().Any(p2 => p2.MovieId == p.Id)).ToList().Where(y => y.Genre.ToUpper().Contains(model.Genre.ToUpper())).ToList();
            }

            return result;
        }

        public List<GetMovieListVM> GetMovieList(GetMovieListVM model)
        {
            var result = GetAllWithType<GetMovieListVM>();
            if (!string.IsNullOrEmpty(model.Name))
            {
                result = result.Where(y => y.Name.ToUpper().Contains(model.Name.ToUpper())).ToList();
            }
            if (!string.IsNullOrEmpty(model.Genre))
            {
                result = result.Where(y => y.Genre.ToUpper().Contains(model.Genre.ToUpper())).ToList();
            }
            return result;
        }
        
    }
}