import { Component, OnInit, Input } from '@angular/core';
import { HttpService } from 'app/services/http.service';
import { ActivatedRoute, Params } from '@angular/router';


@Component({
  selector: 'app-movie-detail',
  templateUrl: './movie-detail.component.html'
})
export class MovieDetailComponent implements OnInit {

  movies: any = [];
  controlMovies: any = [];
  movieId: number;
  record: any = {};
  rating: number;
  showDetail = false;

  constructor(private httpService: HttpService, private route: ActivatedRoute) { }
  ngOnInit(): void {
    debugger
    let movieId = this.route.snapshot.params['movieId'];
    this.httpService.get("Movie", "GetSingleMovieList", movieId).subscribe(data => {
      debugger
      this.movies = data;
    })

      debugger
      this.httpService.get<boolean>("VisionMovie","ControlVisionMovieList", this.route.snapshot.params['movieId'], ).subscribe(data => {
        debugger
        if(data)
        this.showDetail = true;
    })

  }
}
