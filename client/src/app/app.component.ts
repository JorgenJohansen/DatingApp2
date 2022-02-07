import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  title = 'The Best dating app on the market';
  users: any;
  apiUrl: string = 'https://localhost:5001/api/users';

  constructor(private http: HttpClient) {}


  ngOnInit(){
    this.getUsers();
    console.log(this.users);
  }

  getUsers(){
    this.http.get('https://localhost:5001/api/users').subscribe(
      data => {
        this.users = data;
      },
      error => {
        console.log(error)
      }
    );
  }
}
