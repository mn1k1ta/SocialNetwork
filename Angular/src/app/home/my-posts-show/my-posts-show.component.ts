import { Component, OnInit } from '@angular/core';
import {PostService} from '../../shared/post.service';
import {PostModel} from '../../Models/post-model';

@Component({
  selector: 'app-my-posts-show',
  templateUrl: './my-posts-show.component.html',
  styleUrls: ['./my-posts-show.component.css']
})
export class MyPostsShowComponent implements OnInit {
post: PostModel = new PostModel();
posts: PostModel[];
  constructor(private service: PostService) { }

  ngOnInit(): void {
    this.loadMyPosts();
  }
  loadMyPosts() {
    this.service.loadMyPosts().subscribe((data: PostModel[]) => this.posts = data);
  }

}
