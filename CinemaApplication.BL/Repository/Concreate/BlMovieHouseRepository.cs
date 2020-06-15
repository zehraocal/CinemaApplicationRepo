using CinemaApplication.BL.Repository.Interface;
using CinemaApplication.Entity.Entities;
using CinemaApplication.Entity.ViewModels;

namespace CinemaApplication.BL.Repository.Concreate
{
    public class BlMovieHouseRepository: BlRepository<MovieHouse>, IBlMovieHouseRepository
    {
        //public override bool Add(MovieHouse model)
        //{
        //    // kontrol veya eklemeden once yapılacak moive house'a ait islemler burada yapılmalıdır.
        //    //TODO: MovieHouseAddViewModel olustur ve burada MovieHouse turune maple
        //    MovieHouse movieHouse = new MovieHouse()
        //    {
        //        Name = model.Name,
        //        Capacity = model.Capacity
        //    };

        //    return base.Add(movieHouse);
        //}

        //public override bool Add<A>(A model)
        //{

        //    return base.Add(model);
        //}
    }
   
}
