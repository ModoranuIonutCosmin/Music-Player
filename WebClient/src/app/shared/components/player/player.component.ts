import {Component, Input, OnInit} from '@angular/core';
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

  @Input() paused: boolean = true;
  @Input() shuffled: boolean = false;
  songInfo: SongInfo;
  trackPosition: string;
  albumId: string | undefined;
  playerStatus: BehaviorSubject<string>
  userActivity: BehaviorSubject<MusicActivityModel>


  constructor(public playerService: MusicPlayerControllerFacadeService,
              public durationFormatter: DurationFormatterService) {
    this.playerStatus = playerService.getPlayerStatusStream();
    this.userActivity = playerService.getUserActivity();

    this.trackPosition= "0:00";
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
        console.log(this.songInfo);
    })

    timer(0, 500)
      .subscribe(_ => {
        this.trackPosition = this.durationFormatter.formatLength((this.userActivity.value.trackPosition || 0) * 10000000 );
      })
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
