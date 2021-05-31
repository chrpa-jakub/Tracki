import { Component, OnInit } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { UserBasicInfo } from 'src/app/models/UserBasicInfo';

@Component({
  selector: 'app-user',
  templateUrl: './user.component.html',
  styles: [``]
})

export class UserComponent implements OnInit  {
  users: any;
 
  constructor(private http: HttpClient) { }
 
  ngOnInit() {

  }
}