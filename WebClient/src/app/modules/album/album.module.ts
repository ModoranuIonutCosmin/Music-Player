import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { AlbumRoutingModule } from './album-routing.module';
import { SongBrowserComponent } from './components/song-browser/song-browser.component';
import {MaterialModule} from "../material/material.module";
import { AlbumExplorerComponent } from './pages/album-explorer/album-explorer.component';
import { AlbumInfoPanelComponent } from './components/album-info-panel/album-info-panel.component';
import {AlbumService} from "../../core/services/media/album/album.service";


@NgModule({
    declarations: [
        SongBrowserComponent,
        AlbumExplorerComponent,
        AlbumInfoPanelComponent
    ],
    imports: [
        CommonModule,
        AlbumRoutingModule,
        MaterialModule
    ],
    exports: [
        SongBrowserComponent
    ],
    providers: [AlbumService]
})
export class AlbumModule { }
