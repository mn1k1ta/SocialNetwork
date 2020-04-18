import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { UserComponent } from './user/user.component';
import { RegistrationComponent } from './user/registration/registration.component';
import { LoginComponent } from './user/login/login.component';
import { HomeComponent } from './home/home.component';
import { AuthGuard } from './auth/auth.guard';
import {EditUserProfileComponent} from './home/edit-user-profile/edit-user-profile.component';


const routes: Routes = [
  {path: '', redirectTo: '/user/registration', pathMatch: 'full'},
  {
    path: 'user', component: UserComponent,
    children: [
      {path: 'login', component: LoginComponent},
      { path: 'registration', component: RegistrationComponent }
    ]
  },
  {path: 'home' , component : HomeComponent, canActivate:[AuthGuard],
    children: [
      {path: 'edit-user-profile', component: EditUserProfileComponent}
    ]
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
