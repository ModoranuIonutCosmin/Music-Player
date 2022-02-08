import {Component, EventEmitter, Input, OnInit, Output} from '@angular/core';
import {SongInfo} from "../../models/song-info";
import {PlaylistsPopupComponent} from "../../../../shared/components/playlists-popup/playlists-popup.component";
import {MatDialog} from "@angular/material/dialog";
import {MatSnackBar} from "@angular/material/snack-bar";

@Component({
  selector: 'app-song-browser',
  templateUrl: './song-browser.component.html',
  styleUrls: ['./song-browser.component.scss']
})

export class SongBrowserComponent implements OnInit {
  displayedColumns: string[] = ['position', 'coverImg', 'name', 'length', 'controls'];
  @Input() dataSource: SongInfo[];
  @Output() songPlayClicked: EventEmitter<SongInfo> = new EventEmitter<SongInfo>();
  highlightedElementIndex: number = -1;


  openDialog(songId: string,) {
    const dialogRef = this.dialog.open(PlaylistsPopupComponent, {
      data: {songId: songId}
    });

    dialogRef.afterClosed().subscribe((result: any) => {
      if (result == 1) {
        this.snackBar.open("Song added to playlist");
      } else {
        this.snackBar.open("Couldn't add song to playlist");
      }
    });
  }


  constructor(public dialog: MatDialog,
              public snackBar: MatSnackBar) {
    this.dataSource = []
  }

  ngOnInit(): void {

  }

  songPlayed(songInfo: SongInfo) {
    this.songPlayClicked.emit(songInfo);
  }

  addSongToPlaylist(songId: string) {
    this.openDialog(songId);
  }
}
