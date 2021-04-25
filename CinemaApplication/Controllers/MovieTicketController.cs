using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using CinemaApplication.BL.Repository.Interface;
using Microsoft.AspNetCore.Mvc;
using CinemaApplication.Entity.ViewModels;

namespace CinemaApplication.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class MovieTicketController : ControllerBase
    {
        IBIMovieTicketRepository _blMovieTicketRepository;

        public MovieTicketController(IBIMovieTicketRepository movieTicketRepository)
        {
            _blMovieTicketRepository = movieTicketRepository;
        }

        [HttpPost]
        public IActionResult GetWhereMovieTicket(MovieTicketGetVM model)
        {
            var Ticket = _blMovieTicketRepository.GetWhere(a => a.MovieHouseId == model.MovieHouseId && a.MovieId == model.MovieId && a.SessionId == model.SessionId).ToList();
            List<string> movieTicketResponse = new List<string>();
            for (int i = 0; i < Ticket.Count; i++)
            {
                movieTicketResponse.Add(Ticket[i].SeatName);

            }
            return Ok(movieTicketResponse);
        }

        [HttpPost]
        public IActionResult GetWhereByMovieTicket(MovieTicketGetByVM model)
        {
            var ticket = _blMovieTicketRepository.GetWhere(a => a.MovieHouseId == model.MovieHouseId && a.MovieId == model.MovieId && a.SessionId == model.SessionId && a.SeatName == model.SeatName).ToList();
            int a = 0;
            if(ticket.Count != 0)
            {
                a++;
            }
            return Ok(a);
        }

        [HttpPost]
        public IActionResult AddMovieTicket(MovieTicketAddVM model)
        {
            _blMovieTicketRepository.Add(model);
            return Ok(true);
        }


    }
}