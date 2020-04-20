import { Component, OnInit } from '@angular/core';
import {PostService} from '../../shared/post.service';
import {PostModel} from '../../Models/post-model';
import {Router} from '@angular/router';
import {ToastrService} from 'ngx-toastr';

@Component({
  selector: 'app-my-posts-show',
  templateUrl: './my-posts-show.component.html',
  styleUrls: ['./my-posts-show.component.css']
})
export class MyPostsShowComponent implements OnInit {
post: PostModel = new PostModel();
posts: PostModel[];
  constructor(private service: PostService, private router: Router, private toastr: ToastrService) { }

  ngOnInit(): void {
    this.loadMyPosts();
  }
  loadMyPosts() {
    this.service.loadMyPosts().subscribe((data: PostModel[]) => this.posts = data);
  }
  editPost(id: any) {
    localStorage.setItem('IdPostForEdit', id);
    this.router.navigateByUrl('/home/app-edit-post');
  }
  deletePost(id: any) {
    this.service.deletePost(id).subscribe(res => {
      this.toastr.success('\n' + 'Delted!', 'Delete Post');
    });
  }
}
