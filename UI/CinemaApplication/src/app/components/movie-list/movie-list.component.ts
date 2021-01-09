import { Component, OnInit } from '@angular/core';
import { HttpService } from 'app/services/http.service';
import { GetMovieListVM } from 'app/entities/get-movie-list-vm';
import { DropDownListVM } from 'app/entities/drop-down-list-vm';
import { VisionMovieGetVM } from 'app/entities/vision-movie-get-vm';

@Component({
  selector: 'app-movie-list',
  templateUrl: './movie-list.component.html'
})
export class MovieListComponent implements OnInit {

  movies: {};
  movieDropDown: {};
  sessionDropDown: {};
  criteria: any = {};
  gueryVisionMovie = false;
  gueryMovie = false;
  getVisionMovieList = false;
  getMovieList = false;

  constructor(private httpService: HttpService) { }

  ngOnInit(): void {
    let movieParam: GetMovieListVM = new GetMovieListVM();
    this.httpService.post<GetMovieListVM, any>("Movie", movieParam, "GetVisionMovieList").subscribe(data => {
      debugger
      this.movies = data;
      this.gueryMovie = true;
      this.getVisionMovieList = true;
      this.getMovieList = false;
    })

  }

  visionMovieGetList() {
    let movieParam: GetMovieListVM = new GetMovieListVM();
    movieParam.name = this.criteria.name;
    movieParam.genre = this.criteria.genre;
    this.httpService.post<GetMovieListVM, any>("Movie", movieParam, "GetVisionMovieList").subscribe(data => {
      this.movies = data;
      this.gueryVisionMovie = true;
      this.gueryMovie = false;
      this.getVisionMovieList = true;
      this.getMovieList = false;
    })
  }
  MovieGetList() {
    let movieParam: GetMovieListVM = new GetMovieListVM();
    movieParam.name = this.criteria.name;
    movieParam.genre = this.criteria.genre;
    this.httpService.post<GetMovieListVM, any>("Movie", movieParam, "GetMovieList").subscribe(data => {
      debugger
      this.movies = data;
      this.gueryMovie = true;
      this.gueryVisionMovie = false;
      this.getVisionMovieList = false;
      this.getMovieList = true;
    })
  }
}

