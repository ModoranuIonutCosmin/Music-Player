import {NgModule} from '@angular/core';
import {BrowserModule} from '@angular/platform-browser';

import {AppRoutingModule} from './app-routing.module';
import {AppComponent} from './app.component';
import {HTTP_INTERCEPTORS, HttpClientModule} from "@angular/common/http";
import {AuthInterceptor} from "./core/interceptors/auth.interceptor";
import {BrowserAnimationsModule} from '@angular/platform-browser/animations';
import {UnauthorizedInterceptor} from "./core/interceptors/unauthorized.interceptor";
import {AuthenticationService} from "./core/authentication/authentication.service";
import {LayoutModule} from '@angular/cdk/layout';
import {MatToolbarModule} from '@angular/material/toolbar';
import {MatButtonModule} from '@angular/material/button';
import {MatSidenavModule} from '@angular/material/sidenav';
import {MatIconModule} from '@angular/material/icon';
import {MatListModule} from '@angular/material/list';
import {PlayerComponent} from "./shared/components/player/player.component";
import {AudioService} from "./core/services/music player/audio.service";
import {MediaService} from "./core/services/media/media.service";
import {MusicActivityService} from "./core/services/states/music-activity.service";
import {MaterialModule} from "./modules/material/material.module";
import {FormsModule} from "@angular/forms";
import {SearchbarComponent} from './shared/components/searchbar/searchbar.component';
import {MusicPlayerControllerFacadeService} from "./core/services/music player/music-player-controller-facade.service";
import {PlaylistsPopupComponent} from './shared/components/playlists-popup/playlists-popup.component';
import {PlaylistsService} from "./core/services/playlists/playlists.service";
import {
    NbThemeModule,
    NbLayoutModule,
    NbSidebarModule,
    NbSearchModule,
    NbIconModule,
    NbContextMenuModule, NbMenuModule, NbInputModule, NbButtonModule, NbProgressBarModule, NbUserModule, NbSpinnerModule
} from '@nebular/theme';
import {NbEvaIconsModule} from '@nebular/eva-icons';
import {SearchService} from "./core/services/search/search.service";
import {HeaderService} from "./core/header/header.service";
import {NextSongService} from "./core/services/music player/next-song.service";
import {AlbumService} from "./core/services/media/album/album.service";
import {SharedModule} from "./shared/shared.module";
import {SpinnerService} from "./core/services/helpers/spinner.service";
import { ImageFallbackDirective } from './core/directives/image-fallback.directive';

@NgModule({
  declarations: [
    AppComponent,
  ],
    imports: [
        BrowserModule,
        AppRoutingModule,
        HttpClientModule,
        BrowserAnimationsModule,
        LayoutModule,
        MatToolbarModule,
        MatButtonModule,
        MatSidenavModule,
        MatIconModule,
        MatListModule,
        MaterialModule,
        FormsModule,

        NbThemeModule.forRoot({name: 'dark'}),
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
        SharedModule,
        NbSpinnerModule
    ],
  providers: [{
    provide: HTTP_INTERCEPTORS,
    useClass: AuthInterceptor,
    multi: true
  },
    {
      provide: HTTP_INTERCEPTORS,
      useClass: UnauthorizedInterceptor,
      multi: true
    },
    AuthenticationService,
    MusicPlayerControllerFacadeService,
    AudioService,
    MusicActivityService,
    MediaService,
    NextSongService,
    SpinnerService
  ],
  bootstrap: [AppComponent],
})
export class AppModule {
}
