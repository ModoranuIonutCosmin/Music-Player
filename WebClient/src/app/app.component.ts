import {Component} from '@angular/core';
import {NbPosition, NbTrigger} from "@nebular/theme";
import {AuthenticationService} from "./core/authentication/authentication.service";
import {BehaviorSubject} from "rxjs";

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {
  title = 'MusicPlayer';

  //header stuff
  exploreItems = [{title: 'Latest albums'}, {title: 'Popular'}];
  libraryItems = [{title: 'Favorite songs'}, {title: 'My playlists'}];
  usersControlsItems = [ {title: 'Playlists'},{title: 'Profile'}, {title: 'Log out'} ];

  contextMenuOpenDirection: NbPosition = NbPosition.BOTTOM;
  contextMenuOpenTrigger: NbTrigger = NbTrigger.HOVER;

  currentUser$: BehaviorSubject<string>;

  constructor(private authenticationService: AuthenticationService) {
    this.currentUser$ = this.authenticationService.user;
  }
}
