import { Component, OnInit } from '@angular/core';
import {Router} from "@angular/router";

@Component({
  selector: 'app-searchbar',
  templateUrl: './searchbar.component.html',
  styleUrls: ['./searchbar.component.scss']
})
export class SearchbarComponent implements OnInit {

  searchBarInput: string = "";

  constructor(private router: Router) { }

  ngOnInit(): void {
  }

  search() {

    console.log(this.searchBarInput);
    if (this.searchBarInput && this.searchBarInput.trim()) {
      this.router.navigate(['search', `${btoa(this.searchBarInput)}`]);
    }
  }
}
