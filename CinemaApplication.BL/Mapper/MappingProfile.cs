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
            // ** Org MovieHouse Mappings **
            CreateMap<MovieHouse, MovieHouseAddVM>();
            CreateMap<MovieHouseAddVM, MovieHouse>();
        }
    }
}
