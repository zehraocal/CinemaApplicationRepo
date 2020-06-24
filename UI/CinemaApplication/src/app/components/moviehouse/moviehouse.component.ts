import { Component, OnInit } from '@angular/core';
import { MovieHouse } from 'app/entities/movie-house';
import { HttpService } from 'app/services/http.service';
import { MovieHouseAddVM } from 'app/entities/movie-house-add-vm';
import { stringify } from 'querystring';
import { MovieHouseUpdateVM } from 'app/entities/movie-house-update-vm';

import { FormGroup, FormControl } from '@angular/forms';
import { NgbModal, ModalDismissReasons } from '@ng-bootstrap/ng-bootstrap';


@Component({
  selector: 'app-moviehouse',
  templateUrl: './moviehouse.component.html'
})
export class MoviehouseComponent implements OnInit {
  closeResult: string;
  MovieHouses: MovieHouse[];
  record: any= {};

  constructor(private httpService: HttpService, private modalService: NgbModal) { }

  ngOnInit(): void {
  
  }

  getMovieHouse() {
    this.httpService.get<MovieHouse[]>("moviehouse").subscribe(data => {
      this.MovieHouses = data;
    })
  }

  addMovieHouse(name: HTMLInputElement, capacity: HTMLInputElement) {

    let movieHouse: MovieHouseAddVM = new MovieHouseAddVM();
    movieHouse.name = name.value;
    movieHouse.capacity = parseInt(capacity.value);


    this.httpService.post<MovieHouseAddVM, any>("moviehouse", movieHouse).subscribe(data => {
      if (data)
        alert("Sinema salonu başarıyla kayıt olmuştur....")

    })
  }

  updateMovieHouse(id) {
    debugger
    let updateMovieHouse: MovieHouseUpdateVM = new MovieHouseUpdateVM();
    
    updateMovieHouse.name = this.record.name;
    updateMovieHouse.capacity = this.record.capacity;

    this.httpService.put<MovieHouseUpdateVM, any>("moviehouse", updateMovieHouse).subscribe(Updatedata => {
      this.updateMovieHouse = Updatedata;
    })

  }
  deleteMovieHouse(id: number) {

    this.httpService.delete<any>("moviehouse", id).subscribe(data => {
      if (data)
        alert("Sinema salonu başarıyla silinmiştir....")

    })


  }


  
  open(content) {
      this.modalService.open(content).result.then((result) => {
        this.closeResult = `Closed with: ${result}`;
      }, (reason) => {
        this.closeResult = `Dismissed ${this.getDismissReason(reason)}`;
      });

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
