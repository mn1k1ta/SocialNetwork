import { Component, OnInit } from '@angular/core';
import {UserService} from '../../shared/user.service';
import {UserProfileModel} from '../../Models/user-profile-model';
import {FilterForSearchModel} from '../../Models/filter-for-search-model';
import {ToastrService} from 'ngx-toastr';

@Component({
  selector: 'app-find-user-by-filter',
  templateUrl: './find-user-by-filter.component.html',
  styleUrls: ['./find-user-by-filter.component.css']
})
export class FindUserByFilterComponent implements OnInit {
user: UserProfileModel = new UserProfileModel();
users: UserProfileModel[];
filter: FilterForSearchModel = new FilterForSearchModel();
  constructor(private service: UserService, private toastr: ToastrService) { }

  ngOnInit(): void {
    this.filterForSearch(this.filter);
  }
  filterForSearch(filter: FilterForSearchModel) {
    this.service.findUserByFilter(filter).subscribe((data: UserProfileModel[]) => this.users = data);
  }

}
