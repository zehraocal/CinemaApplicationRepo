using AutoMapper;
using CinemaApplication.BL.Repository.Interface;
using CinemaApplication.Entity.Entities;
using System;
using CinemaApplication.DAL.Contexts;
using System.Collections.Generic;
using System.Text;
using CinemaApplication.Service;
using CinemaApplication.Entity.ViewModels;

namespace CinemaApplication.BL.Repository.Concreate
{
    public class BIMovieTicketRepository : BlRepository<MovieTicket>, IBIMovieTicketRepository
    {
      
        public BIMovieTicketRepository(IMapper mappingProfile) : base(mappingProfile)
        {
           
        }

        //public MovieTicket GetMovieTicketList(MovieTicketGetVM model)
        //{
        //    var Ticket = GetSingle(a => a.MovieHouseId == model.MovieHouseId && a.MovieId == model.MovieId && a.SessionId == model.SessionId && a.SeatName == model.SeatName);
        //    return Ticket;
        //}
    }
}
