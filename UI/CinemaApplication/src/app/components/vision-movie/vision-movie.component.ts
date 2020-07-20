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
import { VisionMovieUpdateVM } from 'app/entities/vision-movie-update-vm';
import { MessageService } from 'primeng/api';
@Component({
  selector: 'app-vision-movie',
  templateUrl: './vision-movie.component.html',
  providers: [MessageService]
})

export class VisionMovieComponent implements OnInit {

  criteria: any = {};
  sorgulandi = false;
  record: any = {};
  cols: any[];
  updateId: number;
  deleteId: number;



  visionMovies: {};
  visionMoviesList: VisionMovieListVM[];
  movies: {};
  selectedMovie: number;
  queryMovie: number;
  movieHouses: {};
  selectedMovieHouse: number;
  queryMovieHouse: number;
  sessions: {};
  selectedSession: number;
  guerySession: number;
  options: string;
  value: Date;
  updateDate: Date;
  gueryValue: Date;
  selectedUpdateMovie: any = {};
  selectedUpdateMovieHouse: any = {};
  selectedUpdateSession: any = {};

  @ViewChild(CnmConfirmDialogComponent, { static: false }) dialogComponentRef: CnmConfirmDialogComponent;
  @ViewChild('updateViewComponent', { static: false }) UpdateViewComponentRef: CnmModalComponent;
  @ViewChild('addViewComponent', { static: false }) AddViewComponentRef: CnmModalComponent;

  constructor(private httpService: HttpService, private modalService: NgbModal, private messageService: MessageService) { }

  ngOnInit(): void {

    this.cols = [
      { field: 'movieName', header: 'Film Adı' },
      { field: 'movieHouseName', header: 'Salon Adı' },
      { field: 'sessionStartTime', header: 'Süre' },
      { field: 'displayDate', header: 'Gösterim Tarihi', type: 'date' },
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
    let visionMovieParam: VisionMovieGetVM = new VisionMovieGetVM();
    visionMovieParam.movieId = this.queryMovie;
    visionMovieParam.movieHouseId = this.queryMovieHouse;
    visionMovieParam.sessionId = this.guerySession;
    visionMovieParam.displayDate = this.gueryValue;
    this.httpService.post<VisionMovieGetVM, any>("VisionMovie", visionMovieParam, "GetVisionMovieList").subscribe(data => {
      this.visionMoviesList = data;
      this.sorgulandi = true;
    });
  }

  addVisionMovie() {
    let visionMovie: VisionMovieAddVM = new VisionMovieAddVM();
    visionMovie.movieId = this.selectedMovie;
    visionMovie.movieHouseId = this.selectedMovieHouse;
    visionMovie.sessionId = this.selectedSession;
    visionMovie.price = this.record.price;
    visionMovie.displayDate = new Date(this.value);

    this.httpService.post<VisionMovieAddVM, any>("VisionMovie", visionMovie, "AddVisionMovie").subscribe(data => {
      if (data) {
        this.messageService.add({ severity: 'success', detail: 'Başarıyla eklendi.' });
        this.getVisionMovie();
        this.modalService.dismissAll();
      }
      else 
        this.messageService.add({ severity: 'error', detail: 'Ekleme başarısız.' });
    });
  }

  openAddDialog() {

    this.AddViewComponentRef.openDialog();
  }


  updateVisionMovie() {
    let updateVisionMovie: VisionMovieUpdateVM = new VisionMovieUpdateVM();
    updateVisionMovie.id = this.updateId;
    updateVisionMovie.movieId = this.selectedUpdateMovie;
    updateVisionMovie.movieHouseId = this.selectedUpdateMovieHouse;
    updateVisionMovie.sessionId = this.selectedUpdateSession;
    updateVisionMovie.price = this.record.updatePrice;
    updateVisionMovie.displayDate = new Date(this.updateDate);

    this.httpService.put<VisionMovieUpdateVM, any>("VisionMovie", updateVisionMovie, "UpdateVisionMovie").subscribe(updatedata => {
      this.updateVisionMovie = updatedata;
      this.getVisionMovie();
      this.modalService.dismissAll();
    });
  }

  openUpdateDialog(selectedVisionMovie, id: number) {
    this.updateId = id;
    this.selectedUpdateMovie = selectedVisionMovie.movieId;
    this.selectedUpdateMovieHouse = selectedVisionMovie.movieHouseId;
    this.selectedUpdateSession = selectedVisionMovie.sessionId;
    this.record.updatePrice = selectedVisionMovie.price;
    this.record.value = selectedVisionMovie.displayDate;
    this.UpdateViewComponentRef.openDialog();
  }

  deleteVisionMovie() {
    this.httpService.delete<any>("VisionMovie", this.deleteId, "DeleteVisionMovie").subscribe(data => {
      this.getVisionMovie();
      this.modalService.dismissAll();
    })
  }

  openDeleteDialog(id: number) {
    this.deleteId = id;
    this.dialogComponentRef.openDeleteDialog('sm');
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
    this.queryMovie = null;
    this.queryMovieHouse = null;
    this.guerySession = null;
    this.gueryValue = null;
  }
}
