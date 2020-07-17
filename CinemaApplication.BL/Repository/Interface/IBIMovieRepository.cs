using CinemaApplication.Entity.Entities;
using CinemaApplication.Entity.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CinemaApplication.BL.Repository.Interface
{
    public interface IBIMovieRepository : IBlRepository<Movie>
    {
        List<Movie> GetWhereMovieList(MovieGetVM model);


    }
}
