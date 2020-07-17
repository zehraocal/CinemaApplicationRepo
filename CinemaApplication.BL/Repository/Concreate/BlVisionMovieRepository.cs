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
    public class BlVisionMovieRepository : BlRepository<VisionMovie>, IBlVisionMovieRepository
    {
        IBISessionRepository _bISessionRepository;
        IBIMovieRepository _bIMovieRepository;
        public BlVisionMovieRepository(IBISessionRepository bISessionRepository, IBIMovieRepository bIMovieRepository, IMapper mappingProfile) : base(mappingProfile)
        {
            _bISessionRepository = bISessionRepository;
            _bIMovieRepository = bIMovieRepository;
        }

        public List<VisionMovieListVM> GetVisionMovieList(VisionMovieGetVM model)
        {

            var movies = GetAllWithType<VisionMovieListVM>();
            if (model.MovieId.HasValue)
            {
                movies = movies.Where(y => y.MovieId == model.MovieId).ToList();
            }
            if (model.MovieHouseId.HasValue)
            {
                movies = movies.Where(y => y.MovieHouseId == model.MovieHouseId).ToList();
            }

            if (model.SessionId.HasValue)
            {
                movies = movies.Where(y => y.SessionId == model.SessionId).ToList();
            }
            if (!String.IsNullOrEmpty(model.DisplayDate))
            {

                movies = movies.Where(y => (y.DisplayDate).ToShortDateString() == DateTime.Parse(model.DisplayDate).ToShortDateString()).ToList();
            }
            return movies;
        }

        public override bool Add<TAddVM>(TAddVM model)
        {//ToDo return string dön hata mesajı yaz çakışma gerçekleşti diye ve bu stringi returnle
            var visionMovieAddParam = model as VisionMovieAddVM;
            if (!VisionMovieControl(visionMovieAddParam))
                return false;    
            // ToDo toaster eklendiği zaman ilgili mesaj yazdırılacak.
            return base.Add(model);
        }
        public bool VisionMovieControl(VisionMovieAddVM model)
        {
            var visionMovies = GetAllWithType<VisionMovieListVM>();
            visionMovies = visionMovies.Where(a => a.MovieHouseId == model.MovieHouseId && a.DisplayDate == DateTime.Parse(model.DisplayDate)).ToList();

            var sessions = GetAllWithType<VisionMovieListVM>();
            var startTime = sessions.FirstOrDefault(x => x.SessionId == model.SessionId).SessionStartTime;
            var modelStartTime = Convert.ToDateTime(startTime).TimeOfDay;

            var movieStartTime = visionMovies.ToList().FirstOrDefault(a => Convert.ToDateTime(a.SessionStartTime).TimeOfDay == modelStartTime || Convert.ToDateTime(a.SessionStartTime).TimeOfDay < modelStartTime);

            foreach (var item in visionMovies)
            {
                var movieDuration = item.Duration;
                var Hour = movieDuration / 60;
                var Minute = (movieDuration % 60);
                string endTime = (Hour + ":" + Minute);
                var movieEndTime = Convert.ToDateTime(endTime).TimeOfDay + Convert.ToDateTime(item.SessionStartTime).TimeOfDay;

                if (movieStartTime != null && modelStartTime < movieEndTime)
                {
                    return false;
                }
            }
            return (true);
        }
    }
}
