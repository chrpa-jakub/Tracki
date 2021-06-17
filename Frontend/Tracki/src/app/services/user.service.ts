import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { UserBasicInfo } from '../models/UserBasicInfo';
import { UserDetailedInfo } from '../models/UserDetailedInfo';

@Injectable({
  providedIn: 'root'
})
export class UserService {
  private baseUrl: string = 'https://localhost:5001/api/user';

  constructor(private http: HttpClient) { }

  getAllUsers(): Observable<UserBasicInfo[]> {
    return this.http.get<UserBasicInfo[]>(`${this.baseUrl}/all`);
  }

  getUserByUsername(userName: string): Observable<UserDetailedInfo> {
    return this.http.get<UserDetailedInfo>(`${this.baseUrl}/${userName}`);
  }

  getUsersBySearch(searchText: string): Observable<UserBasicInfo[]> {
    return this.http.get<UserBasicInfo[]>(`${this.baseUrl}/search/${searchText}`);
  }

  followUser(userName: string) {
    return this.http.get(`${this.baseUrl}/${userName}/follow`);
  }
}
