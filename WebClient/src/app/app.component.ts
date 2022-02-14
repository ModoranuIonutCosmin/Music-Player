import {Component, HostBinding, HostListener, ViewChild} from '@angular/core';
import {NbPosition, NbTrigger} from "@nebular/theme";
import {AuthenticationService} from "./core/authentication/authentication.service";
import {BehaviorSubject} from "rxjs";
import {HeaderService} from "./core/header/header.service";

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {
  title = 'MusicPlayer';

  constructor() {

  }
}
