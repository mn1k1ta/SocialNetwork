import { Component, OnInit } from '@angular/core';
import {UserService} from '../../shared/user.service';
import {UserProfileModel} from '../../Models/user-profile-model';
import {ToastrService} from 'ngx-toastr';

@Component({
  selector: 'app-edit-user-profile',
  templateUrl: './edit-user-profile.component.html',
  styleUrls: ['./edit-user-profile.component.css']
})
export class EditUserProfileComponent implements OnInit {
userProfileForEdit: UserProfileModel = new UserProfileModel();
  constructor(private service: UserService, private toastr: ToastrService) { }

  ngOnInit(): void {
    this.loadUserProfile();
  }
  loadUserProfile() {
    this.service.getAuthUser().subscribe((data: UserProfileModel) => this.userProfileForEdit = data);
  }
  editUserProfile(userProfileModel: UserProfileModel) {
    this.service.editUserProfile(userProfileModel).subscribe(res => {
      this.toastr.success('\n' + 'Changes saved', 'Edit User');
  });
  }
}
