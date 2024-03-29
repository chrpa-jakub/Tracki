import { Injectable } from '@angular/core';
import { UserLoginInfo } from 'src/app/models/UserLoginInfo'
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { JwtHelperService } from '@auth0/angular-jwt';
import { UserBasicInfo } from '../models/UserBasicInfo';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  private baseUrl:string = 'https://localhost:5001/api/auth';

  httpOptions = {
    withCredentials: true,
    headers: new HttpHeaders({ 'Content-Type': 'application/json' })
  };

  constructor(private http:HttpClient,
     private jwtHelper: JwtHelperService) { }

  signup(login: UserLoginInfo): Observable<UserLoginInfo>{  
    return this.http.post<UserLoginInfo>(`${this.baseUrl}/signup`, login, this.httpOptions);
  }

  login(login: UserLoginInfo): Observable<UserLoginInfo>{
    return this.http.post<UserLoginInfo>(`${this.baseUrl}/login`, login, this.httpOptions);
  }

  // For login we just remove the jwt token from local storage
  logout(): void {
    localStorage.removeItem("jwt");
  }

  // Checks if the user is logged in by checking jwt token expiration and if it even exists
  isLoggedIn(): boolean {
    const token = localStorage.getItem("jwt");
    if (token && !this.jwtHelper.isTokenExpired(token)){
      return true;
    }
    return false;
  }
}
