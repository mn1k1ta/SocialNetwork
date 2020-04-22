import { Component, OnInit } from '@angular/core';
import {UserService} from '../../shared/user.service';
import {UserProfileModel} from '../../Models/user-profile-model';
import {FilterForSearchModel} from '../../Models/filter-for-search-model';
import {ToastrService} from 'ngx-toastr';
import {Router} from '@angular/router';
import {FriendsService} from '../../shared/friends.service';
import {HelperModel} from '../../Models/helperModel';

@Component({
  selector: 'app-find-user-by-filter',
  templateUrl: './find-user-by-filter.component.html',
  styleUrls: ['./find-user-by-filter.component.css']
})
export class FindUserByFilterComponent implements OnInit {
user: UserProfileModel = new UserProfileModel();
users: UserProfileModel[];
filter: FilterForSearchModel = new FilterForSearchModel();
userIdByAuth: any;
  constructor(private service: UserService, private toastr: ToastrService, private router: Router, private friendService: FriendsService) { }

  ngOnInit(): void {
    this.filterForSearch(this.filter);
    this.userIdByAuth = sessionStorage.getItem('authUserProfileId');
  }
  filterForSearch(filter: FilterForSearchModel) {
    this.service.findUserByFilter(filter).subscribe((data: UserProfileModel[]) => this.users = data);
  }
  goToUserProfile(id: any) {
    sessionStorage.setItem('anyUserIdForShow', id);
    this.router.navigateByUrl('/home/app-any-user-profile-show');
  }
  addToFriends(friendId: any) {
    this.friendService.addToFriends(sessionStorage.getItem('authUserProfileId'), friendId).subscribe((data: HelperModel) => {
      if (data.succedeed) {
        this.toastr.success('\n' + '', data.message);
      } else {
        this.toastr.error('\n' + data.message, 'Error');
      }
    });
  }
}
