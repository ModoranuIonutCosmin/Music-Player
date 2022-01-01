import { Injectable } from '@angular/core';
import {Observable} from "rxjs";
import {ApiPaths, environment} from "../../../../environments/environment";
import {HttpClient} from "@angular/common/http";
import {ResourceUrlResponse} from "../../../shared/models/resource-url-response";

@Injectable()
export class MediaService {

  constructor(private httpClient: HttpClient) { }

  public getSongUrl(songId: string): Observable<ResourceUrlResponse> {
    return this.httpClient
      .get<ResourceUrlResponse>(environment.baseUrl + ApiPaths.mediaService + `?songId=${songId}`)
  }
}
