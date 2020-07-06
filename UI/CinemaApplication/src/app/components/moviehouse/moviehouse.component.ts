import { Component, OnInit, ViewChild } from '@angular/core';
import { MovieHouse } from 'app/entities/movie-house';
import { HttpService } from 'app/services/http.service';
import { MovieHouseAddVM } from 'app/entities/movie-house-add-vm';
import { stringify } from 'querystring';
import { MovieHouseUpdateVM } from 'app/entities/movie-house-update-vm';

import { FormGroup, FormControl } from '@angular/forms';
import { NgbModal, ModalDismissReasons } from '@ng-bootstrap/ng-bootstrap';
import { MovieHouseGetVM } from 'app/entities/movie-house-get-vm';
import { CnmConfirmDialogComponent } from '../cinema-components/cnm-confirm-dialog/cnm-confirm-dialog.component';
import { CnmModalComponent } from '../cinema-components/cnm-modal/cnm-modal.component';


@Component({
  selector: 'app-moviehouse',
  templateUrl: './moviehouse.component.html'
})
export class MoviehouseComponent implements OnInit {

  @ViewChild(CnmConfirmDialogComponent, { static: false }) dialogComponentRef: CnmConfirmDialogComponent;
  @ViewChild('updateViewComponent', { static: false }) UpdateViewComponentRef: CnmModalComponent;
  @ViewChild('addViewComponent', { static: false }) AddViewComponentRef: CnmModalComponent;

  deleteId: number;
  updateId: number;
  closeResult: string;
  MovieHouses: MovieHouse[];
  record: any = {};
  criteria: any = {};
  sorgulandi = false;
  cols: any[];

  constructor(private httpService: HttpService, private modalService: NgbModal) { }

  ngOnInit(): void {
    this.cols = [
      { field: 'name', header: 'Salon Adı' },
      { field: 'capacity', header: 'Kapasitesi' }

    ];
  }

  getMovieHouse() {
    debugger
    let movieHouseParam: MovieHouseGetVM = new MovieHouseGetVM();
    movieHouseParam.name = this.criteria.name;

    this.httpService.post<MovieHouseGetVM, any>("MovieHouse", movieHouseParam, "GetWhereMovieHouse").subscribe(data => {
      this.MovieHouses = data;
      this.sorgulandi = true;
    });
  }

  addMovieHouse() {
    let movieHouse: MovieHouseAddVM = new MovieHouseAddVM();
    movieHouse.name = this.record.addName;
    movieHouse.capacity = this.record.addCapacity;

    this.httpService.post<MovieHouseAddVM, any>("moviehouse", movieHouse, "AddMovieHouse").subscribe(data => {
      if (data)
        this.getMovieHouse();
      this.modalService.dismissAll();
    });
  }
  
  openAddDialog() {
    this.AddViewComponentRef.openDialog();
   }

  updateMovieHouse() {
    debugger
    let updateMovieHouse: MovieHouseUpdateVM = new MovieHouseUpdateVM();
    updateMovieHouse.id = this.updateId;
    updateMovieHouse.name = this.record.name;
    updateMovieHouse.capacity = this.record.capacity;

    this.httpService.put<MovieHouseUpdateVM, any>("MovieHouse", updateMovieHouse, "UpdateMovieHouse").subscribe(updatedata => {
      this.updateMovieHouse = updatedata;
      this.getMovieHouse();
      this.modalService.dismissAll();
    })
  }

  openUpdateDialog(selectedMovieHouse, id: number) {      
    this.updateId = id;
    this.record.name = selectedMovieHouse.name;
    this.record.capacity = selectedMovieHouse.capacity;
    this.UpdateViewComponentRef.openDialog();
  }

  openDeleteDialog(id: number) {
    this.deleteId = id;
    this.dialogComponentRef.openDeleteDialog('sm');
  }

  deleteMovieHouse() {
    this.httpService.delete<any>("MovieHouse", this.deleteId, "DeleteMovieHouse").subscribe(data => {
      this.getMovieHouse();
      this.modalService.dismissAll();
    })
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
  cleanSelectedMovieHouse() {
    this.criteria.name = "";
  }



}
