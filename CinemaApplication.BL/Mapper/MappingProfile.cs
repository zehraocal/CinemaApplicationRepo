using AutoMapper;
using CinemaApplication.Entity.Entities;
using CinemaApplication.Entity.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace CinemaApplication.BL.Mapper
{
    public class MappingProfile :Profile
    {
        public MappingProfile()
        {
            // ** MovieHouse Mappings **
            CreateMap<MovieHouseAddVM, MovieHouse>();
            CreateMap<MovieHouseUpdateVM, MovieHouse>();
            CreateMap<MovieAddVM, Movie>();
            CreateMap<MovieUpdateVM, Movie>();
            CreateMap<SessionAddVM, Session>();
            CreateMap<SessionUpdateVM, Session>();
            CreateMap<VisionMovieAddVM, VisionMovie>();
            CreateMap<VisionMovieUpdateVM, VisionMovie>();
        }
    }
}
