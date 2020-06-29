import { Component, OnInit } from '@angular/core';
import { MovieHouse } from 'app/entities/movie-house';
import { HttpService } from 'app/services/http.service';
import { MovieHouseAddVM } from 'app/entities/movie-house-add-vm';
import { stringify } from 'querystring';
import { MovieHouseUpdateVM } from 'app/entities/movie-house-update-vm';

import { FormGroup, FormControl } from '@angular/forms';
import { NgbModal, ModalDismissReasons } from '@ng-bootstrap/ng-bootstrap';
import { MovieHouseGetVM } from 'app/entities/movie-house-get-vm';


@Component({
  selector: 'app-moviehouse',
  templateUrl: './moviehouse.component.html'
})
export class MoviehouseComponent implements OnInit {
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

  updateMovieHouse(id: number) {
    let updateMovieHouse: MovieHouseUpdateVM = new MovieHouseUpdateVM();
    updateMovieHouse.id = id
    updateMovieHouse.name = this.record.name;
    updateMovieHouse.capacity = this.record.capacity;

    this.httpService.put<MovieHouseUpdateVM, any>("MovieHouse", updateMovieHouse, "UpdateMovieHouse").subscribe(updatedata => {
      this.updateMovieHouse = updatedata;
      this.getMovieHouse();
      this.modalService.dismissAll();
    })

  }
  deleteMovieHouse(id: number) {
    this.httpService.delete<any>("MovieHouse", id, "DeleteMovieHouse").subscribe(data => {
      this.getMovieHouse();
      this.modalService.dismissAll();
    })
  }

  cleanSelectedMovieHouse() {
    this.criteria.name = "";
  }

  openUpdateDialog(content, selectedMovieHouse) {
    this.record.name = selectedMovieHouse.name;
    this.record.capacity = selectedMovieHouse.capacity;
    this.modalService.open(content).result.then((result) => {
      this.closeResult = `Closed with: ${result}`;
    }, (reason) => {
      this.closeResult = `Dismissed ${this.getDismissReason(reason)}`;
    });
  }

  openAddDialog(content) {
    this.modalService.open(content).result.then((result) => {
      this.closeResult = `Closed with: ${result}`;
    }, (reason) => {
      this.closeResult = `Dismissed ${this.getDismissReason(reason)}`;
    });
  }

  openDeleteDialog(content, modalDimension) {
    if (modalDimension === 'sm') {
      this.modalService.open(content, { size: 'sm' }).result.then((result) => {
        this.closeResult = `Closed with: ${result}`;
      }, (reason) => {
        this.closeResult = `Dismissed ${this.getDismissReason(reason)}`;
      });
    }
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



}
