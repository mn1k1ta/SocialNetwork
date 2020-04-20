import { Component, OnInit } from '@angular/core';
import {PostService} from '../../shared/post.service';
import {ToastrService} from 'ngx-toastr';
import {PostModel} from '../../Models/post-model';

@Component({
  selector: 'app-create-post',
  templateUrl: './create-post.component.html',
  styleUrls: ['./create-post.component.css']
})
export class CreatePostComponent implements OnInit {
post: PostModel = new PostModel();
  constructor(private service: PostService, private toastr: ToastrService) { }

  ngOnInit(): void {
  }
  addPost(post: PostModel) {
    this.service.addPost(post).subscribe(res => {
      this.toastr.success('\n' + '', '\n' + 'Post created!');
    });

  }

}
