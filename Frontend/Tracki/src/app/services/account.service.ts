import { Injectable } from '@angular/core';
import { UserLoginInfo } from 'src/app/models/UserLoginInfo'
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { UserBasicInfo } from '../models/UserBasicInfo';

@Injectable({
  providedIn: 'root'
})
export class AccountService {
  private baseUrl: string = 'https://localhost:5001/api/account';

  constructor(private http: HttpClient) { }

  getAccountOverview(): Observable<UserBasicInfo> {
    return this.http.get<UserBasicInfo>(`${this.baseUrl}/overview`);
  }

  editAccount(userInfo: UserLoginInfo): Observable<UserLoginInfo> {
    return this.http.post<UserLoginInfo>(`${this.baseUrl}/edit`, userInfo);
  }

}
