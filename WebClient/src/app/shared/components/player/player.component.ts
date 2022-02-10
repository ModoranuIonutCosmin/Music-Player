import {Component, HostListener, Input, OnInit} from '@angular/core';
import {BehaviorSubject, timer} from "rxjs";
import {SongInfo} from "../../../modules/album/models/song-info";
import {
  MusicPlayerControllerFacadeService
} from "../../../core/services/music player/music-player-controller-facade.service";
import {MusicActivityModel} from "../../models/music-activity-model";
import {DurationFormatterService} from "../../../core/services/helpers/duration-formatter.service";

@Component({
  selector: 'app-player',
  templateUrl: './player.component.html',
  styleUrls: ['./player.component.scss']
})
export class PlayerComponent implements OnInit {

  ARROW_SKIP_MSEC: number = 5000;

  @Input() paused: boolean = true;
  @Input() shuffled: boolean = false;
  songInfo: SongInfo;

  trackPosition: string;
  totalTrackTime: string;
  trackPositionMsec: number = 0;
  totalTrackTimeMsec: number = 0;

  albumId: string | undefined;
  playerStatus: BehaviorSubject<string>
  userActivity: BehaviorSubject<MusicActivityModel>

  // @HostListener('document:keyup', ['$event'])
  // handleNonHoldingKeyPresses(event: KeyboardEvent) {
  //   if (event.key == ' ') {
  //     console.log(event.target);
  //     this.playSong();
  //   }
  // }
  // @HostListener('document:keydown', ['$event'])
  // handleKeyboardEvent(event: KeyboardEvent) {
  //   if (event.key == 'ArrowLeft') {
  //     this.playerService.seekSkipMiliseconds(this.ARROW_SKIP_MSEC, false);
  //   }
  //
  //   if (event.key == 'ArrowRight') {
  //     this.playerService.seekSkipMiliseconds(this.ARROW_SKIP_MSEC, true);
  //   }
  // }

  constructor(public playerService: MusicPlayerControllerFacadeService,
              public durationFormatter: DurationFormatterService) {
    this.playerStatus = playerService.getPlayerStatusStream();
    this.userActivity = playerService.getUserActivity();

    this.trackPosition= "0:00";
    this.totalTrackTime = "0:00";
    this.songInfo = {
      position: 0,
      coverImageUrl: "",
      length: 0,
      name: ""
    };
  }

  ngOnInit(): void {
    this.playerStatus.subscribe(status => {
      if (status == "ended" || status == "pause" || status == "waiting") {
        this.paused = true;
      } else if (status == "playing") {
        this.paused = false;
      }
    });
    this.userActivity.subscribe(activity => {
        this.songInfo = activity.songInfo || this.songInfo;
        this.shuffled = activity.isShuffled || false;
        this.totalTrackTime = this.durationFormatter.formatLength((activity.songInfo?.length   || 0));
        this.totalTrackTimeMsec = (activity.songInfo?.length   || 0) / 10000;
        console.log(this.songInfo);
    })

    timer(0, 500)
      .subscribe(_ => {
        this.trackPositionMsec = (this.userActivity.value.trackPosition || 0) * 1000;
        this.songInfo = (this.userActivity.value.songInfo) || this.songInfo;
        this.trackPosition = this.durationFormatter.formatLength(this.trackPositionMsec * 10000 );
      })
  }

  progressPercent(): number {
    return (this.trackPositionMsec / (this.totalTrackTimeMsec + 0.00001)) * 100;
  }

  seek(event: any): void {
    let progressBarRect: any = event.target.getBoundingClientRect();

    let clickX = event.clientX;
    let progressBarWidth = progressBarRect.right - progressBarRect.left;
    let clickDistance = clickX - progressBarRect.left;

    let percentSeek = clickDistance / (progressBarWidth + 0.0001);
    this.playerService.seekToPercentage((this.totalTrackTimeMsec / 1000) * percentSeek);
  }

  playSong() {

    if (!this.paused) {
      this.playerService.pauseCurrentSong();
      this.paused = !this.paused;
      console.log('Punem melodie pe pause!');
      return;
    }

    console.log('Punem melodie sa cante!');
    this.paused = !this.paused;
    this.playerService.resumeCurrentSong();
  }
}
