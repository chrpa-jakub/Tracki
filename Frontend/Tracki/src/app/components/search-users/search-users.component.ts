import { Component, Input, OnInit } from '@angular/core';
import { UserService } from "src/app/services/user.service"
import { UserBasicInfo } from 'src/app/models/UserBasicInfo';
import { ActivatedRoute } from "@angular/router";

@Component({
  selector: 'app-search-users',
  templateUrl: './search-users.component.html',
  styleUrls: ['./search-users.component.scss']
})
export class SearchUsersComponent implements OnInit {

  @Input() searchText: string;

  usersToDisplay: UserBasicInfo[] = [];
  constructor(private userService: UserService,
              private route: ActivatedRoute) { }

  ngOnInit(): void {
    this.route.paramMap.subscribe(params => {
      this.searchText = params.get("searchText");
      this.searchUser();
    })
  }

  searchAllUsers(): void {
    this.usersToDisplay = [];
    this.userService.getAllUsers().subscribe(res => {
      this.usersToDisplay.push(...res);
    });
  }

  searchUser(): void {
    this.usersToDisplay = [];
    this.userService.getUsersBySearch(this.searchText).subscribe(res => {
      this.usersToDisplay.push(...res);
    })
  }

}
