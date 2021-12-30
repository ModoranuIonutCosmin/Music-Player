import {Component, OnInit} from '@angular/core';
import {SongInfo} from "../../models/song-info";
import {ActivatedRoute} from "@angular/router";
import {flatMap, mergeMap} from "rxjs/operators";
import {AlbumService} from "../../../../core/services/media/album/album.service";
import {AlbumInfo} from "../../models/album-info";

@Component({
  selector: 'app-album-explorer',
  templateUrl: './album-explorer.component.html',
  styleUrls: ['./album-explorer.component.scss']
})
export class AlbumExplorerComponent implements OnInit {
  albumData!: AlbumInfo;
  albumDescription: any;

  songsData: SongInfo[] =
    [{
      coverImgUrl: "https://media.istockphoto.com/photos/vintage-vinyl-record-album-cover-mockup-flat-concept-picture-id1127565686?b=1&k=20&m=1127565686&s=170667a&w=0&h=OBvTbZEFPOwXQLGWAKODUXwX8VaiEbQvPWrNzfl5GUI=",
      name: 'Song name here',
      length: 100,
      position: 1
    },
      {
        coverImgUrl: "https://media.istockphoto.com/photos/vintage-vinyl-record-album-cover-mockup-flat-concept-picture-id1127565686?b=1&k=20&m=1127565686&s=170667a&w=0&h=OBvTbZEFPOwXQLGWAKODUXwX8VaiEbQvPWrNzfl5GUI=",
        name: 'track #1 soundscape',
        length: 1004001,
        position: 2
      },
      {
        coverImgUrl: "https://media.istockphoto.com/photos/vintage-vinyl-record-album-cover-mockup-flat-concept-picture-id1127565686?b=1&k=20&m=1127565686&s=170667a&w=0&h=OBvTbZEFPOwXQLGWAKODUXwX8VaiEbQvPWrNzfl5GUI=",
        name: 'some music ',
        length: 1002121,
        position: 2
      }];
  albumId!: string

  constructor(private route: ActivatedRoute,
              private albumService: AlbumService) {
  }

  ngOnInit(): void {
    this.route.params.pipe(mergeMap((v, index) => {
      return this.albumService.getAlbumData(v['albumId']);
    })).subscribe(data => {
      this.albumData = data;
      this.songsData = data.songs || [];

      this.songsData.forEach((value, index) =>
      {
        value.position = index + 1;
        let coverUrl = value.coverImgUrl;
        if(!(coverUrl && coverUrl.trim())){
          value.coverImgUrl = data.coverImageUrl
        }
      });

      console.log(this.songsData);
    });
  }

}
