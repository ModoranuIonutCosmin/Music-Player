import {Component, HostBinding, HostListener, ViewChild} from '@angular/core';
import {NbPosition, NbTrigger} from "@nebular/theme";
import {AuthenticationService} from "./core/authentication/authentication.service";
import {BehaviorSubject} from "rxjs";
import {HeaderService} from "./core/header/header.service";
import {SpinnerService} from "./core/services/helpers/spinner.service";

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {
  title = 'MusicPlayer';

  isLoading$: BehaviorSubject<boolean>;

  constructor(private spinnerService: SpinnerService) {
    this.isLoading$ = spinnerService.isLoading$;
  }
}
