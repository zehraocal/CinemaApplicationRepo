import { Component, OnInit } from '@angular/core';
import { HttpService } from 'app/services/http.service';
import { GetMovieListVM } from 'app/entities/get-movie-list-vm';

@Component({
  selector: 'app-movie-list',
  templateUrl: './movie-list.component.html'
})
export class MovieListComponent implements OnInit {

  movies : {};
  movieDetail: any = [];
  constructor(private httpService: HttpService) { }

  ngOnInit(): void {
    this.httpService.get<GetMovieListVM>("Movie", "GetMovieList").subscribe(data => {
      debugger
      this.movies = data;
    })
  }
  moviesDetail(movieId){
    this.httpService.get<GetMovieListVM>("Movie", "GetSingleMovieList", movieId).subscribe(data => {
    this.movieDetail = data;
    });
  }
}
