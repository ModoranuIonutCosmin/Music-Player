import {Component, Input, OnInit} from '@angular/core';
import {AlbumInfo} from "../../models/album-info";

@Component({
  selector: 'app-album-info-panel',
  templateUrl: './album-info-panel.component.html',
  styleUrls: ['./album-info-panel.component.scss']
})
export class AlbumInfoPanelComponent implements OnInit {

  @Input() dataSource!: AlbumInfo;
  constructor() {

  }

  ngOnInit(): void {

  }

}
