import { Component, OnInit, Input } from '@angular/core';
import { UserBasicInfo } from 'src/app/models/UserBasicInfo';

@Component({
  selector: 'app-individual-search-user',
  templateUrl: './individual-search-user.component.html',
  styleUrls: ['./individual-search-user.component.scss']
})
export class IndividualSearchUserComponent implements OnInit {
  
  @Input() user: UserBasicInfo;

  constructor() { }

  ngOnInit(): void {
  }

}
