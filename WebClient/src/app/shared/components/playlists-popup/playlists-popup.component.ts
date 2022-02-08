import {Component, Inject, Input, OnInit, Optional} from '@angular/core';
import {PlaylistsResponseDTO} from "../../../modules/playlist/models/playlists-response-dto";
import {PlaylistsService} from "../../../core/services/playlists/playlists.service";
import {MAT_DIALOG_DATA, MatDialogRef} from "@angular/material/dialog";

@Component({
  selector: 'app-playlists-popup',
  templateUrl: './playlists-popup.component.html',
  styleUrls: ['./playlists-popup.component.scss']
})
export class PlaylistsPopupComponent implements OnInit {
  @Input() dataSource: PlaylistsResponseDTO = {playlists: []};
  readOnly: boolean = true;
  enteredName: string = "Add a new playlist.";
  songId: string = "";

  constructor(private playlistService: PlaylistsService,
              @Optional() @Inject(MAT_DIALOG_DATA) public data: any,
              private dialogRef: MatDialogRef<PlaylistsPopupComponent>) {
    this.songId = data.songId;
  }

  ngOnInit(): void {
    this.playlistService.loadMyPlaylists().subscribe(result => {
      this.dataSource = result;
    })
  }

  addNewPlaylist() {
    this.readOnly = false;
  }

  resetFromEdit() {
    this.enteredName = "Add a new playlist.";
  }

  finishEditing() {
    this.playlistService.createNewPlaylist(this.enteredName, 0)
      .subscribe(result => {
        result.name = this.enteredName;
        this.dataSource.playlists.push(result);
        this.resetFromEdit();
      })
  }

  addSongToPlaylist(playlistId: string) {
    this.playlistService.addSongToPlaylist(playlistId, this.songId)
      .subscribe(result => {
        this.dialogRef.close(1)
      },
      error => {
        this.dialogRef.close(0);
      })
  }
}
