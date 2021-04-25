import { Component, OnInit, ViewChild } from '@angular/core';
import { HttpService } from 'app/services/http.service';
import { NgbModal, ModalDismissReasons } from '@ng-bootstrap/ng-bootstrap';
import { MovieGetVM } from 'app/entities/movie-get-vm';
import { Movie } from 'app/entities/movie';
import { MovieAddVM } from 'app/entities/movie-add-vm';
import { CnmModalComponent } from '../cinema-components/cnm-modal/cnm-modal.component';
import { CnmConfirmDialogComponent } from '../cinema-components/cnm-confirm-dialog/cnm-confirm-dialog.component';
import { MovieUpdateVM } from 'app/entities/movie-update-vm';

@Component({
  selector: 'app-movie',
  templateUrl: './movie.component.html',

})
export class MovieComponent implements OnInit {

  updateId: number;
  deleteId: number;
  Movie: Movie[];
  record: any = {};
  criteria: any = {};
  sorgulandi = false;
  cols: any[];
  value: Date;
  updateDate:Date;
  ImageBaseData: string | ArrayBuffer = null;

  @ViewChild(CnmConfirmDialogComponent, { static: false }) dialogComponentRef: CnmConfirmDialogComponent;
  @ViewChild('updateViewComponent', { static: false }) UpdateViewComponentRef: CnmModalComponent;
  @ViewChild('addViewComponent', { static: false }) AddViewComponentRef: CnmModalComponent;


  constructor(private httpService: HttpService, private modalService: NgbModal) { }

  ngOnInit(): void {
    this.cols = [
      { field: 'name', header: 'Film Adı' },
      { field: 'genre', header: 'Tür' },
      { field: 'duration', header: 'Süre' },
      { field: 'description', header: 'Açıklama' },
      { field: 'releaseDate', header: 'Vizyon Tarihi', type: 'date' }
    ];
  }

  getMovie() {
    debugger
    let movieParam: MovieGetVM = new MovieGetVM();
    movieParam.name  = this.criteria.name;
    movieParam.genre=this.criteria.genre;

    this.httpService.post<MovieGetVM, any>("Movie", movieParam, "GetWhereMovieList").subscribe(data => {
      debugger
      this.Movie = data;
      this.sorgulandi = true;
    });
  }


  addMovie() {
    debugger
    let movie: MovieAddVM = new MovieAddVM();
    movie.name = this.record.addName;
    movie.genre = this.record.addGenre;
    movie.duration = this.record.addDuration;
    movie.description = this.record.addDescription;
    movie.posterName=this.record.addPosterName;
    movie.releaseDate = new Date(this.value);
    movie.PngBase64=this.ImageBaseData.toString();

    this.httpService.post<MovieAddVM, any>("Movie", movie, "AddMovie").subscribe(data => {
      if (data)
        this.getMovie();
      this.modalService.dismissAll();
    });
  }
  pictureSelect(files: FileList) {
    debugger
    this.ImageBaseData = null;
    let me = this;
    let file = files[0];
    let reader = new FileReader();
    reader.readAsDataURL(file);
    reader.onload = function () {
      me.ImageBaseData = reader.result;
    };

    reader.onerror = function (error) {
      alert("Dosya seçimi sırasında bir hata oluştu. Lütfen tekrar deneyiniz.");
    };
  }
  openAddDialog() {
    debugger
    this.AddViewComponentRef.openDialog();
  }

  updateMovie() {
    debugger
    let updateMovie: MovieUpdateVM = new MovieUpdateVM();
    updateMovie.id = this.updateId;
    updateMovie.name = this.record.name;
    updateMovie.genre = this.record.genre;
    updateMovie.duration = this.record.duration;
    updateMovie.posterName=this.record.posterName;
    updateMovie.description = this.record.description;
    updateMovie.releaseDate = new Date(this.updateDate);
    updateMovie.PngBase64=this.ImageBaseData.toString();

    this.httpService.put<MovieUpdateVM, any>("Movie", updateMovie, "UpdateMovie").subscribe(updatedata => {
      this.updateMovie = updatedata;
      this.getMovie();
      this.modalService.dismissAll();
    });
  }

  openUpdateDialog(selectedMovie, id: number) {
    this.updateId = id;
    this.record.name = selectedMovie.name;
    this.record.genre = selectedMovie.genre;
    this.record.duration = selectedMovie.duration;
    this.record.posterName=selectedMovie.posterName;
    this.record.description = selectedMovie.description;
    this.updateDate= selectedMovie.releaseDate;
    this.UpdateViewComponentRef.openDialog();
  }
  deleteMovie() {
    this.httpService.delete<any>("Movie", this.deleteId, "DeleteMovie").subscribe(data => {
      this.getMovie();
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

  cleanSelectedMovie() {
    this.criteria.name = "";
    this.criteria.genre = "";
  }
}
