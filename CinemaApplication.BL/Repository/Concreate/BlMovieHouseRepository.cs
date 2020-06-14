using CinemaApplication.BL.Repository.Interface;
using CinemaApplication.Entity.Entities;

namespace CinemaApplication.BL.Repository.Concreate
{
    public class BlMovieHouseRepository: BlRepository<MovieHouse>, IBlMovieHouseRepository
    {
        public override bool Add(MovieHouse model)
        {
            // kontrol veya eklemeden once yapılacak moive house'a ait islemler burada yapılmalıdır.
            //TODO: MovieHouseAddViewModel olustur ve burada MovieHouse turune maple
            return base.Add(model);
        }

    }
   
}
