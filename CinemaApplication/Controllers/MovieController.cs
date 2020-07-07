﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CinemaApplication.BL.Repository.Interface;
using CinemaApplication.Entity.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CinemaApplication.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]

    public class MovieController : ControllerBase
    {
        IBIMovieRepository _blMovieRepository;
        public MovieController(IBIMovieRepository movieRepository)
        {
            _blMovieRepository = movieRepository;
        }

        [HttpGet]
        public IActionResult GetMovie()
        {
            return Ok(_blMovieRepository.GetAll());
        }

        [HttpPost]
        public IActionResult GetWhereMovie(MovieGetVM model)
        {
            return Ok(_blMovieRepository.GetWhereMovie(model));
        }

        [HttpPost]
        public IActionResult AddMovie(MovieAddVM model)
        {
            _blMovieRepository.Add(model);
            return Ok(true);
        }
        
        [HttpDelete("{id}")]
        public IActionResult DeleteMovie(long id)
        {
            _blMovieRepository.Remove(id);
            return Ok(true);
        }

        [HttpPut]
        public IActionResult UpdateMovie(MovieUpdateVM param)
        {
            return Ok(_blMovieRepository.Update(param));
        }

        [HttpGet]
        public IActionResult GetDropDownList()
        {
            return Ok(_blMovieRepository.GetAllWithType<DropDownListVM>());
        }

    }
}