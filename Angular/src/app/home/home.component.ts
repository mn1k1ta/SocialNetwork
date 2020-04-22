import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { UserService } from '../shared/user.service';
import { User } from '../user';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {
  userDetails;
  user: User = new User();
  users: User[];
  userAuth: User = new User();
  tableMode: boolean = true;
  userName: string;

  constructor(private router: Router, private service: UserService) { }

  ngOnInit() {
  }
  onLogout() {
    sessionStorage.removeItem('token');
    this.router.navigate(['/user/login']);
    sessionStorage.clear();
  }
}
