import { Component, OnInit, Input } from '@angular/core';
import { Movie } from 'app/entities/movie';
import { HttpService } from 'app/services/http.service';
import { MovieGetVM } from 'app/entities/movie-get-vm';

@Component({
  selector: 'app-movie-carousel',
  templateUrl: './movie-carousel.component.html',
  
})
export class MovieCarouselComponent implements OnInit {

  movies: any[];
  moviesName: string;
  movieGenre: string;
  responsiveOptions;
  constructor(private httpService: HttpService) { }

  ngOnInit(): void {
    this.responsiveOptions = [
      {
          breakpoint: '1024px',
          numVisible: 3,
          numScroll: 3
      },
      {
          breakpoint: '768px',
          numVisible: 2,
          numScroll: 2
      },
      {
          breakpoint: '560px',
          numVisible: 1,
          numScroll: 1
      }];

      this.movies = [
        { genre: 'dram', header: 'Gora', duration: '30', jpgName: 'Gora' },
        { genre: 'korku', header: 'Eltilerin Savaşı', duration: '10', jpgName: 'EltilerinSavasi' }
      ];
  }

  
}
