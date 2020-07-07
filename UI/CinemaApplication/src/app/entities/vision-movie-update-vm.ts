import { MovieHouse } from './movie-house';
import { Session } from './session';
import { Movie } from './movie';

export class VisionMovieUpdateVM {
    id: number;
    movieId: number;
    sessionId : number;
    movieHouseId: number;
    displayDate: Date;
    price: number;
}

