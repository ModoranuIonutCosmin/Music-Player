import {Component, EventEmitter, Input, OnInit, Output} from '@angular/core';
import {SongInfo} from "../../models/song-info";

@Component({
  selector: 'app-song-browser',
  templateUrl: './song-browser.component.html',
  styleUrls: ['./song-browser.component.scss']
})

export class SongBrowserComponent implements OnInit {
  displayedColumns: string[] = ['position', 'coverImg', 'name', 'length', 'controls'];
  @Input() dataSource: SongInfo[];
  @Output() songPlayClicked: EventEmitter<SongInfo> = new EventEmitter<SongInfo>();
  highlightedElementIndex: number = -1;

  constructor() {
    this.dataSource = []
  }

  ngOnInit(): void {

  }

  songPlayed(songInfo: SongInfo) {
    this.songPlayClicked.emit(songInfo);
  }

}
