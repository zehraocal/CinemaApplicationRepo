using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CinemaApplication.BL.Repository.Interface;
using CinemaApplication.Entity.Entities;
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
        public IActionResult GetVisionMovieList(VisionMovieGetVM model)
        {

            return Ok(_blVisionMovieRepository.GetVisionMovieList(model));
        }

        [HttpGet("{id}")]
        public IActionResult GetSingleVisionMovieList(long id)
        {
            return Ok(_blVisionMovieRepository.GetSingle(x => x.MovieId == id));
        }

        public IActionResult VisionMovieControl(VisionMovieAddVM model)
        {
            var movie = _blVisionMovieRepository.VisionMovieControl(model);
            return Ok(true);
        }

        [HttpPost]
        public IActionResult AddVisionMovie(VisionMovieAddVM model)
        {
            return Ok(_blVisionMovieRepository.Add(model));
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteVisionMovie(long id)
        {
            _blVisionMovieRepository.Remove(id);
            return Ok(true);
        }

        [HttpPut]
        public IActionResult UpdateVisionMovie(VisionMovieUpdateVM param)
        {
            DateTime.Parse(param.DisplayDate);
            return Ok(_blVisionMovieRepository.Update(param));
        }

        [HttpGet]
        public IActionResult GetDropDownList()
        {
            return Ok(_blVisionMovieRepository.GetAllWithType<VisionMovieListVM>());
        }


        [HttpGet("{id}")]
        public IActionResult GetDisplayDateList(long id)
        {
            var a = _blVisionMovieRepository.GetDisplayDateList(id);
            return Ok(a);
        }

        [HttpGet("{id}")]
        public IActionResult ControlVisionMovieList(long id)
        {
            var movie = _blVisionMovieRepository.ControlVisionMovieList(id);

            return Ok(movie);
        }

    }
}