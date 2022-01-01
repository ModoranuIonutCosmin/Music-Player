import {Component, Input, OnInit} from '@angular/core';
import {AlbumInfo} from "../../models/album-info";

@Component({
  selector: 'app-album-info-panel',
  templateUrl: './album-info-panel.component.html',
  styleUrls: ['./album-info-panel.component.scss']
})
export class AlbumInfoPanelComponent implements OnInit {

  @Input() dataSource: AlbumInfo;
  constructor() {
    this.dataSource = {
      coverImageUrl: "https://upload.wikimedia.org/wikipedia/en/9/9a/BugMafiaDeCartier.jpg",
      name: "De cartier",
      description: "De cartier is the fourth studio album by hip hop group B.U.G. Mafia, released September1998.",
      releaseDate: new Date(),
      artists: [
        {
          "artistName": "Tataee",
          "firstName": "Irimia",
          "lastName": "Vlad"
        },
        {
          "artistName": "Caddy",
          "firstName": "Irimia",
          "lastName": "Vlad"
        },
        {
          "artistName": "Uzzi",
          "firstName": "Irimia",
          "lastName": "Vlad"
        }
      ]
    }
  }

  ngOnInit(): void {

  }

}
