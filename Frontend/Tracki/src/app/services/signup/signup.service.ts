import { Injectable } from '@angular/core';
import { UserInfo } from 'src/app/models/Userinfo'
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class SignupService {
  private apiUrl = 'https://localhost:44332/api/Users'
  
  httpOptions = {
    headers: new HttpHeaders({ 'Content-Type': 'application/json' })
  };

  constructor(private http:HttpClient) { }

  signup(login: UserInfo): Observable<UserInfo>{  
    const url = `${this.apiUrl}/Create`
    return this.http.post<UserInfo>(url, login, this.httpOptions);
  }
}
