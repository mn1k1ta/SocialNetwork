import { Component, OnInit } from '@angular/core';
import {PostService} from '../../shared/post.service';
import {Router} from '@angular/router';
import {PostModel} from '../../Models/post-model';
import {ToastrService} from 'ngx-toastr';

@Component({
  selector: 'app-post-show',
  templateUrl: './post-show.component.html',
  styleUrls: ['./post-show.component.css']
})
export class PostShowComponent implements OnInit {
  post: PostModel = new PostModel();
  posts: PostModel[];
  constructor(private service: PostService, private router: Router, private toastr: ToastrService) { }

  ngOnInit(): void {
    this.loadAllPosts();
  }
  loadAllPosts() {
    this.service.loadAllPosts().subscribe((data: PostModel[]) => this.posts = data);
  }

}
