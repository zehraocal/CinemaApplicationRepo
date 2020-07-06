import { Component, OnInit, ViewChild } from '@angular/core';
import { VisionMovieAddVM } from 'app/entities/vision-movie-add-vm';
import { HttpService } from 'app/services/http.service';
import { NgbModal, ModalDismissReasons } from '@ng-bootstrap/ng-bootstrap';
import { CnmConfirmDialogComponent } from '../cinema-components/cnm-confirm-dialog/cnm-confirm-dialog.component';
import { CnmModalComponent } from '../cinema-components/cnm-modal/cnm-modal.component';
import { VisionMovie } from 'app/entities/vision-movie';
import { Movie } from 'app/entities/movie';
import { MovieHouse } from 'app/entities/movie-house';
import { Session } from 'app/entities/session';
import { VisionMovieGetVM } from 'app/entities/vision-movie-get-vm';
import { DropDownListVM } from 'app/entities/drop-down-list-vm';
import { VisionMovieListVM } from 'app/entities/vision-movie-list-vm';

@Component({
  selector: 'app-vision-movie',
  templateUrl: './vision-movie.component.html'
})

export class VisionMovieComponent implements OnInit {

  criteria: any = {};
  sorgulandi = false;
  record: any = {};
  cols: any[];


  visionMovies: {};
  visionMoviesList: VisionMovieListVM[];
  movies: {};
  selectedMovie: number;
  movieHouses: {};
  selectedMovieHouse: number;
  sessions: {};
  selectedSession: number;
  options: string;
  value: Date;

  @ViewChild(CnmConfirmDialogComponent, { static: false }) dialogComponentRef: CnmConfirmDialogComponent;
  @ViewChild('updateViewComponent', { static: false }) UpdateViewComponentRef: CnmModalComponent;
  @ViewChild('addViewComponent', { static: false }) AddViewComponentRef: CnmModalComponent;

  constructor(private httpService: HttpService, private modalService: NgbModal) { }

  ngOnInit(): void {
    debugger
    this.cols = [
      { field: 'movieId', header: 'Film Adı' },
      { field: 'movieHouseId', header: 'Salon Adı' },
      { field: 'sessionId', header: 'Süre' },
      { field: 'displayDate', header: 'Gösterim Tarihi' , type: 'date' },
      { field: 'price', header: 'Ücret' }
      
    ];
    this.httpService.get<DropDownListVM>("Movie", "GetDropDownList").subscribe(data => {
      this.movies = data;
    })
    this.httpService.get<DropDownListVM>("MovieHouse", "GetDropDownList").subscribe(data => {
      this.movieHouses = data;
    })
    this.httpService.get<DropDownListVM>("Session", "GetDropDownList").subscribe(data => {
      this.sessions = data;
    })
   
  }


  getVisionMovie() { 
  debugger
    //  let visionMovieParam: VisionMovieGetVM = new VisionMovieGetVM();
    //  visionMovieParam.movie= this.criteria.name;
    // this.httpService.post<VisionMovieGetVM, any>("VisionMovie", visionMovieParam, "GetVisionMovie").subscribe(data => {
    //   this.visionMovies = data;
    //  this.sorgulandi = true;
    // });
    this.httpService.get<VisionMovieListVM>("VisionMovie", "GetDropDownList").subscribe(data => {
      this.visionMovies = data;
      this.sorgulandi = true;
    });
  }

  addVisionMovie() {
    debugger
    let visionMovie: VisionMovieAddVM = new VisionMovieAddVM();
    visionMovie.movieId = this.selectedMovie;
    visionMovie.movieHouseId = this.selectedMovieHouse;
    visionMovie.sessionId = this.selectedSession;
    visionMovie.price = this.record.price;
    visionMovie.displayDate = new Date(this.value);

    this.httpService.post<VisionMovieAddVM, any>("VisionMovie", visionMovie, "AddVisionMovie").subscribe(data => {
      if (data)
        this.getVisionMovie();
      this.modalService.dismissAll();
    });
  }

  openAddDialog() {

    this.AddViewComponentRef.openDialog();
  }

  private getDismissReason(reason: any): string {
    if (reason === ModalDismissReasons.ESC) {
      return 'by pressing ESC';
    } else if (reason === ModalDismissReasons.BACKDROP_CLICK) {
      return 'by clicking on a backdrop';
    } else {
      return `with: ${reason}`;
    }
  }
  cleanSelectedVisionMovie() {
    this.criteria.name = "";
  }
}
