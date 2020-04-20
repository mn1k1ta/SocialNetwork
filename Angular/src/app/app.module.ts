import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { ReactiveFormsModule, FormsModule } from "@angular/forms";
import { HttpClientModule, HTTP_INTERCEPTORS } from "@angular/common/http";
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { UserComponent } from './user/user.component';
import { RegistrationComponent } from './user/registration/registration.component';
import { LoginComponent } from './user/login/login.component';
import { HomeComponent } from './home/home.component';

import { UserService } from './shared/user.service';
import { ShowUserProfileComponent } from './home/show-user-profile/show-user-profile.component';
import { EditUserProfileComponent } from './home/edit-user-profile/edit-user-profile.component';
import {ToastrModule} from 'ngx-toastr';
import {CommonModule} from '@angular/common';
import { PostShowComponent } from './home/post-show/post-show.component';
import { MyPostsShowComponent } from './home/my-posts-show/my-posts-show.component';
import { EditMyPostComponent } from './home/edit-my-post/edit-my-post.component';

@NgModule({
  declarations: [
    AppComponent,
    UserComponent,
    RegistrationComponent,
    LoginComponent,
    HomeComponent,
    ShowUserProfileComponent,
    EditUserProfileComponent,
    PostShowComponent,
    MyPostsShowComponent,
    EditMyPostComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    ReactiveFormsModule,
    HttpClientModule,
    BrowserAnimationsModule,
    FormsModule,
    CommonModule,
    BrowserAnimationsModule,
    ToastrModule.forRoot()
  ],
  providers: [],

  bootstrap: [AppComponent]
})
export class AppModule { }
