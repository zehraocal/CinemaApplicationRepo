import { HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { CanActivate, ActivatedRouteSnapshot, RouterStateSnapshot, UrlTree } from '@angular/router';
import { HttpService } from 'app/services/http.service';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class AuthorizeGuard implements CanActivate {
  constructor(private httpService: HttpService) {

  }

  canActivate(next: ActivatedRouteSnapshot, state: RouterStateSnapshot){
    let accessToken: string = localStorage.getItem("accesstoken");
    let _state: Promise<boolean>;
    debugger;
    _state = this.httpService.get<boolean>("login", null, null, new HttpHeaders({ "authorization": "Bearer " + localStorage.getItem("accesstoken") })).toPromise();
    return _state
  }
}
