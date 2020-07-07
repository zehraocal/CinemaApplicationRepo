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
    public class BlMovieRepository : BlRepository<Movie>, IBIMovieRepository
    {
        public BlMovieRepository(IMapper mappingProfile) : base(mappingProfile)
        {
        }
        public List<Movie> GetWhereMovie(MovieGetVM model)

        {
            var movie = GetAll().OrderBy(x => x.Name).ToList();

            if (!string.IsNullOrEmpty(model.Name))
            {
                movie = GetWhere(y => y.Name.ToUpper().Contains(model.Name.ToUpper())).ToList();
            }
            if (!string.IsNullOrEmpty(model.Genre))
            {
                movie = GetWhere(y => y.Genre.ToUpper().Contains(model.Genre.ToUpper())).ToList();
            }
            return movie;

        }
    }
}
