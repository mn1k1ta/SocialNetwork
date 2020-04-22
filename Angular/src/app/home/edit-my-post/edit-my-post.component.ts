import { Component, OnInit } from '@angular/core';
import {PostService} from '../../shared/post.service';
import {PostModel} from '../../Models/post-model';
import {ToastrService} from 'ngx-toastr';

@Component({
  selector: 'app-edit-my-post',
  templateUrl: './edit-my-post.component.html',
  styleUrls: ['./edit-my-post.component.css']
})
export class EditMyPostComponent implements OnInit {
post: PostModel = new PostModel();
  constructor(private  service: PostService, private toastr: ToastrService) { }

  ngOnInit(): void {
    this.loadPost();
  }
  editPost(post: PostModel) {
    this.service.editPost(post).subscribe(res => {
      this.toastr.success('\n' + 'Changes saved', 'Edit Post');
    });
  }
  loadPost() {
    this.service.loadPostById(sessionStorage.getItem('IdPostForEdit')).subscribe((data: PostModel) => this.post = data);
  }


}
