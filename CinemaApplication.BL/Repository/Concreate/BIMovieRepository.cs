using AutoMapper;
using CinemaApplication.BL.Repository.Interface;
using CinemaApplication.DAL.Contexts;
using CinemaApplication.Entity.Entities;
using CinemaApplication.Entity.Helper;
using CinemaApplication.Entity.ViewModels;
using CinemaApplication.Service;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace CinemaApplication.BL.Repository.Concreate
{
    public class BlMovieRepository : BlRepository<Movie>, IBIMovieRepository
    {
        private readonly CinemaApplicationContext _context;
        public BlMovieRepository(IMapper mappingProfile) : base(mappingProfile)
        {  //VisionMoviede movie çağrığımız için tekrardan movie visionmovieyi çağırınca hata aldık.
            _context = DbContextService.GetDbContext();
        }


        public override bool Add<TAddVM>(TAddVM model)
        {
            var movieAddParam = model as MovieAddVM;
            var spl = movieAddParam.PngBase64.Split('/')[1];
            var format = spl.Split(';')[0];
            var stringConvert = movieAddParam.PngBase64.Replace($"data:image/{format};base64,", String.Empty).Replace($"data:application/{format};base64,", String.Empty);

            var bytes = Convert.FromBase64String(stringConvert);
            var folderName = Path.Combine("wwwroot", "img", "movies");
            string filedir = Path.Combine(Directory.GetCurrentDirectory(), folderName);

            if (!Directory.Exists(filedir))
            {
                Directory.CreateDirectory(filedir);
            }

            var fileName = movieAddParam.PosterName + "." + format;
            string file = Path.Combine(filedir, fileName);

            if (bytes.Length > 0)
            {
                using (var stream = new FileStream(file, FileMode.Create))
                {
                    stream.Write(bytes, 0, bytes.Length);
                    stream.Flush();
                }
            }

            var fileFullPath = "wwwroot/img/movies/" + fileName;
            movieAddParam.PngBase64 = fileFullPath;
            return base.Add(model);
        }

        public override bool Update<TAddVM>(TAddVM model)
        {
            var movieAddParam = model as MovieUpdateVM;
            var spl = movieAddParam.PngBase64.Split('/')[1];
            var format = spl.Split(';')[0];
            var stringConvert = movieAddParam.PngBase64.Replace($"data:image/{format};base64,", String.Empty).Replace($"data:application/{format};base64,", String.Empty);

            var bytes = Convert.FromBase64String(stringConvert);
            var folderName = Path.Combine( "wwwroot", "img", "movies");
            string filedir = Path.Combine(Directory.GetCurrentDirectory(), folderName);

            if (!Directory.Exists(filedir))
            {
                Directory.CreateDirectory(filedir);
            }

            var fileName = movieAddParam.PosterName + "." + format;
            string file = Path.Combine(filedir, fileName);

            if (bytes.Length > 0)
            {
                using (var stream = new FileStream(file, FileMode.Create))
                {
                    stream.Write(bytes, 0, bytes.Length);
                    stream.Flush();
                }
            }

            var fileFullPath = "wwwroot/img/movies/" + fileName;
            movieAddParam.PngBase64 = fileFullPath;
            return base.Update(model);
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