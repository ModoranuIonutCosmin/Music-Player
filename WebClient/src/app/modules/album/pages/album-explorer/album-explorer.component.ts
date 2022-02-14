import {Component, OnInit} from '@angular/core';
import {SongInfo} from "../../models/song-info";
import {ActivatedRoute} from "@angular/router";
import {flatMap, mergeMap} from "rxjs/operators";
import {AlbumService} from "../../../../core/services/media/album/album.service";
import {AlbumInfo} from "../../models/album-info";
import {MusicActivityService} from "../../../../core/services/states/music-activity.service";
import {AudioService} from "../../../../core/services/music player/audio.service";
import {DurationFormatterService} from "../../../../core/services/helpers/duration-formatter.service";
import {
  MusicPlayerControllerFacadeService
} from "../../../../core/services/music player/music-player-controller-facade.service";
import {PlaylistsPopupComponent} from "../../../../shared/components/playlists-popup/playlists-popup.component";
import {MatDialog} from "@angular/material/dialog";
import {ToastrHelpersService} from "../../../../core/services/helpers/toastr-helpers.service";

@Component({
  selector: 'app-album-explorer',
  templateUrl: './album-explorer.component.html',
  styleUrls: ['./album-explorer.component.scss']
})
export class AlbumExplorerComponent implements OnInit {
  albumData!: AlbumInfo;

  songsData: SongInfo[] =
    [];
  albumId!: string


  constructor(private route: ActivatedRoute,
              private albumService: AlbumService,
              private durationFormatter: DurationFormatterService,
              private playerService: MusicPlayerControllerFacadeService,
              ) {
  }

  ngOnInit(): void {
    this.route.params.pipe(mergeMap((v, index) => {
      this.albumId = v['albumId'];

      return this.albumService.getAlbumData(this.albumId);
    })).subscribe(data => {
      this.albumData = data;
      this.songsData = data.songs || [];

      this.songsData.forEach((value, index) =>
      {
        let coverUrl = value.coverImageUrl;
        if(!(coverUrl && coverUrl.trim())){
          value.coverImageUrl = data.coverImageUrl
        }
      });
    });
  }

  songPlayClicked(songInfo: SongInfo) {
    console.log('playing' + JSON.stringify(songInfo));
    this.playerService.startPlayingAlbum(this.albumId, songInfo);
  }
}
