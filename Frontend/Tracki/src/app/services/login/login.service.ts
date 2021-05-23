import { Injectable } from '@angular/core';
import { UserInfo } from 'src/app/models/Userinfo'
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class LoginService {
  private apiUrl = 'https://localhost:44332/api/Users'

  constructor(private http:HttpClient) { }

  login(login: UserInfo): Observable<UserInfo>{
    const url = `${this.apiUrl}/Login`
    this.http.get(url,  );
    return this.http.post<UserInfo>(url, login);
  }
}
