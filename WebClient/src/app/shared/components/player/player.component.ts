import {Component, Input, OnInit} from '@angular/core';
import {AudioService} from "../../../core/services/music player/audio.service";
import {MusicActivityService} from "../../../core/services/states/music-activity.service";
import {BehaviorSubject} from "rxjs";
import {MediaService} from "../../../core/services/media/media.service";
import {SongInfo} from "../../../modules/album/models/song-info";
import {DurationFormatterService} from "../../../core/services/helpers/duration-formatter.service";

@Component({
  selector: 'app-player',
  templateUrl: './player.component.html',
  styleUrls: ['./player.component.scss']
})
export class PlayerComponent implements OnInit {

  @Input() paused: boolean = true;
  @Input() shuffled: boolean = false;
  songInfo!: SongInfo;
  albumId: string | undefined;
  playerStatus: BehaviorSubject<string>


  constructor(public audioService: AudioService,
              private musicActivityService: MusicActivityService,
              private mediaService: MediaService,
              private durationFormatter: DurationFormatterService) {

    this.playerStatus = audioService.playerStatus;
    this.playerStatus.subscribe(state => {
      if (state == 'ended') {
        this.paused = true;
      }

      if (state == 'playing') {
        this.paused = false;
      }
    });
    musicActivityService.currentSongData.subscribe(activity => {
      let songId = activity?.songInfo?.id || "";
      // if (this.songInfo?.id == songId) {
      //   return;
      // }
      //TODO: PENDING FINDING BETTER WAY OF HANDLING DOUBLE (TRIPLE, 100) CLICK

      let shouldPlayNow = activity.shouldPlayNow;

      if (activity.songInfo != undefined) {
        this.songInfo = activity.songInfo;
        this.songInfo.formattedLength = durationFormatter.formatLength(this.songInfo.length);
      }

      this.mediaService.getSongUrl(songId || "")
        .subscribe(song => {

          if (shouldPlayNow) {
            console.log("setare url");
            this.audioService.setAudio(song.url);
            this.paused = false;
          } else {
            this.audioService.setUrl(song.url);
          }

        }, (err) => {
          this.audioService.setUrl("");
        });
    })
  }

  ngOnInit(): void {

  }

  playSong() {

    if (!this.paused) {
      this.audioService.pauseAudio();
      this.paused = true;
      return;
    }

    this.paused = !this.paused;
    this.audioService.playAudio();
  }
}
