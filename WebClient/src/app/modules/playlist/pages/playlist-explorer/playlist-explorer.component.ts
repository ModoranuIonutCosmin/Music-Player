import {Component, Input, OnInit} from '@angular/core';
import {ActivatedRoute} from "@angular/router";
import {SongInfo} from "../../../album/models/song-info";
import {PlaylistInfo} from "../../models/playlist-info";
import {
  MusicPlayerControllerFacadeService
} from "../../../../core/services/music player/music-player-controller-facade.service";
import {PlaylistsService} from "../../../../core/services/playlists/playlists.service";
import {MatSnackBar} from "@angular/material/snack-bar";
import {DurationFormatterService} from "../../../../core/services/helpers/duration-formatter.service";

@Component({
  selector: 'app-playlist-explorer',
  templateUrl: './playlist-explorer.component.html',
  styleUrls: ['./playlist-explorer.component.scss']
})
export class PlaylistExplorerComponent implements OnInit {
  displayedColumns: string[] = ['position', 'coverImg', 'name', 'length', 'controls'];
  dataSource: SongInfo[] = [];
  playlistName: string = "";
  highlightedElementIndex: number = -1;
  playlistId: string = "";

  constructor(private route: ActivatedRoute,
              private playerService: MusicPlayerControllerFacadeService,
              private playlistService: PlaylistsService,
              private durationFormatter: DurationFormatterService,
              private snackbar: MatSnackBar) {
  }

  ngOnInit(): void {
    this.playlistId = this.route.snapshot.params['playlistId'];

    this.playlistService.loadSpecificPlaylist(this.playlistId)
      .subscribe(result => {
        this.dataSource = result.songs;
        this.playlistName = result.name;
      })
  }

  songPlayed(songInfo: SongInfo) {
    console.log(songInfo);
    this.playerService.startPlayingPlaylist(this.playlistId, songInfo);
  }

  removeFromPlaylist(songId: string) {
    this.playlistService.deleteSongFromPlaylist(this.playlistId, songId)
      .subscribe(result => {
        this.dataSource = this.dataSource.filter(song => song.id != songId);
        this.snackbar.open('The song was deleted!', 'Ok', {duration: 1000})
      });
  }
}
