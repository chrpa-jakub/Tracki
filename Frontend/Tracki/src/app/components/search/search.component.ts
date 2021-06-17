import { Component, OnInit } from '@angular/core';
import { UserService } from "src/app/services/user.service"
import { SongService } from "src/app/services/song.service"
import { UserBasicInfo } from 'src/app/models/UserBasicInfo';
import { ActivatedRoute } from "@angular/router";
import { SongInfo } from 'src/app/models/SongInfo';

@Component({
  selector: 'app-search',
  templateUrl: './search.component.html',
  styleUrls: ['./search.component.scss']
})
export class SearchComponent implements OnInit {

  searchText: string;
  songsToDisplay: SongInfo[] = [];
  usersToDisplay: UserBasicInfo[] = [];
  
  constructor(private userService: UserService,
              private songService: SongService,
              private route: ActivatedRoute) { }

  ngOnInit(): void {
    this.route.paramMap.subscribe(params => {
      this.searchText = params.get("searchText");
      this.searchUsers();
      this.searchSongs();
    })
  }

  searchAllUsers(): void {
    this.usersToDisplay = [];
    this.userService.getAllUsers().subscribe(res => {
      this.usersToDisplay.push(...res);
    });
  }

  searchUsers(): void {
    this.usersToDisplay = [];
    this.userService.getUsersBySearch(this.searchText).subscribe(res => {
      this.usersToDisplay.push(...res);
    })
  }

  searchSongs(): void {
    this.songsToDisplay = [];
    this.songService.getSongsBySearch(this.searchText).subscribe(res => {
      this.songsToDisplay.push(...res);
    })
  }
  

}
