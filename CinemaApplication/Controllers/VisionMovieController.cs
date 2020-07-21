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
        public IActionResult GetVisionMovieList(VisionMovieGetVM model)
        {

            return Ok(_blVisionMovieRepository.GetVisionMovieList(model));
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

        [HttpGet]
        public IActionResult GetCardVisionMovieList()
        {
            return Ok(_blVisionMovieRepository.GetAllWithType<GetVisionMovieListVM>());
        }
    }
}