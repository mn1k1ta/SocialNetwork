import { Injectable } from '@angular/core';
import {FormBuilder} from '@angular/forms';
import {HttpClient, HttpHeaders, HttpParams} from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class MessageService {
  constructor(private fb: FormBuilder, private http: HttpClient) { }
  readonly BaseURI = 'https://localhost:5001/api';
  getAllMessagesByDialog(userId: any, friendId: any) {
    const tokenHeader = new HttpHeaders({Authorization: 'Bearer ' + sessionStorage.getItem('token')});
    // tslint:disable-next-line:max-line-length
    return this.http.get(this.BaseURI + '/Message/GetAllMessagesByDialog', { headers: tokenHeader, params: new HttpParams().set('userId', userId).
      set('friendId', friendId)});
  }
}
