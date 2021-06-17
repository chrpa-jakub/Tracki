import { Component, Input, OnInit } from '@angular/core';
import { SongInfo } from 'src/app/models/SongInfo';

@Component({
  selector: 'app-individual-search-song',
  templateUrl: './individual-search-song.component.html',
  styleUrls: ['./individual-search-song.component.scss']
})
export class IndividualSearchSongComponent implements OnInit {

  @Input() song: SongInfo;
  isPlaying: boolean = false;
  
  constructor() { }

  ngOnInit(): void {
    console.log(this.song.location);
  }

  onPlayClick(): void {
    this.isPlaying = true;
  }

}
