import { Injectable } from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {AlbumInfo} from "../../../../modules/sound/models/album-info";
import {Observable} from "rxjs";
import {ApiPaths, environment} from "../../../../../environments/environment";

@Injectable()
export class AlbumService {

  constructor(private httpClient: HttpClient) {

  }

  public getAlbumData(albumId: string) : Observable<AlbumInfo> {
      return this.httpClient
        .get<AlbumInfo>(environment.baseUrl + ApiPaths.albumInfoGet + `?albumId=${albumId}`);
  }
}
