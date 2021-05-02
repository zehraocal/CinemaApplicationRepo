using AutoMapper;
using CinemaApplication.Entity.Entities;
using CinemaApplication.Entity.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
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
            CreateMap<MovieTicketGetVM, MovieTicket>();
            CreateMap<UserAddVM, User>();
            CreateMap<SessionUpdateVM, Session>();
            CreateMap<VisionMovieAddVM, VisionMovie>();
            CreateMap<VisionMovieUpdateVM, VisionMovie>();
            CreateMap<VisionMovie, Movie>();
            CreateMap<Movie, GetMovieListVM>();
            CreateMap<Movie, DropDownListVM>()
                .ForMember(member1 => member1.Value, member2 => member2.MapFrom(x => x.Id))
                .ForMember(member1 => member1.Label, member2 => member2.MapFrom(x => x.Name));
            CreateMap<VisionMovie, DisplayDateList>()
                .ForMember(member1 => member1.DisplayDate, member2 => member2.MapFrom(x => x.DisplayDate));
            CreateMap<Movie, DetailMovieVM>()
                .ForMember(member1 => member1.DirectorName, member2 => member2.MapFrom(x => string.Join(", ", x.MovieCastings.Where(a => a.Casting.Type == 2).Select(a => a.Casting.Name))))
                .ForMember(member1 => member1.ActorName, member2 => member2.MapFrom(x => string.Join(", ", x.MovieCastings.Where(a=>a.Casting.Type==1).Select(a=>a.Casting.Name))));
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
            CreateMap<Movie, GetVisionMovieListVM>();
            
            CreateMap<VisionMovie, DropDownListVM>()
                   .ForMember(member1 => member1.Value, member2 => member2.MapFrom(x => x.Id))
                   .ForMember(member1 => member1.Label, member2 => member2.MapFrom(x => x.DisplayDate.ToShortDateString()));
            CreateMap<MovieHouse, DropDownListVM>()
                  .ForMember(member1 => member1.Value, member2 => member2.MapFrom(x => x.Id))
                  .ForMember(member1 => member1.Label, member2 => member2.MapFrom(x => x.Name));
            CreateMap<MovieTicketAddVM, MovieTicket>();
        }
    }
}
