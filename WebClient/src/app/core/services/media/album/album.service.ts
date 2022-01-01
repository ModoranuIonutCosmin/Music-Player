import { Injectable } from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {Observable} from "rxjs";
import {ApiPaths, environment} from "../../../../../environments/environment";
import {AlbumInfo} from "../../../../modules/album/models/album-info";

@Injectable()
export class AlbumService {

  constructor(private httpClient: HttpClient) {

  }

  public getAlbumData(albumId: string) : Observable<AlbumInfo> {
      return this.httpClient
        .get<AlbumInfo>(environment.baseUrl + ApiPaths.albumInfoGet + `?albumId=${albumId}`);
  }
}
