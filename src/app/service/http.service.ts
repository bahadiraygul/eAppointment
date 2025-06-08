import { HttpClient, HttpResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { ResultModel } from '../models/result.model';
import { api } from '../constants';

@Injectable({
  providedIn: 'root'
})
export class HttpService {

  constructor( private http : HttpClient) { }

  post<T>(apiUrl : string, body: any, callBack :( res: ResultModel<T>) => void, errorCallBack? : (err: HttpResponse<any>) => void) {
    this.http.post<ResultModel<T>>(`${api}/${apiUrl}`,body)
    .subscribe({
      next: (res => {

     callBack(res);
        

      }),
      error: ((err: HttpResponse<any>) => {
        errorCallBack ? errorCallBack(err) : console.error('Error occurred:', err);
      })
    })
  }
}
