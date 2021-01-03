import { Component, OnInit } from '@angular/core';
import { HttpService } from 'app/services/http.service';
import { ActivatedRoute } from '@angular/router';
import { VisionMovieGetVM } from 'app/entities/vision-movie-get-vm';
import { DropDownListVM } from 'app/entities/drop-down-list-vm';
import { MovieTicketGetSession } from 'app/entities/movie-ticket-get-session';
import { MovieTicketGetDisplayTime } from 'app/entities/movie-ticket-get-display-time';
import { MovieHouseGetVM } from 'app/entities/movie-house-get-vm';
import { MovieHouse } from 'app/entities/movie-house';

@Component({
  selector: 'app-movie-ticket',
  templateUrl: './movie-ticket.component.html'
})
export class MovieTicketComponent implements OnInit {

  movieId: number;
  ticketMovie: any = [];
  sessions: {};
  guerySession: number;
  selectedDates: Date;
  getDate = false;
  displayDates: {};
  movieHouses: {};
  MovieHousesCapacity: number;
  queryMovieHouse: number;
  showSeat: boolean = false;
  rows: string[] = ['A', 'B', 'C', 'D', 'E'];
  cols= [];
  selected: string[] = [];
  reserved: string[] = ['A2', 'A3', 'F5', 'F1', 'F2', 'F6', 'F7', 'F8', 'H1', 'H2', 'H3', 'H4'];//Veritanına bunu ekle

  constructor(private httpService: HttpService, private route: ActivatedRoute) {
    this.httpService.get<MovieTicketGetDisplayTime>("VisionMovie", "GetDisplayDateList", this.route.snapshot.params['movieId']).subscribe(data => {
      debugger
      this.displayDates = data;
    });
  }

  ngOnInit(): void {
    let movieId = this.route.snapshot.params['movieId'];
    this.httpService.get<VisionMovieGetVM>("VisionMovie", "GetSingleVisionMovieList", movieId).subscribe(data => {
      debugger
      this.ticketMovie = data;
      this.getDate = true;
    })
  }


  onChange(event) {
    debugger
    let movieTicketSession: MovieTicketGetSession = new MovieTicketGetSession();
    movieTicketSession.movieId = this.route.snapshot.params['movieId'];
    movieTicketSession.visionMovieId = event.value;

    this.httpService.post<MovieTicketGetSession, DropDownListVM>("MovieHouse", movieTicketSession, "GetMovieHouseDropDownList").subscribe(data => {
      debugger
      this.movieHouses = data;
    });
  }

  onChange1(event) {
    debugger
    let movieTicketSession: MovieTicketGetSession = new MovieTicketGetSession();
    movieTicketSession.movieId = this.route.snapshot.params['movieId'];
    movieTicketSession.visionMovieId = event.value;
    movieTicketSession.queryMovieHouse = this.queryMovieHouse;
    this.httpService.post<MovieTicketGetSession, DropDownListVM>("Session", movieTicketSession, "GetVisionMovieDropDownList").subscribe(data => {
      debugger
      this.sessions = data;
    });
  }

  selectDateTime(value) {
    let movieTicketSession: MovieTicketGetSession = new MovieTicketGetSession();
    movieTicketSession.movieId = this.route.snapshot.params['movieId'];
    movieTicketSession.visionMovieId = value;
    this.httpService.post<MovieTicketGetSession, DropDownListVM>("MovieHouse", movieTicketSession, "GetMovieHouseDropDownList").subscribe(data => {
      this.movieHouses = data;
    });
  }

  selectMovieHouse(value) {
    debugger

    let movieHouseParam: MovieHouseGetVM = new MovieHouseGetVM();
    this.httpService.get("MovieHouse", "GetSingleMovieHouse", value).subscribe(data1 => {
      this.MovieHousesCapacity = data1["capacity"];
      this.getSeat(this.MovieHousesCapacity);
    });

    let movieTicketSession: MovieTicketGetSession = new MovieTicketGetSession();
    movieTicketSession.movieId = this.route.snapshot.params['movieId'];
    movieTicketSession.visionMovieId = value;
    movieTicketSession.queryMovieHouse = this.queryMovieHouse;
    this.httpService.post<MovieTicketGetSession, DropDownListVM>("Session", movieTicketSession, "GetVisionMovieDropDownList").subscribe(data => {
      this.sessions = data;
    });
  }

  //return status of each seat
  getStatus(seatPos: string) {
    if (this.reserved.indexOf(seatPos) !== -1) {
      return 'reserved';
    } else if (this.selected.indexOf(seatPos) !== -1) {
      return 'selected';
    }
  }

  clearSelected() {
    this.selected = [];
  }

  //click handler
  seatClicked(seatPos: string) {
    var index = this.selected.indexOf(seatPos);

    if (index !== -1) {
      // seat already selected, remove
      this.selected.splice(index, 1)
    } else {
      //push to selected array only if it is not reserved
      if (this.reserved.indexOf(seatPos) === -1)
        this.selected.push(seatPos);
    }
  }

getSeat(seatCount:number){
  //TODO burada iki boyutlu array oluşturulacak ve html kısmı düzenlenecek
debugger
let alphabets = [];
var sayi=seatCount/10;
for (let i = 65; i <= 65+sayi;i++) {
    alphabets.push(String.fromCharCode(i));
}
console.log(alphabets);
for (var i = 1; i < seatCount+1; i++) {
  this.cols.push(i);
}


}



  //showSelected = function() {
  //if(this.selected.length > 0) {
  //  alert("Selected Seats: " + this.selected + "\nTotal: "+(this.ticketPrice * this.selected.length + this.convFee));
  // } else {
  //   alert("No seats selected!");
  //}
  //}

}
