import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { SongRoutingModule } from './song-routing.module';
import { SongWholePagePanelComponent } from './components/song-whole-page-panel/song-whole-page-panel.component';
import { SongPageComponent } from './pages/song-page/song-page.component';
import {MaterialModule} from "../material/material.module";
import {SongService} from "../../core/services/media/songs/song.service";


@NgModule({
  declarations: [
    SongWholePagePanelComponent,
    SongPageComponent
  ],
  imports: [
    CommonModule,
    SongRoutingModule,
    MaterialModule
  ],
  providers: [SongService]

})
export class SongModule { }
