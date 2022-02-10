import {Injectable} from '@angular/core';
import {AudioService} from "./audio.service";
import {BehaviorSubject, timer} from "rxjs";
import {MusicActivityService} from "../states/music-activity.service";
import {MusicActivityModel} from "../../../shared/models/music-activity-model";
import {MediaService} from "../media/media.service";
import {SongInfo} from "../../../modules/album/models/song-info";

@Injectable()
export class MusicPlayerControllerFacadeService {
  playerStatus: BehaviorSubject<string>;
  latestUserActivity: BehaviorSubject<MusicActivityModel>;

  constructor(private audioService: AudioService,
              private musicActivityService: MusicActivityService,
              private mediaService: MediaService) {
    this.playerStatus = audioService.playerStatus;
    this.latestUserActivity = musicActivityService.latestUserActivity;

    this.playerStatus.subscribe(status => {
      if (status == 'ended') {
        //determina urmatoarea melodie
      }
    })

    //pregateste ultima muzica pusa.
    mediaService.getSongUrl(this.latestUserActivity.value.songInfo?.id || "")
      .subscribe(url => {
        this.audioService.setUrl(url.url);
        this.audioService.seekAudio(this.latestUserActivity.value.trackPosition || 0);
      })

    //Event to keep track of current playing time
    timer(500, 1000).subscribe(
      _ => {
        this.musicActivityService.updateCurrentTimeStamp(this.audioService.audio.currentTime);
      }
    )
  }

  getPlayerStatusStream(): BehaviorSubject<string> {
    return this.playerStatus;
  }

  getUserActivity(): BehaviorSubject<MusicActivityModel> {
    return this.latestUserActivity;
  }

  startPlayingSingularSong(songInfo: SongInfo): void {
    console.log('Avem songInfo: ' + JSON.stringify(songInfo))
    this.mediaService.getSongUrl(songInfo.id || "")
      .subscribe(url => {
        this.musicActivityService.updateCurrentSongActivity('song', songInfo, [songInfo.id || ""],
          [songInfo.position], "", songInfo.id || "");
        this.audioService.setAudio(url.url);
      })
  }

  startPlayingAlbum(albumId: string, songInfo: SongInfo): void {
    this.mediaService.getSongUrl(songInfo?.id || "")
      .subscribe(url => {
        this.musicActivityService.updateCurrentSongActivity('album', songInfo, [songInfo.id || ""],
          [songInfo.position], "", albumId || "");
        this.audioService.setAudio(url.url);
      })
  }

  startPlayingPlaylist(playlistId: string, songInfo: SongInfo): void {
    this.mediaService.getSongUrl(songInfo?.id || "")
      .subscribe(url => {
        this.musicActivityService.updateCurrentSongActivity('playlist', songInfo, [songInfo.id || ""],
          [songInfo.position], "", playlistId || "");
        this.audioService.setAudio(url.url);
      })
  }

  pauseCurrentSong(): void {
    this.audioService.pauseAudio()
  }

  resumeCurrentSong(): void {
    this.audioService.playAudio()
  }

  seekToPercentage(position: number): void {
    this.audioService.seekAudio(position);
  }

  seekSkipMiliseconds(msecAmount: number, forwards: boolean): void {
    let secondsAddedQuanity = msecAmount / 1000 * (forwards ? 1 : -1);
    let currentProgress = this.audioService.audio.currentTime;

    if (currentProgress - secondsAddedQuanity < 0) {
      this.audioService.seekAudio(0);
      return;
    }

    this.audioService.seekAudio(currentProgress + secondsAddedQuanity);
  }



  playSongFromTheBeginningOrThePreviousSong(): void {
    let activity = this.latestUserActivity.value;

    if (activity.trackPosition != undefined && activity.trackPosition <= 500) {
      //Pune melodia de canta inainte (daca exista).
      if (!activity.previousSongId) {
        // this.son
      }

    } else {
      //Pune melodia curenta de la inceput.
      this.audioService.seekAudio(0)
    }
  }

  playNextSong(): void {

  }
}
