import {SongInfo} from "../../modules/album/models/song-info";

export interface MusicActivityModel {
  songId?: string
  albumId?: string,
  playListId?: string,
  isShuffled?: boolean,
  trackPosition?: number,
  songInfo?: SongInfo,
  songsIdsHistory?: Array<string>,
  songsPositionsHistory?: Array<number>,
  previousSongId?: string
}
