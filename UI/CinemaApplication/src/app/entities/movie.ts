import { VisionMovie } from './vision-movie';

export class Movie {
    id: number;
    name: string;
    genre: string;
    duration: number;
    description: string;
    releaseDate: Date;
    
    visionMovie: VisionMovie[];
}
