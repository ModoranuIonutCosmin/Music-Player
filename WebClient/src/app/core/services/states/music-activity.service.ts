import { Injectable } from '@angular/core';
import {BehaviorSubject} from "rxjs";
import {MusicActivityModel} from "../../../shared/models/music-activity-model";
import {SongInfo} from "../../../modules/album/models/song-info";

@Injectable()
export class MusicActivityService {

  public lastActivityKey : string = "last_song_activity";
  public currentSongData = new BehaviorSubject<MusicActivityModel>({shouldPlayNow: false});


  constructor() {
    this.loadLastActivity();
  }

  public loadLastActivity() : void {
    let lastActivity = localStorage.getItem(this.lastActivityKey);

    var result = JSON.parse(lastActivity || "{shouldPlayNow: false}");

    result.shouldPlayNow = false;

    this.currentSongData.next(<MusicActivityModel> result);
  }


  public storeLastActivity(type: string, id: string, seekPos: number, songInfo: SongInfo,
                           playNow: boolean) : void {
      this.currentSongData.next(<MusicActivityModel>{
        songInfo: songInfo,
        songId: type == "song" ? id : undefined,
        playlistId: type == "playList" ? id : undefined,
        albumId: type == "album" ? id : undefined,
        shouldPlayNow: playNow,
        trackPosition: seekPos,
      });

      localStorage.setItem(this.lastActivityKey, JSON.stringify(this.currentSongData.value));
  }
}
