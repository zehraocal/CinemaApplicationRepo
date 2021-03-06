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

        [HttpPost]
        public IActionResult GetWhereMovieList(MovieGetVM model)
        {
            return Ok(_blMovieRepository.GetWhereMovieList(model));
        }

        [HttpGet("{id}")]
        public IActionResult GetSingleMovieList(long id)
        {
            return Ok(_blMovieRepository.GetSingleWithType<DetailMovieVM>(x => x.Id == id));
        }

        [HttpPost]
        public IActionResult AddMovie(MovieAddVM model)
        {
            DateTime.Parse(model.ReleaseDate);
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

        [HttpPost]
        public IActionResult GetMovieList(GetMovieListVM model)
        {
            var a = _blMovieRepository.GetMovieList(model);
            return Ok(_blMovieRepository.GetMovieList(model));
        }

        [HttpPost]
        public IActionResult GetVisionMovieList(GetMovieListVM model)
        {
            return Ok(_blMovieRepository.GetVisionMovieList(model));
        }

        [HttpGet]
        public IActionResult GetCardVisionMovieList()
        {

            return Ok(_blMovieRepository.GetAllWithType<GetVisionMovieListVM>().GroupBy(x => x.Name).Select(g => g.First()).ToList());
        }
    }
}