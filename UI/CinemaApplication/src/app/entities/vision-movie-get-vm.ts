import { Movie } from './movie';
import { MovieHouse } from './movie-house';
import { Session } from './session';

export class VisionMovieGetVM {
    displayDate: Date;
    movieHouse: MovieHouse;
    session : Session;
    movie: Movie;
}
