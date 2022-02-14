import {Component, HostListener, OnInit, ViewChild} from '@angular/core';
import {NbMenuService, NbPosition, NbTrigger} from "@nebular/theme";
import {BehaviorSubject} from "rxjs";
import {AuthenticationService} from "../../../core/authentication/authentication.service";
import {filter, map} from "rxjs/operators";
import {PlayerComponent} from "../player/player.component";
import {HeaderService} from "../../../core/header/header.service";
import {animate, style, transition, trigger} from "@angular/animations";

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.scss'],
  animations: [
    trigger('slideInOut', [
      transition(':enter', [
        style({transform: 'translateX(-100%)'}),
        animate('200ms ease-in', style({transform: 'translateX(0%)'}))
      ]),
      transition(':leave', [
        animate('200ms ease-in', style({transform: 'translateX(-100%)'}))
      ])
    ])
  ]
})
export class HeaderComponent implements OnInit{


  //header stuff
  exploreItems = [{title: 'Latest albums'}, {title: 'Popular'}];
  libraryItems = [{title: 'Favorite songs'}, {title: 'My playlists'}];
  usersControlsItems = [ {title: 'Playlists'},{title: 'Profile'}, {title: 'Log out'} ];

  contextMenuOpenDirection: NbPosition = NbPosition.BOTTOM;
  contextMenuOpenTrigger: NbTrigger = NbTrigger.HOVER;

  @HostListener('window:resize', ['$event'])
  onResize(event: any) {
    this.tablet = event.target.innerWidth < 1200;

  }
  overlayOpen: boolean = false;
  tablet: boolean= false;

  currentUser$: BehaviorSubject<string>;

  constructor(private authenticationService: AuthenticationService,
              private nbMenuService: NbMenuService) {
    this.currentUser$ = this.authenticationService.user;
  }

  ngOnInit(): void {
    this.nbMenuService.onItemClick()
      .pipe(
        filter(({ tag }) => tag === 'user-profile-menu'),
        map(({ item: { title } }) => title),
      )
      .subscribe(title => {
        if (this.usersControlsItems[2].title === title) {
          this.authenticationService.logout();
        }
      });
  }


  closeOverlay(): void {
    this.overlayOpen = false;
  }
  toggleOverlay(): void{
    this.overlayOpen = ! this.overlayOpen;
  }

}
