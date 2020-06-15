import { Injectable, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class HttpService {

  constructor(private httpClient: HttpClient, @Inject("url") private url: string ){ }

  rootUrl(controller: string): string {
    return `${this.url}/${controller}`;
  }
  get<ReturnType>(controller: string, action?: string, id?: number): Observable<ReturnType> {
    return this.httpClient.get<ReturnType>(`${this.rootUrl(controller)}/${action == null ? (id ? id : "") : `${action}/${id}`}`);
  }
  post<BodyType, ReturnType>(controller: string, body: BodyType, action?: string): Observable<ReturnType> {
    return this.httpClient.post<ReturnType>(`${this.rootUrl(controller)}${action ? `/${action}` : ""}`, body);
  }

  put<BodyType, ReturnType>(controller: string, id: number, body: BodyType, action?: string): Observable<ReturnType> {
    return this.httpClient.put<ReturnType>(`${this.rootUrl(controller)}/${action == null ? id : `${action}/${id}`}`, body);
  }

  delete<ReturnType>(controller: string, id: number, action?: string): Observable<ReturnType> {
    return this.httpClient.delete<ReturnType>(`${this.rootUrl(controller)}/${action == null ? id : `${action}/${id}`}`);
  }
  
}
