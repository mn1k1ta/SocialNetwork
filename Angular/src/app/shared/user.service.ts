import { Injectable } from '@angular/core';
import { FormBuilder, Validators, FormGroup } from '@angular/forms';
import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';
import { Observable } from 'rxjs';
import {UserProfileModel} from '../Models/user-profile-model';
import {FilterForSearchModel} from '../Models/filter-for-search-model';

@Injectable({
  providedIn: 'root'
})
export class UserService {

  constructor(private fb: FormBuilder, private http: HttpClient) { }
  readonly BaseURI = 'https://localhost:5001/api';

  formModel = this.fb.group({
    UserName: ['', Validators.required],
    Email: ['', Validators.email],
    FullName: [''],
    Passwords: this.fb.group({
      Password: ['', [Validators.required, Validators.minLength(4)]],
      ConfirmPassword: ['', Validators.required]
    }, { validator: this.comparePasswords })

  });

  comparePasswords(fb: FormGroup) {
    const confirmPswrdCtrl = fb.get('ConfirmPassword');
    // passwordMismatch
    // confirmPswrdCtrl.errors={passwordMismatch:true}
    if (confirmPswrdCtrl.errors == null || 'passwordMismatch' in confirmPswrdCtrl.errors) {
      if (fb.get('Password').value != confirmPswrdCtrl.value) {
        confirmPswrdCtrl.setErrors({ passwordMismatch: true });
      } else {
        confirmPswrdCtrl.setErrors(null);
      }
    }
  }

  register() {
    const body = {
      UserName: this.formModel.value.UserName,
      Email: this.formModel.value.Email,
      FullName: this.formModel.value.FullName,
      Password: this.formModel.value.Passwords.Password
    };
    return this.http.post(this.BaseURI + '/ApplicationUser/Register', body);
  }
  login(formData) {
    return this.http.post(this.BaseURI + '/ApplicationUser/Login', formData);
  }
  getAuthUser() {
    const tokenHeader = new HttpHeaders({Authorization: 'Bearer ' + localStorage.getItem('token')});
    // tslint:disable-next-line:max-line-length
    return this.http.get(this.BaseURI + '/UserProfile/GetUserProfileByApplicationUserId', { headers: tokenHeader, params: new HttpParams().set('userId', localStorage.getItem('userId'))});
  }
  editUserProfile(userProfile: UserProfileModel) {
    const tokenHeader = new HttpHeaders({Authorization: 'Bearer ' + localStorage.getItem('token')});
    // tslint:disable-next-line:max-line-length
    return this.http.put(this.BaseURI + '/UserProfile/EditUserProfile', userProfile, { headers: tokenHeader});
  }
  findUserByFilter(filter: FilterForSearchModel){
    const tokenHeader = new HttpHeaders({Authorization: 'Bearer ' + localStorage.getItem('token')});
    // tslint:disable-next-line:max-line-length
    return this.http.get(this.BaseURI + '/UserProfile/SearchByFilters', { headers: tokenHeader, params: new HttpParams().set('name', filter.name)
        .set('gender', filter.gender)
        .set('country', filter.country)
        .set('city', filter.city)});
  }
  getUserById(id: any) {
    const tokenHeader = new HttpHeaders({Authorization: 'Bearer ' + localStorage.getItem('token')});
    // tslint:disable-next-line:max-line-length
    return this.http.get(this.BaseURI + '/UserProfile/GetUserProfileById', { headers: tokenHeader, params: new HttpParams().set('id', id)});
  }

  getUserProfile(id: any) {
    const tokenHeader = new HttpHeaders({Authorization: 'Bearer ' + localStorage.getItem('token')});
    // tslint:disable-next-line:max-line-length
    return this.http.get(this.BaseURI + '/UserProfile/GetUserProfileByApplicationUserId', { headers: tokenHeader, params: new HttpParams().set('userId', id)});
  }
}


