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
    public class BlVisionMovieRepository : BlRepository<VisionMovie>, IBlVisionMovieRepository
    {
        IBISessionRepository _bISessionRepository;
        IBIMovieRepository _bIMovieRepository;
        private readonly CinemaApplicationContext _context;
        public BlVisionMovieRepository(IBISessionRepository bISessionRepository, IBIMovieRepository bIMovieRepository, IMapper mappingProfile) : base(mappingProfile)
        {
            _bISessionRepository = bISessionRepository;
            _bIMovieRepository = bIMovieRepository;
            _context = DbContextService.GetDbContext();
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

        //public GetVisionMovieListVM GetCardVisionMovieList() {

        //    //var result = from vm in _context.Set<VisionMovie>()
        //    //             join m in _context.Set<Movie>() on vm.MovieId equals m.Id
        //    //             select new
        //    //             {
        //    //                 m.Name,
        //    //                 m.Genre,
        //    //                 m.Duration,
        //    //                 m.Description,
        //    //                 m.PosterName,
        //    //                 m.ReleaseDate,
        //    //                 m.PngBase64
        //    //             };
                
        //    return result;
        //}


        public override bool Add<TAddVM>(TAddVM model)
        {
            //ToDo return string dön hata mesajı yaz çakışma gerçekleşti diye ve bu stringi returnle
            var visionMovieAddParam = model as VisionMovieAddVM;

            if (!VisionMovieControl(visionMovieAddParam))
                return false;    
            // ToDo toaster eklendiği zaman ilgili mesaj yazdırılacak.
            return base.Add(model);
        }

        public bool VisionMovieControl(VisionMovieAddVM model)
        {
            var visionMovieList = GetWhereWithType<VisionMovieListVM>(a => a.MovieHouseId == model.MovieHouseId && a.DisplayDate == DateTime.Parse(model.DisplayDate)).ToList();
            var modelStartTime = Convert.ToDateTime(_bISessionRepository.GetSingle(x => x.Id == model.SessionId).StartTime).TimeOfDay;

            var duration = _bIMovieRepository.GetSingle(x => x.Id == model.MovieId).Duration;
            var hour = duration / 60;
            var minute = duration % 60;
            var modelEndTime = modelStartTime + Convert.ToDateTime(hour + ":" + minute).TimeOfDay;

            foreach (var item in visionMovieList)
            {
                hour = item.Duration / 60;
                minute = item.Duration % 60;
                var movieEndTime = Convert.ToDateTime(hour + ":" + minute).TimeOfDay + Convert.ToDateTime(item.SessionStartTime).TimeOfDay;

                if (Convert.ToDateTime(item.SessionStartTime).TimeOfDay <= modelStartTime && modelStartTime <= movieEndTime)
                    return false;
                if (modelEndTime >= Convert.ToDateTime(item.SessionStartTime).TimeOfDay && modelStartTime <= movieEndTime)
                    return false;
            }
            return (true);
        }

        public List<DropDownListVM> GetDisplayDateList(long id)
        {
            var visionMovieList = GetWhere(a => a.MovieId == id).ToList();
            return _mappingProfile.Map<List<VisionMovie>, List<DropDownListVM>>(visionMovieList).GroupBy(x => x.Label).Select(g => g.First()).ToList();
        }

        public bool ControlVisionMovieList(long id)
        {
            var visionMovieControl = GetWhere(a => a.MovieId == id).ToList();
            if (visionMovieControl.Count()>0)
            {
                return true;
            }
            return false;
        }
    }
}
