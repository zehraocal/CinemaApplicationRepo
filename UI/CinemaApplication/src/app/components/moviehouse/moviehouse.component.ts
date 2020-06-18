import { Component, OnInit } from '@angular/core';
import { MovieHouse } from 'app/entities/movie-house';
import { HttpService } from 'app/services/http.service';

@Component({
  selector: 'app-moviehouse',
  templateUrl: './moviehouse.component.html',
  styleUrls: ['./moviehouse.component.css']
})
export class MoviehouseComponent implements OnInit {

  constructor(private httpService: HttpService) { }


  MovieHouses: MovieHouse[];

  ngOnInit(): void {
   debugger
    this.httpService.get<MovieHouse[]>("MovieHouse").subscribe(data=> {
      this.MovieHouses=data;
    })


  }

}
