import {Component, OnInit} from '@angular/core';
import {SongInfo} from "../../models/song-info";
import {ActivatedRoute} from "@angular/router";
import {flatMap, mergeMap} from "rxjs/operators";
import {AlbumService} from "../../../../core/services/media/album/album.service";
import {AlbumInfo} from "../../models/album-info";
import {MusicActivityService} from "../../../../core/services/states/music-activity.service";
import {AudioService} from "../../../../core/services/music player/audio.service";
import {DurationFormatterService} from "../../../../core/services/helpers/duration-formatter.service";

@Component({
  selector: 'app-album-explorer',
  templateUrl: './album-explorer.component.html',
  styleUrls: ['./album-explorer.component.scss']
})
export class AlbumExplorerComponent implements OnInit {
  albumData!: AlbumInfo;

  songsData: SongInfo[] =
    [{
      coverImageUrl: "https://media.istockphoto.com/photos/vintage-vinyl-record-album-cover-mockup-flat-concept-picture-id1127565686?b=1&k=20&m=1127565686&s=170667a&w=0&h=OBvTbZEFPOwXQLGWAKODUXwX8VaiEbQvPWrNzfl5GUI=",
      name: 'Song name here',
      length: 100,
      position: 1
    },
      {
        coverImageUrl: "https://media.istockphoto.com/photos/vintage-vinyl-record-album-cover-mockup-flat-concept-picture-id1127565686?b=1&k=20&m=1127565686&s=170667a&w=0&h=OBvTbZEFPOwXQLGWAKODUXwX8VaiEbQvPWrNzfl5GUI=",
        name: 'track #1 soundscape',
        length: 1004001,
        position: 2
      },
      {
        coverImageUrl: "https://media.istockphoto.com/photos/vintage-vinyl-record-album-cover-mockup-flat-concept-picture-id1127565686?b=1&k=20&m=1127565686&s=170667a&w=0&h=OBvTbZEFPOwXQLGWAKODUXwX8VaiEbQvPWrNzfl5GUI=",
        name: 'some music ',
        length: 1002121,
        position: 2
      }];
  albumId!: string

  constructor(private route: ActivatedRoute,
              private albumService: AlbumService,
              private audioService: AudioService,
              private mediaActivityService: MusicActivityService,
              private durationFormatter: DurationFormatterService
              ) {
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
        value.formattedLength = this.durationFormatter.formatLength(value.length);
        let coverUrl = value.coverImageUrl;
        if(!(coverUrl && coverUrl.trim())){
          value.coverImageUrl = data.coverImageUrl
        }
      });
    });
  }

  songPlayClicked(songInfo: SongInfo) {
    this.mediaActivityService.storeLastActivity("album", this.albumId, 0, songInfo, true);
  }
}
