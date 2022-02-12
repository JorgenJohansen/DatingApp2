import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { User } from './_models/user';
import { AccountService } from './_services/account.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  title = 'The Best dating app on the market';
  users: any;
  apiUrl: string = 'https://localhost:5001/api/users';




  constructor(private accountService: AccountService) {}



  ngOnInit(){
    this.setCurrentUser();

    // console.log(this.users);
  }

  setCurrentUser(){
    const user: User = JSON.parse(localStorage.getItem('user'));
    this.accountService.setCurrentUser(user);
  }

  

  
}
