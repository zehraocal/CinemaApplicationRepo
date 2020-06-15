using CinemaApplication.BL.Repository;
using CinemaApplication.BL.Repository.Interface;
using CinemaApplication.Entity.Entities;
using CinemaApplication.Entity.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;
using System;

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
        public IActionResult AddMovieHouse(MovieHouseAddVM model)
        {
            //_blMovieHouseRepository.Add<Movie>(new Movie());


            //_blMovieHouseRepository.Add(new MovieHouse
            //{
            //    Capacity = model.Capacity,
            //    Name = model.Name
            //});
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


    #region Implicit & Explicit
    class Canli
    {
        public string Adi { get; set; }
        public string Yasi { get; set; }
        public bool Cinsiyet { get; set; }

        public static implicit operator Canli(Insan i)
        {
            return new Canli()
            {
                Adi = i.Isim,
                Cinsiyet = i.Cinsiyet == 1 ? true : false,
                Yasi = (DateTime.Now.Year - i.DogumYili).ToString()
            };
        }
    }
    class Insan
    {
        public string Isim { get; set; }
        public int DogumYili { get; set; }
        public int Cinsiyet { get; set; }

        public static explicit operator Insan(Canli c)
        {
            return new Insan
            {
                Isim = c.Adi,
                Cinsiyet = Convert.ToInt32(c.Cinsiyet),
                DogumYili = DateTime.Now.Year - int.Parse(c.Yasi)
            };
        }
    }

    class MyClass
    {
        public MyClass()
        {
            Canli c = new Insan()
            {
                DogumYili = 2000,
                Cinsiyet = 1,
                Isim = "Hilmi"

            };


            Insan i = (Insan)new Canli();
        }
    }
    #endregion



}