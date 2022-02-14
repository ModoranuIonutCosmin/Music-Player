import {Injectable} from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {Observable} from "rxjs";
import {environment} from "../../../../../environments/environment";
import {AlbumInfo} from "../../../../modules/album/models/album-info";
import {ApiPaths} from "../../../../../environments/apiPaths";
import {map, switchMap} from "rxjs/operators";
import {SongInfo} from "../../../../modules/album/models/song-info";

@Injectable()
export class AlbumService {

  constructor(private httpClient: HttpClient) {

  }

  public getAlbumData(albumId: string): Observable<AlbumInfo> {
    return this.httpClient
      .get<AlbumInfo>(environment.baseUrl + ApiPaths.albumInfoGet + `?albumId=${albumId}`);
  }


  public getSongPositionInAlbum(albumId: string, songId: string): Observable<SongInfo> {
    return this.getAlbumData(albumId)
      .pipe(map((result, index) => {

          let songInfo = result?.songs?.find(song => song.id == songId);

          if (songInfo == undefined) {
            throw new Error('Couldnt find this song');
          }

          return songInfo;
        }
      ));
  }
}
