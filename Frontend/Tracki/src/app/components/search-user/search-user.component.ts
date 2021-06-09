import { Component, OnInit, Input } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-search-user',
  templateUrl: './search-user.component.html',
  styleUrls: ['./search-user.component.scss']
})
export class SearchUserComponent implements OnInit {
  searchText: string

  constructor(private router: Router) {
    this.searchText = this.router.getCurrentNavigation().extras.state.searchText;
   }

  ngOnInit(): void {
    console.log("init");
  }

}
