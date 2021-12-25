import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { DashboardRoutingModule } from './dashboard-routing.module';
import { DashboardComponent } from './components/dashboard.component';
import {MediaService} from "../../core/services/media/media.service";
import { PlayerComponent } from './components/player/player.component';
import {MaterialModule} from "../material/material.module";


@NgModule({
  declarations: [
    DashboardComponent,
    PlayerComponent
  ],
  imports: [
    CommonModule,
    DashboardRoutingModule,
    MaterialModule
  ],
  providers:
    [MediaService]
})
export class DashboardModule { }
