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
import { MovieTicketGetByVM } from 'app/entities/movie-ticket-get-by-vm';

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
    let movieId = this.route.snapshot.params['movieId'];
    this.selectMovieId = movieId;
    await this.httpService.get<VisionMovieGetVM>("VisionMovie", "GetSingleVisionMovieList", movieId).toPromise().then(data => {

      this.ticketMovie = data;
      this.getDate = true;
    })

    this.httpService.get<MovieTicketGetDisplayTime>("VisionMovie", "GetDisplayDateList", this.route.snapshot.params['movieId']).subscribe(async data => {
      this.displayDates = data;
    });

  }


  onChange(event) {
    let movieTicketSession: MovieTicketGetSession = new MovieTicketGetSession();
    movieTicketSession.movieId = this.route.snapshot.params['movieId'];
    movieTicketSession.visionMovieId = event.value;

    this.httpService.post<MovieTicketGetSession, DropDownListVM>("MovieHouse", movieTicketSession, "GetMovieHouseDropDownList").subscribe(data => {
      this.movieHouses = data;
    });
  }

  onChange1(event) {
    let movieTicketSession: MovieTicketGetSession = new MovieTicketGetSession();
    movieTicketSession.movieId = this.route.snapshot.params['movieId'];
    movieTicketSession.visionMovieId = event.value;
    movieTicketSession.queryMovieHouse = this.queryMovieHouse;
    this.httpService.post<MovieTicketGetSession, DropDownListVM>("Session", movieTicketSession, "GetVisionMovieDropDownList").subscribe(data => {
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
    let movieTicketVM: MovieTicketGetVM = new MovieTicketGetVM();
    movieTicketVM.MovieHouseId = this.selectMovieHouseId;
    movieTicketVM.MovieId = this.selectMovieId;
    movieTicketVM.SessionId = this.selectSessionId;
    var resultA = this.getStatusControl(movieTicketVM);
  }

  //return status of each seat
  getStatusControl(movieTicketVM: any = []) {
    this.httpService.post<MovieTicketGetVM, any>("MovieTicket", movieTicketVM, "GetWhereMovieTicket").toPromise().then(data => {
      debugger
      if (data != null) {
        for (let i = 0; i < data.length; i++) {
          this.reserved.push(data[i]);
        }
        this.getSeat(this.MovieHousesCapacity);
      }      
    });
  }

  getStatus(row) {
    for (let i = 0; i < this.reserved.length; i++) {
      if (this.reserved[i] == row) {
        return 'reserved';
      }
    }
  }

  clearSelected() {
    this.selected = [];
  }

  //click handler
  seatClicked(seatPos: string) {
    debugger
    let movieTicketByVM: MovieTicketGetByVM = new MovieTicketGetByVM();
    movieTicketByVM.MovieHouseId = this.selectMovieHouseId;
    movieTicketByVM.MovieId = this.selectMovieId;
    movieTicketByVM.SessionId = this.selectSessionId;
    movieTicketByVM.SeatName = seatPos;

    this.httpService.post<MovieTicketGetByVM, any>("MovieTicket", movieTicketByVM, "GetWhereByMovieTicket").toPromise().then(data => {
      if (data > 0) {
         alert("Bu koltuk daha önce alındı");        
         }
      else {
        this.httpService.post<MovieTicketAddVM, any>("MovieTicket", movieTicketByVM, "AddMovieTicket").subscribe(async data1 => {
          if (data1) { 
            alert("İşlem başarıyla gerçekleşti");
            window.location.reload(); 
          }
          else { alert("İşlem başarısız."); }
        });
      }
    });

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
        let seatItem;
        if(this.reserved.includes(element + i))
          seatItem = { seat: element + i, status: 'reserved'};
        else
          seatItem = { seat: element + i, status: 'selected'};
        this.seatList.push(seatItem);
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
