import { Injectable } from '@angular/core';
import {HttpClient, HttpHeaders, HttpParams} from '@angular/common/http';
import {Router} from '@angular/router';

@Injectable({
  providedIn: 'root'
})
export class FriendsService {
  readonly BaseURI = 'https://localhost:5001/api';
  constructor(private http: HttpClient , private router: Router) { }
  loadFriendsByUser(id: any) {
    const tokenHeader = new HttpHeaders({Authorization: 'Bearer ' + localStorage.getItem('token')});
    // tslint:disable-next-line:max-line-length
    return this.http.get(this.BaseURI + '/Friends/GetFriendsUser', { headers: tokenHeader, params: new HttpParams().set('userId', id)});
  }
  deleteUser(userId: any, friendsId: any) {
    const tokenHeader = new HttpHeaders({Authorization: 'Bearer ' + localStorage.getItem('token')});
    // tslint:disable-next-line:max-line-length
    return this.http.delete(this.BaseURI + '/Friends/RemoveUserFromFriends', { headers: tokenHeader, params: new HttpParams().set('userId', userId)
        .set('friendsId', friendsId)});
  }
  addToFriends(userId: any, friendId: any) {
    const tokenHeader = new HttpHeaders({Authorization: 'Bearer ' + localStorage.getItem('token')});
    // tslint:disable-next-line:max-line-length
    return this.http.get(this.BaseURI + '/Friends/AddUserToFriends',  { headers: tokenHeader, params: new HttpParams().set('userId', userId)
        .set('friendId', friendId)});
  }
}
