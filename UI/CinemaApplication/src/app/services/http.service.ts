import { Injectable, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class HttpService {

  constructor(private httpClient: HttpClient, @Inject("url") private url: string) { }

  get<ReturnType>(controller: string, action?: string, id?: number): Observable<ReturnType> {
    return this.httpClient.get<ReturnType>(`${this.url}/${controller}/${action == null ? (id ? id : "") : `${action}/${id}`}`);
  }
 
  post<BodyType, ReturnType>(controller: string, body: BodyType, action?: string): Observable<ReturnType> {
    return this.httpClient.post<ReturnType>(`${this.url}/${controller}${action ? `/${action}` : ""}`, body);
  }

  put<BodyType, ReturnType>(controller: string, body:BodyType , action?: string): Observable<ReturnType> {
    return this.httpClient.put<ReturnType>(`${this.url}/${controller}${action ? `/${action}` : ""}`, body);
  }

  delete<ReturnType>(controller: string, id: number, action?: string): Observable<ReturnType> {
    return this.httpClient.delete<ReturnType>(`${this.url}/${controller}/${action == null ? id : `${action}/${id}`}`);
  }

}
