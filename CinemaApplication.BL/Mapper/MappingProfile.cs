using AutoMapper;
using CinemaApplication.Entity.Entities;
using CinemaApplication.Entity.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace CinemaApplication.BL.Mapper
{
    public class MappingProfile : Profile
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
            CreateMap<VisionMovie, Movie>();
            CreateMap<Movie, GetMovieListVM>();
            CreateMap<Movie, DropDownListVM>()
                .ForMember(member1 => member1.Value, member2 => member2.MapFrom(x => x.Id))
                .ForMember(member1 => member1.Label, member2 => member2.MapFrom(x => x.Name));
            CreateMap<MovieHouse, DropDownListVM>()
               .ForMember(member1 => member1.Value, member2 => member2.MapFrom(x => x.Id))
               .ForMember(member1 => member1.Label, member2 => member2.MapFrom(x => x.Name));
            CreateMap<Session, DropDownListVM>()
               .ForMember(member1 => member1.Value, member2 => member2.MapFrom(x => x.Id))
               .ForMember(member1 => member1.Label, member2 => member2.MapFrom(x => x.StartTime)); 
            CreateMap<VisionMovie, VisionMovieListVM>()
               .ForMember(member1 => member1.MovieName, member2 => member2.MapFrom(x => x.Movie.Name))
               .ForMember(member1 => member1.MovieHouseName, member2 => member2.MapFrom(x => x.MovieHouse.Name))
               .ForMember(member1 => member1.Duration, member2 => member2.MapFrom(x => x.Movie.Duration))
               .ForMember(member1 => member1.SessionStartTime, member2 => member2.MapFrom(x => x.Session.StartTime));
            CreateMap<VisionMovie, GetVisionMovieListVM>()
                .ForMember(member1 => member1.Name, member2 => member2.MapFrom(x => x.Movie.Name))
                .ForMember(member1 => member1.Genre, member2 => member2.MapFrom(x => x.Movie.Genre))
                .ForMember(member1 => member1.Duration, member2 => member2.MapFrom(x => x.Movie.Duration))
                .ForMember(member1 => member1.Description, member2 => member2.MapFrom(x => x.Movie.Description))
                .ForMember(member1 => member1.PosterName, member2 => member2.MapFrom(x => x.Movie.PosterName))
                .ForMember(member1 => member1.ReleaseDate, member2 => member2.MapFrom(x => x.Movie.ReleaseDate));
        }
    }
}
