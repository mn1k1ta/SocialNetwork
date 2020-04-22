import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { UserService } from 'src/app/shared/user.service';
import { Router } from '@angular/router';
import {UserProfileModel} from '../../Models/user-profile-model';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

count :number =0;
increase() : void {
  this.count++;
}
  formModel={
    UserName: '',
    Password: ''
  }
  constructor(private service: UserService, private router: Router) { }

  ngOnInit() {
  }

  onSubmit(form: NgForm) {
    this.service.login(form.value).subscribe(
      (res: any) => {
        localStorage.setItem('token', res.token);
        localStorage.setItem('userId', res.id);
        this.setUserProfileId(res.id);
        this.router.navigateByUrl('/home/app-show-user-profile');
      },
      err => {
        if (err.status != 400)
                   console.log(err);
      });
  }
  setUserProfileId(id: any) {
    // tslint:disable-next-line:max-line-length
    this.service.getUserProfile(id).subscribe((data: UserProfileModel) => localStorage.setItem('authUserProfileId' , data.userProfileId.toString()));
  }

}
