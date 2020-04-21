import { Component, OnInit } from '@angular/core';
import {PostService} from '../../shared/post.service';
import {PostModel} from '../../Models/post-model';
import {CommentService} from '../../shared/comment.service';
import {CommentModel} from '../../Models/comment-model';
import {Router} from '@angular/router';
import {ToastrService} from 'ngx-toastr';

@Component({
  selector: 'app-comment',
  templateUrl: './comment.component.html',
  styleUrls: ['./comment.component.css']
})
export class CommentComponent implements OnInit {
post: PostModel = new PostModel();
comment: CommentModel = new CommentModel();
comments: CommentModel[];
userProfileId: any;
  constructor(private postService: PostService, private commentService: CommentService, private router: Router, private toastr: ToastrService) { }

  ngOnInit(): void {
    this.loadPost();
    this.loadComments();
    this.userProfileId = localStorage.getItem('authUserProfileId');
  }
  loadPost() {
    this.postService.loadPostById(localStorage.getItem('postIdForComment')).subscribe((data: PostModel) => this.post = data);
  }
  loadComments() {
    // tslint:disable-next-line:max-line-length
    this.commentService.loadCommentForPost(localStorage.getItem('postIdForComment')).subscribe((data: CommentModel[]) => this.comments = data);
  }
  createComment(comment: CommentModel) {
    this.commentService.createComment(comment, this.post.postId).subscribe(res => {
      this.toastr.success('\n' + '', '\n' + 'Comment Added!');
      this.ngOnInit();
    });
  }
  edit(id: any) {
    localStorage.setItem('idCommentForEdit', id);
    this.router.navigateByUrl('/home/app-comments-edit');
  }
  delete(id: any) {
    this.commentService.deleteComment(id).subscribe(res => {
      this.toastr.success('\n' + '', '\n' + 'Comment Deleted!');
      this.ngOnInit();
    });
  }
  goToUserProfile(id: any) {
    localStorage.setItem('anyUserIdForShow', id);
    this.router.navigateByUrl('/home/app-any-user-profile-show');
  }

}
