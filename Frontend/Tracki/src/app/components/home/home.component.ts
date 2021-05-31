import { Component, OnInit } from '@angular/core';
import { JwtHelperService } from '@auth0/angular-jwt';
import { Router } from '@angular/router';
import { AuthService } from 'src/app/services/auth-service'
import { UserBasicInfo } from 'src/app/models/UserBasicInfo';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})
export class HomeComponent implements OnInit {

  userBasicInfo: UserBasicInfo;

  constructor(private jwtHelper: JwtHelperService,
              private authService: AuthService,
              private router: Router) {}

  ngOnInit(): void {
    this.authService.getUserProfile().subscribe(
      res => {
        this.userBasicInfo = res;
        console.log(res);
      },
      err => {
        console.log(err);
      }
    )
  }

  get isLoggedIn(): boolean {
    return this.authService.isLoggedIn();
  }

  onLogOut() {
    this.authService.logout();
  }

}
