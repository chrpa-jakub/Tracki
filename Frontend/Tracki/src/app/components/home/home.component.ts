import { Component, OnInit } from '@angular/core';
import { JwtHelperService } from '@auth0/angular-jwt';
import { Router } from '@angular/router';
import { AuthService } from 'src/app/services/auth-service'
import { AccountService } from 'src/app/services/account.service'
import { UserBasicInfo } from 'src/app/models/UserBasicInfo';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})
export class HomeComponent implements OnInit {

  userBasicInfo: UserBasicInfo = new UserBasicInfo();

  isUserMenuVisible: boolean = false;

  constructor(private accountService: AccountService,
              private authService: AuthService,
              private router: Router) {}

  ngOnInit(): void {
    this.accountService.getAccountOverview().subscribe(
      res => {
        this.userBasicInfo = res;
      }
    )
  }

  get isLoggedIn(): boolean {
    return this.authService.isLoggedIn();
  }

  onLogOut() {
    this.authService.logout();
  }

  onAccountClick() {
    this.router.navigateByUrl("/account");
    console.log("account");
  }

  onProfileClick() {
    this.router.navigateByUrl("/profile");
  }

  onUsernameClick() {
    this.isUserMenuVisible = !this.isUserMenuVisible;
  }

}
