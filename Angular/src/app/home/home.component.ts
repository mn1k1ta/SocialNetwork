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
  user:User=new User();
  users:User[];
  userAuth:User=new User();
  tableMode:boolean=true;
  userName:string;

  constructor(private router: Router, private service: UserService) { }

  ngOnInit() {
    this.lodadUsers();
    this.loadAuthUser();
    
  }

  loadAuthUser(){
    this.service.getUserProfileById().subscribe((data:User)=>this.userAuth=data);
    this.userName=this.userAuth.userName;
    console.log(this.userAuth);
  }

  lodadUsers(){
    this.service.getProducts().subscribe((data:User[])=>this.users=data);
    console.log(this.users);
  }
  
  
  onLogout() {
    localStorage.removeItem('token');
    this.router.navigate(['/user/login']);
  }

  

}
