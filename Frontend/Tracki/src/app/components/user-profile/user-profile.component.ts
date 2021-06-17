import { Component, OnInit } from '@angular/core';
import { UserService } from "src/app/services/user.service"
import { ActivatedRoute } from "@angular/router";
import { UserDetailedInfo } from 'src/app/models/UserDetailedInfo';

@Component({
  selector: 'app-user-profile',
  templateUrl: './user-profile.component.html',
  styleUrls: ['./user-profile.component.scss']
})
export class UserProfileComponent implements OnInit {

  userInfo: UserDetailedInfo = new UserDetailedInfo();

  constructor(private route: ActivatedRoute,
              private userService: UserService) { }

  ngOnInit(): void {
    this.route.paramMap.subscribe(params => {
      this.getUserInfo(params.get("userName"));
    })
  }

  getUserInfo(userName: string): void {
    this.userService.getUserByUsername(userName).subscribe(res => {
      this.userInfo = res;
    })
  }

}
