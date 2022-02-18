import { Component, OnInit } from '@angular/core';
import {ActivatedRoute} from "@angular/router";
import {MusicActivityService} from "../../../../core/services/states/music-activity.service";
import {DurationFormatterService} from "../../../../core/services/helpers/duration-formatter.service";
import {mergeMap} from "rxjs/operators";
import {SongService} from "../../../../core/services/media/songs/song.service";
import {SongInfo} from "../../../album/models/song-info";
import {AudioService} from "../../../../core/services/music player/audio.service";
import {
  MusicPlayerControllerFacadeService
} from "../../../../core/services/music player/music-player-controller-facade.service";

@Component({
  selector: 'app-song-page',
  templateUrl: './song-page.component.html',
  styleUrls: ['./song-page.component.scss']
})
export class SongPageComponent implements OnInit {

  public dataSource!: SongInfo;
  public songId!: string;

  constructor(private route: ActivatedRoute,
              private songService: SongService,
              private playerService: MusicPlayerControllerFacadeService
  ) {}

  ngOnInit(): void {
    this.route.params.pipe(mergeMap((v, index) => {
      this.songId = v['songId'];
      return this.songService.getSongDetails(v['songId']);
    })).subscribe((value : SongInfo) => {
      this.dataSource = value;
      console.log(value);
    });
  }

  playSong() {
    this.playerService.startPlayingSingularSong(this.dataSource);
  }

  openOptions() {

  }
}
