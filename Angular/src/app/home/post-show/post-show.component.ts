import { Component, OnInit } from '@angular/core';
import {PostService} from '../../shared/post.service';
import {Router} from '@angular/router';
import {PostModel} from '../../Models/post-model';
import {ToastrService} from 'ngx-toastr';
import {UserService} from '../../shared/user.service';

@Component({
  selector: 'app-post-show',
  templateUrl: './post-show.component.html',
  styleUrls: ['./post-show.component.css']
})
export class PostShowComponent implements OnInit {
  post: PostModel = new PostModel();
  posts: PostModel[];
  constructor(private service: PostService, private router: Router, private toastr: ToastrService, private userService: UserService) { }

  ngOnInit(): void {
    this.loadAllPosts();
  }
  loadAllPosts() {
    this.service.loadAllPosts().subscribe((data: PostModel[]) => this.posts = data);
  }
  comment(postId: any) {
    localStorage.setItem('postIdForComment', postId);
    this.router.navigateByUrl('/home/app-comments');
  }
  goToUserProfile(id: any) {
    localStorage.setItem('anyUserIdForShow', id);
    this.router.navigateByUrl('/home/app-any-user-profile-show');
  }
}
