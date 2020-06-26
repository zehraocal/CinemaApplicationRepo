﻿using CinemaApplication.BL.Repository;
using CinemaApplication.BL.Repository.Interface;
using CinemaApplication.Entity.Entities;
using CinemaApplication.Entity.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;
using System;
using System.Linq;

namespace CinemaApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class MovieHouseController : ControllerBase
    {
        IBlMovieHouseRepository _blMovieHouseRepository;


        public MovieHouseController(IBlMovieHouseRepository movieHouseRepository)
        {
            _blMovieHouseRepository = movieHouseRepository;
        }
        [HttpGet]
        public IActionResult GetMovieHouse()
        {
            return Ok(_blMovieHouseRepository.GetAll());
        }

        [HttpPost]
        public IActionResult GetWhereMovieHouse([FromBody]string name)
        {
            var movieHouses = _blMovieHouseRepository.GetWhere(y => y.Name.Contains(name)).ToList();
            return Ok(movieHouses);
        }

        [HttpPost]
        public IActionResult AddMovieHouse(MovieHouseAddVM model)
        {
            _blMovieHouseRepository.Add(model);
            return Ok(true);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteMovieHouse(long id)
        {          
            _blMovieHouseRepository.Remove(id);
            return Ok(true);
        }

        [HttpPut]
        public IActionResult UpdateMovieHouse(MovieHouseUpdateVM param)
        {
            return Ok(_blMovieHouseRepository.Update(param));
        }



    }




}