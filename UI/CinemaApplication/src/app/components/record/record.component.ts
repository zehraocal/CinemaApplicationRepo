import { Component, OnInit } from '@angular/core';
import { AddUserVM } from 'app/entities/add-user-vm';
import { HttpService } from 'app/services/http.service';

@Component({
  selector: 'app-record',
  templateUrl: './record.component.html',
  styleUrls: ['./record.component.css']
})
export class RecordComponent implements OnInit {

  record: any = {};

  constructor(private httpService: HttpService) { }

  ngOnInit(): void {
  }


  addUser() {
    debugger
    let user: AddUserVM = new AddUserVM();
    user.Username = this.record.username;
    user.Name=this.record.name;
    user.Surname = this.record.surname;
    user.Password = this.record.password;
    user.Email = this.record.email;

    this.httpService.post<AddUserVM, any>("Login", user, "AddUser").subscribe(data => {
      this.goToLoginPage();

    });
  }
  goToLoginPage() {
    window.location.href = "login"
   }
}
