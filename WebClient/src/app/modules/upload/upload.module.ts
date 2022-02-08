import {NgModule} from '@angular/core';
import { CommonModule } from '@angular/common';

import { UploadRoutingModule } from './upload-routing.module';
import { AlbumUploadComponent } from './pages/album-upload/album-upload.component';
import {DirectivesModule} from "../directives/directives.module";
import {FormsModule, ReactiveFormsModule} from "@angular/forms";
import {MaterialModule} from "../material/material.module";
import {UploadService} from "../../core/services/upload/upload.service";


@NgModule({
  declarations: [
    AlbumUploadComponent
  ],
  imports: [
    CommonModule,
    UploadRoutingModule,
    DirectivesModule,
    FormsModule,
    ReactiveFormsModule,
    MaterialModule
  ],
  providers: [UploadService]
})
export class UploadModule { }
