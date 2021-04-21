import { Component, OnInit } from '@angular/core';
import { HttpService } from 'app/services/http.service';
import { ActivatedRoute } from '@angular/router';
import { VisionMovieGetVM } from 'app/entities/vision-movie-get-vm';
import { DropDownListVM } from 'app/entities/drop-down-list-vm';
import { MovieTicketGetSession } from 'app/entities/movie-ticket-get-session';
import { MovieTicketGetDisplayTime } from 'app/entities/movie-ticket-get-display-time';
import { MovieHouseGetVM } from 'app/entities/movie-house-get-vm';
import { MovieHouse } from 'app/entities/movie-house';
import { MovieTicketGetVM } from 'app/entities/movie-ticket-get-vm';
import { MovieTicketAddVM } from 'app/entities/movie-ticket-add-vm';

@Component({
  selector: 'app-movie-ticket',
  templateUrl: './movie-ticket.component.html'
})
export class MovieTicketComponent implements OnInit {

  movies: any = [];
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
  seatList = [];
  selectMovieId: number;
  selectMovieHouseId: number;
  selectSessionId: number;
  selected: string[] = [];
  reserved: string[] = [];
  messageService: any;

  constructor(private httpService: HttpService, private route: ActivatedRoute) {
  
  }

  async ngOnInit(): Promise<void> {
    debugger
    let movieId = this.route.snapshot.params['movieId'];
    this.selectMovieId = movieId;
    await this.httpService.get<VisionMovieGetVM>("VisionMovie", "GetSingleVisionMovieList", movieId).toPromise().then(data => {
      debugger
      this.ticketMovie = data;
      this.getDate = true;
    })
    debugger
    this.httpService.get<MovieTicketGetDisplayTime>("VisionMovie", "GetDisplayDateList", this.route.snapshot.params['movieId']).subscribe(async data => {
      debugger
      this.displayDates = data;
    });

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
    this.selectMovieHouseId = value;
    let movieHouseParam: MovieHouseGetVM = new MovieHouseGetVM();
    this.httpService.get("MovieHouse", "GetSingleMovieHouse", value).toPromise().then(data1 => {
      this.MovieHousesCapacity = data1["capacity"];

    });

    let movieTicketSession: MovieTicketGetSession = new MovieTicketGetSession();
    movieTicketSession.movieId = this.route.snapshot.params['movieId'];
    movieTicketSession.visionMovieId = value;
    movieTicketSession.queryMovieHouse = this.queryMovieHouse;
    this.httpService.post<MovieTicketGetSession, DropDownListVM>("Session", movieTicketSession, "GetVisionMovieDropDownList").toPromise().then(data => {
      this.sessions = data;
    });
    
  }

  selectSessions(value) {
    this.selectSessionId = value;
    this.getSeat(this.MovieHousesCapacity);
  }



  //return status of each seat
  getStatusControl(movieTicketVM: any = []) {
    debugger
    this.httpService.post<MovieTicketGetVM, any>("MovieTicket", movieTicketVM, "GetWhereMovieTicket").toPromise().then(data => {
     if (data !=null) {
     this.reserved.push(
      data );
         // return 'reserved';  
       }
    });
  }

  clearSelected() {
    this.selected = [];
  }

  //click handler
  seatClicked(seatPos: string) {
    debugger
    let movieTicketVM: MovieTicketGetVM = new MovieTicketGetVM();
    movieTicketVM.MovieHouseId = this.selectMovieHouseId;
    movieTicketVM.MovieId = this.selectMovieId;
    movieTicketVM.SessionId = this.selectSessionId;
    movieTicketVM.SeatName = seatPos;
    debugger
    var resultA=this.getStatusControl(movieTicketVM)
   // if (resultA <1) {
    //  this.httpService.post<MovieTicketAddVM, any>("MovieTicket", movieTicketVM, "AddMovieTicket").subscribe(async data1 => {
     //   if (data1) {
      //    this.messageService.add({ severity: 'success', detail: 'Başarıyla eklendi.' });
      //  }
      //  else
       //   this.messageService.add({ severity: 'error', detail: 'Ekleme başarısız.' });
     // });
    //}
  }

  getSeat(seatCount: number) {
    debugger
    let alphabets = [];
    var sayi = seatCount / 10;
    for (let i = 65; i <= 65 + sayi; i++) {
      alphabets.push(String.fromCharCode(i));
    }
    alphabets.forEach(element => {
      for (let i = 1; i < 11; i++) {
        this.seatList.push(element + i);
      }
    });
    if (this.seatList.length > seatCount) {
      this.seatList.splice(seatCount, (this.seatList.length - seatCount));
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
