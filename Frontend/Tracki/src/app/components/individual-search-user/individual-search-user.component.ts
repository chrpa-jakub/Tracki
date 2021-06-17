import { Component, OnInit, Input } from '@angular/core';
import { UserService } from "src/app/services/user.service"
import { UserBasicInfo } from 'src/app/models/UserBasicInfo';
import { Router } from '@angular/router';

@Component({
  selector: 'app-individual-search-user',
  templateUrl: './individual-search-user.component.html',
  styleUrls: ['./individual-search-user.component.scss']
})
export class IndividualSearchUserComponent implements OnInit {
  
  @Input() user: UserBasicInfo;

  constructor(private router: Router,
              private userService: UserService) { }

  ngOnInit(): void {
  }

  onUserClick(): void {
    this.router.navigateByUrl("/user/" + this.user.userName);
  }

  onFollowClick(): void {
    this.userService.followUser(this.user.userName).subscribe(res => {
      console.log("success");
    })
  }

}
