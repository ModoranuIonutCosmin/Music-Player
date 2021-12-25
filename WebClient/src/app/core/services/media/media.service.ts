import { Injectable } from '@angular/core';
import {Observable} from "rxjs";
import {LoginResponse} from "../../authentication/models/login-response";
import {LoginRequest} from "../../authentication/models/login-request";
import {ApiPaths, environment} from "../../../../environments/environment";
import {shareReplay, tap} from "rxjs/operators";
import {HttpClient} from "@angular/common/http";

@Injectable()
export class MediaService {

  constructor(private httpClient: HttpClient) { }

  public getMedia(): Observable<any> {
    return this.httpClient
      .get(environment.baseUrl + ApiPaths.mediaService)
      .pipe(
        shareReplay());
  }
}
