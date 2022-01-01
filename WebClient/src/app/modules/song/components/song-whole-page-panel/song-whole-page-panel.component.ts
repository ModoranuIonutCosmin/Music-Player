import {Component, Input, OnInit} from '@angular/core';
import {SongInfo} from "../../../album/models/song-info";

@Component({
  selector: 'app-song-whole-page-panel',
  templateUrl: './song-whole-page-panel.component.html',
  styleUrls: ['./song-whole-page-panel.component.scss']
})
export class SongWholePagePanelComponent implements OnInit {

  @Input() dataSource?: SongInfo;

  constructor() { }

  ngOnInit(): void {
  }

}
