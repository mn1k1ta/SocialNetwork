import { Injectable } from '@angular/core';
import {HttpClient, HttpHeaders, HttpParams} from '@angular/common/http';
import {Router} from '@angular/router';
import {PostModel} from '../Models/post-model';

@Injectable({
  providedIn: 'root'
})
export class PostService {
  readonly BaseURI = 'https://localhost:5001/api';
  constructor(private http: HttpClient , private router: Router) { }
  loadAllPosts() {
    const tokenHeader = new HttpHeaders({Authorization: 'Bearer ' + sessionStorage.getItem('token')});
    // tslint:disable-next-line:max-line-length
    return this.http.get(this.BaseURI + '/Post/GetAllPosts', { headers: tokenHeader});
  }
  loadMyPosts() {
    const tokenHeader = new HttpHeaders({Authorization: 'Bearer ' + sessionStorage.getItem('token')});
    // tslint:disable-next-line:max-line-length
    return this.http.get(this.BaseURI + '/Post/GetPostsByUser', { headers: tokenHeader, params: new HttpParams().set('id', sessionStorage.getItem('authUserProfileId'))});
  }
  editPost(post: PostModel) {
    const tokenHeader = new HttpHeaders({Authorization: 'Bearer ' + sessionStorage.getItem('token')});
    // tslint:disable-next-line:max-line-length
    return this.http.put(this.BaseURI + '/Post/UpdatePost', post, { headers: tokenHeader});
  }
  loadPostById(id: any) {
    const tokenHeader = new HttpHeaders({Authorization: 'Bearer ' + sessionStorage.getItem('token')});
    // tslint:disable-next-line:max-line-length
    return this.http.get(this.BaseURI + '/Post/GetPostById', { headers: tokenHeader, params: new HttpParams().set('id', id)});
  }
  deletePost(postId: any) {
    const tokenHeader = new HttpHeaders({Authorization: 'Bearer ' + sessionStorage.getItem('token')});
    // tslint:disable-next-line:max-line-length
    return this.http.delete(this.BaseURI + '/Post/DeletePost', { headers: tokenHeader, params: new HttpParams().set('id', postId)});
  }
  addPost(post: PostModel) {
    const tokenHeader = new HttpHeaders({Authorization: 'Bearer ' + sessionStorage.getItem('token')});
    // tslint:disable-next-line:max-line-length
    return this.http.post(this.BaseURI + '/Post/CreatePost', post, { headers: tokenHeader, params: new HttpParams().set('userProfileDTOId', sessionStorage.getItem('authUserProfileId'))});
  }
}
