import { Injectable } from '@angular/core';
import {HttpClient, HttpHeaders, HttpParams} from '@angular/common/http';
import {Router} from '@angular/router';
import {CommentModel} from '../Models/comment-model';
import {UserProfileModel} from '../Models/user-profile-model';

@Injectable({
  providedIn: 'root'
})
export class CommentService {
  readonly BaseURI = 'https://localhost:5001/api';
  constructor(private http: HttpClient , private router: Router) { }
  loadCommentForPost(id: any) {
    const tokenHeader = new HttpHeaders({Authorization: 'Bearer ' + localStorage.getItem('token')});
    // tslint:disable-next-line:max-line-length
    return this.http.get(this.BaseURI + '/Comment/GetAllCommentsByPosts', { headers: tokenHeader, params: new HttpParams().set('postId', id)});
  }
  createComment(comment: CommentModel, postId: any) {
    const tokenHeader = new HttpHeaders({Authorization: 'Bearer ' + localStorage.getItem('token')});
    // tslint:disable-next-line:max-line-length
    return this.http.post(this.BaseURI + '/Comment/CreateComment', comment, { headers: tokenHeader, params: new HttpParams().set('userId', localStorage.getItem('authUserProfileId'))
        .set('postId', postId)});
  }
  getCommentById(id: any) {
    const tokenHeader = new HttpHeaders({Authorization: 'Bearer ' + localStorage.getItem('token')});
    // tslint:disable-next-line:max-line-length
    return this.http.get(this.BaseURI + '/Comment/GetCommentById', { headers: tokenHeader, params: new HttpParams().set('id', id)});
  }
  editComment(comment: CommentModel) {
    const tokenHeader = new HttpHeaders({Authorization: 'Bearer ' + localStorage.getItem('token')});
    // tslint:disable-next-line:max-line-length
    return this.http.put(this.BaseURI + '/Comment/EditComment', comment, { headers: tokenHeader});
  }
  deleteComment(id: any) {
      const tokenHeader = new HttpHeaders({Authorization: 'Bearer ' + localStorage.getItem('token')});
      // tslint:disable-next-line:max-line-length
      return this.http.delete(this.BaseURI + '/Comment/DeleteComment', { headers: tokenHeader, params: new HttpParams().set('commentId', id)});
  }
}
