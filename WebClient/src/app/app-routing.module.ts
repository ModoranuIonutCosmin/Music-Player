import {NgModule} from '@angular/core';
import {RouterModule, Routes} from '@angular/router';
import {AudioService} from "./core/services/music player/audio.service";

const routes: Routes = [
  {
    path: 'auth',
    loadChildren: () => import('./modules/auth/auth.module').then(m => m.AuthModule)
  },
  {
    path: 'dashboard',
    loadChildren: () => import('./modules/dashboard/dashboard.module').then(m => m.DashboardModule)
  },
  {
    path: 'album',
    loadChildren: () => import('./modules/album/album.module').then(m => m.AlbumModule)
  },
  {
    path: 'song',
    loadChildren: () => import('./modules/song/song.module').then(m => m.SongModule)
  },
  {
    path: 'search',
    loadChildren: () => import('./modules/search-results/search-results.module').then(m => m.SearchResultsModule)
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {
}
