import {NgModule} from '@angular/core';
import {CommonModule} from '@angular/common';
import {LengthFormatPipe} from "./pipes/length-format.pipe";
import {PlayerComponent} from "./components/player/player.component";
import {SearchbarComponent} from "./components/searchbar/searchbar.component";
import {HeaderComponent} from "./components/header/header.component";
import {
  NbButtonModule,
  NbContextMenuModule,
  NbIconModule, NbInputModule,
  NbLayoutModule, NbMenuModule, NbProgressBarModule,
  NbSearchModule,
  NbSidebarModule,
  NbThemeModule, NbToastrModule, NbToastrService, NbUserModule
} from "@nebular/theme";
import {NbEvaIconsModule} from "@nebular/eva-icons";
import {RouterModule} from "@angular/router";
import {FormsModule, ReactiveFormsModule} from "@angular/forms";
import {PlaylistsPopupComponent} from "./components/playlists-popup/playlists-popup.component";
import {MatDialogModule} from "@angular/material/dialog";
import {AuthenticationService} from "../core/authentication/authentication.service";
import {AudioService} from "../core/services/music player/audio.service";
import {SearchService} from "../core/services/search/search.service";
import {MusicActivityService} from "../core/services/states/music-activity.service";
import {MediaService} from "../core/services/media/media.service";
import {MusicPlayerControllerFacadeService} from "../core/services/music player/music-player-controller-facade.service";
import {HeaderService} from "../core/header/header.service";
import {NextSongService} from "../core/services/music player/next-song.service";
import {AlbumService} from "../core/services/media/album/album.service";
import {PlaylistsService} from "../core/services/playlists/playlists.service";
import {SongService} from "../core/services/media/songs/song.service";


@NgModule({
  declarations: [
    LengthFormatPipe,
    PlayerComponent,
    SearchbarComponent,
    PlaylistsPopupComponent,
    HeaderComponent],
  imports: [
    CommonModule,
    NbSidebarModule.forRoot(),
    NbLayoutModule,
    NbEvaIconsModule,
    NbIconModule,
    NbSidebarModule,
    NbSearchModule,

    NbContextMenuModule,
    NbMenuModule.forRoot(),
    NbInputModule,
    NbButtonModule,
    NbProgressBarModule,
    NbUserModule,
    NbToastrModule,
    NbToastrModule.forRoot(),

    RouterModule,
    FormsModule,
    ReactiveFormsModule,
    MatDialogModule
  ],
  exports: [
    LengthFormatPipe,
    PlayerComponent,
    SearchbarComponent,
    PlaylistsPopupComponent,
    HeaderComponent
  ],
  providers: [

    PlaylistsService,
    AlbumService,
    SearchService,
    SongService,
    NbToastrService
  ]
})
export class SharedModule {
}
