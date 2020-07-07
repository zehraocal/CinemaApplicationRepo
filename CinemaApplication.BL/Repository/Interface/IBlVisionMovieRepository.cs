using CinemaApplication.Entity.Entities;
using CinemaApplication.Entity.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace CinemaApplication.BL.Repository.Interface
{
    public interface IBlVisionMovieRepository : IBlRepository<VisionMovie>
    {
        List<VisionMovieListVM> GetVisionMovieList(VisionMovieGetVM model);
    }    
}
