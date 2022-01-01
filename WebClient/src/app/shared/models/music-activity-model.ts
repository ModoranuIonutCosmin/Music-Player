import {SongInfo} from "../../modules/album/models/song-info";

export interface MusicActivityModel {
  songId?: string,
  albumId?: string,
  playlistId?: string,
  trackPosition?: number,
  shouldPlayNow: boolean,
  songInfo?: SongInfo
}
