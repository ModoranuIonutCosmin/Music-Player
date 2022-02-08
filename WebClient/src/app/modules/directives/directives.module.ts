import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import {DragAndDropDirective} from "../../core/directives/drag-and-drop.directive";

@NgModule({
  imports: [
    CommonModule
  ],
  declarations: [DragAndDropDirective],
  exports: [DragAndDropDirective],
})
export class DirectivesModule { }
