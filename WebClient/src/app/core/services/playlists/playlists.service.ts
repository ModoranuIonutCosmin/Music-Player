import {Injectable} from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {PlaylistsResponseDTO} from "../../../modules/playlist/models/playlists-response-dto";
import {Observable} from "rxjs";
import {environment} from "../../../../environments/environment";
import {PlaylistInfo} from "../../../modules/playlist/models/playlist-info";
import {ApiPaths} from "../../../../environments/apiPaths";

@Injectable()
export class PlaylistsService {

  constructor(private httpClient: HttpClient) {

  }

  loadSpecificPlaylist(playlistId: string): Observable<PlaylistInfo> {
    return this.httpClient.get<PlaylistInfo>(environment.baseUrl + ApiPaths.playlistByIdGet + `?playlistId=${playlistId}`);
  }

  loadMyPlaylists(): Observable<PlaylistsResponseDTO> {
    return this.httpClient.get<PlaylistsResponseDTO>(environment.baseUrl + ApiPaths.myPlaylistsGet);
  }

  createNewPlaylist(name: string, visibility = 0): Observable<PlaylistInfo> {
    return this.httpClient.post<PlaylistInfo>(environment.baseUrl + ApiPaths.createPlaylistPost, {
      name: name,
      visibility: visibility
    })
  }

  addSongToPlaylist(playlistId: string, songId: string): Observable<PlaylistInfo> {
    console.log(playlistId);
    return this.httpClient.patch<PlaylistInfo>(environment.baseUrl + ApiPaths.addSongPatch, {
      songId: songId,
      playlistId: playlistId
    });
  }

  deleteSongFromPlaylist(playlistId: string, songId: string): Observable<PlaylistInfo> {
    return this.httpClient.delete<PlaylistInfo>(environment.baseUrl + ApiPaths.deleteSong, {
      body: {
        songId: songId,
        playlistId: playlistId
      }
    });
  }

}
