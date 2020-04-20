import { Component, OnInit } from '@angular/core';
import {UserService} from '../../shared/user.service';
import {Router} from '@angular/router';
import {UserProfileModel} from '../../Models/user-profile-model';

@Component({
  selector: 'app-show-user-profile',
  templateUrl: './show-user-profile.component.html',
  styleUrls: ['./show-user-profile.component.css']
})
export class ShowUserProfileComponent implements OnInit {
  authUserProfile: UserProfileModel = new UserProfileModel();
  constructor(private service: UserService, private router: Router) { }

  ngOnInit(): void {
    this.loadAuthUserProfile();
  }
  loadAuthUserProfile() {
    this.service.getAuthUser().subscribe((data: UserProfileModel) => {
      this.authUserProfile = data;
      localStorage.setItem('authUserProfileId', data.userProfileId.toString());
    });
  }

}
