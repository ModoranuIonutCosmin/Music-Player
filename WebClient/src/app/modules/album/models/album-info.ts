import {ArtistInfo} from "./artist-info";
import {SongInfo} from "./song-info";

export interface AlbumInfo {
  id?: string,
  name: string,
  coverImageUrl: string,
  description: string,
  releaseDate: Date,
  artists? : ArtistInfo[]
  songs? : SongInfo[]
}
