import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { SongInfo } from '../models/SongInfo';

@Injectable({
  providedIn: 'root'
})
export class SongService {

  private baseUrl: string = 'https://localhost:5001/api/song';

  constructor(private http: HttpClient) { }

  getSongsBySearch(searchText: string): Observable<SongInfo[]> {
    return this.http.get<SongInfo[]>(`${this.baseUrl}/search/${searchText}`);
  }

}
