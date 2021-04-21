import { VisionMovie } from './vision-movie';

export class Movie {
    id: number;
    name: string;
    genre: string;
    duration: number;
    description: string;
    posterName: string;
    releaseDate: Date;
    pngBase64: string;
    
    visionMovie: VisionMovie[];
}
