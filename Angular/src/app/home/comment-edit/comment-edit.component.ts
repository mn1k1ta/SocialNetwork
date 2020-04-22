import { Component, OnInit } from '@angular/core';
import {CommentService} from '../../shared/comment.service';
import {ToastrService} from 'ngx-toastr';
import {CommentModel} from '../../Models/comment-model';

@Component({
  selector: 'app-comment-edit',
  templateUrl: './comment-edit.component.html',
  styleUrls: ['./comment-edit.component.css']
})
export class CommentEditComponent implements OnInit {
comment: CommentModel = new CommentModel();

  constructor(private service: CommentService, private toastr: ToastrService) { }

  ngOnInit(): void {
    this.loadComment();
  }
  loadComment() {
    this.service.getCommentById(sessionStorage.getItem('idCommentForEdit')).subscribe((data: CommentModel) => this.comment = data);
  }
  edit(comment: CommentModel) {
  this.service.editComment(comment).subscribe( res => {
    this.toastr.success('\n' + 'Changes saved', 'Edit Comment');
  });
  }
}
