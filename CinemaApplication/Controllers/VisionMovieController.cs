using System;
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
    public class VisionMovieController : ControllerBase
    {
        IBlVisionMovieRepository _blVisionMovieRepository;
        public VisionMovieController(IBlVisionMovieRepository blVisionMovieRepository)
        {
            _blVisionMovieRepository = blVisionMovieRepository;
        }


        [HttpPost]
        public IActionResult GetVisionMovie(VisionMovieGetVM model)
        {
            var movies = _blVisionMovieRepository.GetAll();
            if (!string.IsNullOrEmpty((model.Movie.Name)))
            {
                movies = _blVisionMovieRepository.GetWhere(y=> y.Movie.Name.Contains(model.Movie.Name)).ToList();
            }
            return Ok(movies);
        }
        [HttpPost]
        public IActionResult AddSession(SessionAddVM model)
        {
            _blVisionMovieRepository.Add(model);
            return Ok(true);
        }


        [HttpDelete("{id}")]
        public IActionResult DeleteSession(long id)
        {
            _blVisionMovieRepository.Remove(id);
            return Ok(true);
        }

        [HttpPut]
        public IActionResult UpdateSession(SessionUpdateVM param)
        {
            return Ok(_blVisionMovieRepository.Update(param));
        }


    }
}