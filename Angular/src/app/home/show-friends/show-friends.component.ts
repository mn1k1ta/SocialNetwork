import { Component, OnInit } from '@angular/core';
import {FriendsService} from '../../shared/friends.service';
import {UserProfileModel} from '../../Models/user-profile-model';
import {ToastrService} from 'ngx-toastr';
import {Router} from '@angular/router';
import {UserService} from '../../shared/user.service';

@Component({
  selector: 'app-show-friends',
  templateUrl: './show-friends.component.html',
  styleUrls: ['./show-friends.component.css']
})
export class ShowFriendsComponent implements OnInit {
user: UserProfileModel = new UserProfileModel();
friends: UserProfileModel[];
userId: number;
  constructor(private service: FriendsService, private toastr: ToastrService, private router: Router, private userService: UserService) { }

  ngOnInit(): void {
    this.loadMyFriends();
  }
  loadMyFriends() {
    this.userService.getAuthUser().subscribe((data: UserProfileModel) => {
      this.service.loadFriendsByUser(data.userProfileId).subscribe((data1: UserProfileModel[]) => this.friends = data1);
    });
  }
  deleteFriend(friendId: any) {
    this.service.deleteUser(sessionStorage.getItem('authUserProfileId'), friendId).subscribe(res => {
      this.toastr.success('\n' + '', 'Friend deleted!');
      this.ngOnInit();
    });
  }
  goToUserProfile(id: any) {
    sessionStorage.setItem('anyUserIdForShow', id);
    this.router.navigateByUrl('/home/app-any-user-profile-show');
  }
}
