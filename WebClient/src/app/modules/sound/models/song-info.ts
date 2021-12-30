import {ArtistInfo} from "./artist-info";

export interface SongInfo {
  id?: string,
  position: number,
  coverImgUrl: string,
  name: string,
  length: number
  artists?: ArtistInfo[]
}
