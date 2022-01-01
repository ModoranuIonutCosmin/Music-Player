import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import {SongWholePagePanelComponent} from "./components/song-whole-page-panel/song-whole-page-panel.component";
import {SongPageComponent} from "./pages/song-page/song-page.component";

const routes: Routes = [{
  path: ':songId', component: SongPageComponent
}];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class SongRoutingModule { }
