import { Component, OnInit } from '@angular/core';
import {UserProfileModel} from '../../Models/user-profile-model';
import {UserService} from '../../shared/user.service';

@Component({
  selector: 'app-show-any-user-profile',
  templateUrl: './show-any-user-profile.component.html',
  styleUrls: ['./show-any-user-profile.component.css']
})
export class ShowAnyUserProfileComponent implements OnInit {
userProfile: UserProfileModel = new UserProfileModel();
  constructor(private service: UserService) { }

  ngOnInit(): void {
    this.loadUserProfile();
  }
  loadUserProfile() {
    this.service.getUserById(sessionStorage.getItem('anyUserIdForShow')).subscribe((data: UserProfileModel) => this.userProfile = data);
  }
}
