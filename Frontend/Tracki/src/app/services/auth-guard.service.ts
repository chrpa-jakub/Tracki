import { Injectable } from '@angular/core';
import { CanActivate, Router } from '@angular/router';
import { JwtHelperService } from '@auth0/angular-jwt';

@Injectable()
export class AuthGuard implements CanActivate {
  constructor(private jwtHelper: JwtHelperService, 
              private router: Router) {
  }

  // If there is jwt token in local storage and it isnt expired, the access is granted
  // otherwise it redirects to login page
  canActivate() {
    const token = localStorage.getItem("jwt");

    if (token && !this.jwtHelper.isTokenExpired(token)){
      return true;
    }

    this.router.navigate(["/login"]);
    return false;
  }
}