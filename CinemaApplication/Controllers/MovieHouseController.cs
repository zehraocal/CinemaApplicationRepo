using CinemaApplication.BL.Repository;
using CinemaApplication.BL.Repository.Interface;
using CinemaApplication.Entity.Entities;
using Microsoft.AspNetCore.Mvc;

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

        public IActionResult GetMovieHouse()
        {
            return Ok(_blMovieHouseRepository.GetAll());
        }

        [HttpPost]
        public IActionResult AddMovieHouse(MovieHouse model)
        {         
            _blMovieHouseRepository.Add(model);
            return Ok(true);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteMovieHouse(int id)
        {
            MovieHouse DeleteMovieHouse = _blMovieHouseRepository.GetSingle(a => a.Id == id);
            _blMovieHouseRepository.Remove(DeleteMovieHouse);
            return Ok(true);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateMovieHouse(int id, MovieHouse model)
        {
            MovieHouse UpdateMovieHouse = _blMovieHouseRepository.GetSingle(a => a.Id == id);
            UpdateMovieHouse.Name = model.Name;
            UpdateMovieHouse.Capacity = model.Capacity;

            _blMovieHouseRepository.Update(UpdateMovieHouse);

            return Ok(UpdateMovieHouse);
        }

    }
}