import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { UserComponent } from './user/user.component';
import { RegistrationComponent } from './user/registration/registration.component';
import { LoginComponent } from './user/login/login.component';
import { HomeComponent } from './home/home.component';
import { AuthGuard } from './auth/auth.guard';
import {EditUserProfileComponent} from './home/edit-user-profile/edit-user-profile.component';
import {ShowUserProfileComponent} from './home/show-user-profile/show-user-profile.component';
import {PostShowComponent} from './home/post-show/post-show.component';
import {MyPostsShowComponent} from './home/my-posts-show/my-posts-show.component';
import {EditMyPostComponent} from './home/edit-my-post/edit-my-post.component';
import {CreatePostComponent} from './home/create-post/create-post.component';
import {FindUserByFilterComponent} from './home/find-user-by-filter/find-user-by-filter.component';


const routes: Routes = [
  {path: '', redirectTo: '/user/registration', pathMatch: 'full'},
  {
    path: 'user', component: UserComponent,
    children: [
      {path: 'login', component: LoginComponent},
      { path: 'registration', component: RegistrationComponent }
    ]
  },
  {path: 'home' , component : HomeComponent, canActivate: [AuthGuard],
    children: [
      {path: 'app-edit-user-profile', component: EditUserProfileComponent},
      {path: 'app-show-user-profile', component: ShowUserProfileComponent},
      {path: 'app-show-posts', component: PostShowComponent},
      {path: 'app-my-show-posts', component: MyPostsShowComponent},
      {path: 'app-edit-post', component: EditMyPostComponent},
      {path: 'app-create-post', component: CreatePostComponent},
      {path: 'app-search-user', component: FindUserByFilterComponent}
    ]
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
