import {Component, Input, OnInit} from '@angular/core';
import {SongInfo} from "../../models/song-info";

@Component({
  selector: 'app-song-browser',
  templateUrl: './song-browser.component.html',
  styleUrls: ['./song-browser.component.scss']
})

export class SongBrowserComponent implements OnInit {
  displayedColumns: string[] = ['position', 'coverImg', 'name', 'length', 'controls'];
  @Input() dataSource: SongInfo[];
  constructor() {
    this.dataSource = []
  }

  ngOnInit(): void {
  }

}
