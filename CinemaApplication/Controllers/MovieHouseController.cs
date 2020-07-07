using CinemaApplication.BL.Repository;
using CinemaApplication.BL.Repository.Interface;
using CinemaApplication.Entity.Entities;
using CinemaApplication.Entity.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;
using System;
using System.Linq;

namespace CinemaApplication.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]

    public class MovieHouseController : ControllerBase
    {
        IBlMovieHouseRepository _blMovieHouseRepository;

        public MovieHouseController(IBlMovieHouseRepository movieHouseRepository)
        {
            _blMovieHouseRepository = movieHouseRepository;
        }

        [HttpPost]
        public IActionResult GetWhereMovieHouse(MovieHouseGetVM model)
        {
                  
            return Ok(_blMovieHouseRepository.GetWhereMovieHouse(model));
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

        [HttpGet]
        public IActionResult GetDropDownList()
        {
            return Ok(_blMovieHouseRepository.GetAllWithType<DropDownListVM>());
        }
    }
}