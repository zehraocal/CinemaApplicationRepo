﻿using System;
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
            var Ticket=_blMovieTicketRepository.GetSingle(a => a.MovieHouseId == model.MovieHouseId && a.MovieId == model.MovieId && a.SessionId == model.SessionId && a.SeatName == model.SeatName);
            Boolean result;
            if (Ticket != null)
            {
               result = true;
            }
            else { result = false; }
            return Ok(result);
        }

        [HttpPost]
        public IActionResult AddMovieTicket(MovieTicketAddVM model)
        {
            _blMovieTicketRepository.Add(model);
            return Ok(true);
        }


    }
}