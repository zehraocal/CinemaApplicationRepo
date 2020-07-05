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

@Component({
  selector: 'app-vision-movie',
  templateUrl: './vision-movie.component.html'
})

export class VisionMovieComponent implements OnInit {

  criteria: any = {};
  sorgulandi = false;
  record: any = {};
  cols: any[];


  VisionMovies: VisionMovie[];
  Movies: Movie[];
  SelectedMovie: Movie;
  MovieHouses: MovieHouse[];
  SelectedMovieHouse: MovieHouse;
  Sessions: Session[];
  SelectedSession: Session;
  options:string;

  @ViewChild(CnmConfirmDialogComponent, { static: false }) dialogComponentRef: CnmConfirmDialogComponent;
  @ViewChild('UpdateViewComponent', { static: false }) UpdateViewComponentRef: CnmModalComponent;
  @ViewChild('addViewComponent', { static: false }) AddViewComponentRef: CnmModalComponent;



  constructor(private httpService: HttpService, private modalService: NgbModal) { }

  ngOnInit(): void {
    this.cols = [
      { field: 'movie', header: 'Film Adı' },
      { field: 'moviehouse', header: 'Salon Adı' },
      { field: 'displaydate', header: 'Gösterim Tarihi' },
      { field: 'price', header: 'Ücret' },
      { field: 'session', header: 'Süre' } 
    ];
    
    //this.options =this.Movies.indexOf(name)

  }
  

  getVisionMovie() {
    debugger
    let visionMovieParam: VisionMovieGetVM = new VisionMovieGetVM();
    visionMovieParam.movie.name = this.criteria.name;

    this.httpService.post<VisionMovieGetVM, any>("VisionMovie", visionMovieParam, "GetVisionMovie").subscribe(data => {
      this.VisionMovies = data;
      this.sorgulandi = true;
    });
  }

  addVisionMovie() {
      let visionMovie: VisionMovieAddVM = new VisionMovieAddVM();
      visionMovie.movieId=this.SelectedMovie.id;
      visionMovie.movieHouseId=this.SelectedMovieHouse.id;
      visionMovie.sessionId=this.SelectedSession.id;
      visionMovie.price=this.record.price;
      visionMovie.displayDate=new Date(this.record.Date);

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
      if(reason === ModalDismissReasons.ESC) {
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
