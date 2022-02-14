import {Component, EventEmitter, Input, OnInit, Output} from '@angular/core';
import {SongInfo} from "../../models/song-info";
import {PlaylistsPopupComponent} from "../../../../shared/components/playlists-popup/playlists-popup.component";
import {MatDialog} from "@angular/material/dialog";
import {MatSnackBar} from "@angular/material/snack-bar";
import {NbGlobalPhysicalPosition} from "@nebular/theme";
import {ToastrHelpersService} from "../../../../core/services/helpers/toastr-helpers.service";

@Component({
  selector: 'app-song-browser',
  templateUrl: './song-browser.component.html',
  styleUrls: ['./song-browser.component.scss']
})

export class SongBrowserComponent {
  displayedColumns: string[] = ['coverImg', 'position', 'name', 'length', 'controls'];
  @Input() dataSource: SongInfo[];
  @Output() songPlayClicked: EventEmitter<SongInfo> = new EventEmitter<SongInfo>();
  highlightedElementIndex: number = -1;


  constructor(public dialog: MatDialog,
              private toastrService: ToastrHelpersService) {
    this.dataSource = []
  }

  openDialog(songId: string) {
    const dialogRef = this.dialog.open(PlaylistsPopupComponent, {
      data: {songId: songId}
    });

    dialogRef.afterClosed().subscribe((result: any) => {
      if (result == 1) {
        this.toastrService.showMessage(NbGlobalPhysicalPosition.BOTTOM_RIGHT, 'success', 'Song was added to playlist succesfully');
      } else {
        this.toastrService.showMessage(NbGlobalPhysicalPosition.BOTTOM_RIGHT, 'danger', 'Couldnt add song to playlist' );
      }
    });
  }

  songPlayed(songInfo: SongInfo) {
    this.songPlayClicked.emit(songInfo);
  }

  addSongToPlaylist(songId: string) {
    this.openDialog(songId);
  }
}
