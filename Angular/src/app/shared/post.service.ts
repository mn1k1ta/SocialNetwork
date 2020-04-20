import { Injectable } from '@angular/core';
import {HttpClient, HttpHeaders, HttpParams} from '@angular/common/http';
import {Router} from '@angular/router';

@Injectable({
  providedIn: 'root'
})
export class PostService {
  readonly BaseURI = 'https://localhost:5001/api';
  constructor(private http: HttpClient , private router: Router) { }
  loadAllPosts() {
    const tokenHeader = new HttpHeaders({Authorization: 'Bearer ' + localStorage.getItem('token')});
    // tslint:disable-next-line:max-line-length
    return this.http.get(this.BaseURI + '/Post/GetAllPosts', { headers: tokenHeader});
  }
  loadMyPosts() {
    const tokenHeader = new HttpHeaders({Authorization: 'Bearer ' + localStorage.getItem('token')});
    // tslint:disable-next-line:max-line-length
    return this.http.get(this.BaseURI + '/Post/GetPostsByUser', { headers: tokenHeader, params: new HttpParams().set('id', localStorage.getItem('authUserProfileId'))});
  }
}
