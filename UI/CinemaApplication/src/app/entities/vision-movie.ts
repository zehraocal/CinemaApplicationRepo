import { MovieHouse } from './movie-house';
import { Session } from './session';
import { Movie } from './movie';


export class VisionMovie {
    id: number;
    movieId: number;
    sessionId : number;
    movieHouseId: number;
    displayDate: Date;
    price: number;

    movieHouse: MovieHouse;
    session : Session;
    movie: Movie;

}
