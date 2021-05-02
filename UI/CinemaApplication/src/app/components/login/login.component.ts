import { Component, OnInit } from '@angular/core';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { LoginVM } from 'app/entities/login-vm';
import { Token } from 'app/entities/token';
import { User } from 'app/entities/user';
import { HttpService } from 'app/services/http.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  user: any = {};
  constructor(private httpService: HttpService, private modalService: NgbModal) { }

  //ngOnInit(): void {
  //}
  ngOnInit() {
    var body = document.getElementsByTagName('body')[0];
    body.classList.add('login-page');

    var navbar = document.getElementsByTagName('nav')[0];
    navbar.classList.add('navbar-transparent');
  }
  ngOnDestroy() {
    var body = document.getElementsByTagName('body')[0];
    body.classList.remove('login-page');

    var navbar = document.getElementsByTagName('nav')[0];
    navbar.classList.remove('navbar-transparent');
  }
  LoginIn(user) {
    let loginVM: LoginVM = new LoginVM();

    loginVM.Username = this.user.name;
    loginVM.Password = this.user.password;

    this.httpService.post<LoginVM, Token>("login", loginVM, "Login").subscribe(data => {
      localStorage.setItem("accesstoken", data.accessToken);
      localStorage.setItem("refreshToken", data.refreshToken);
      this.goToHomePage();
    });
  }
  goToHomePage() {
   window.location.href = "index"
  }
}
