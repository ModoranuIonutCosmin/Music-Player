import { Component, OnInit } from '@angular/core';
import {MediaService} from "../../../core/services/media/media.service";

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.scss']
})
export class DashboardComponent implements OnInit {

  info: any
  constructor(private ms: MediaService) { }

  ngOnInit(): void {
    // this.ms.getMedia().subscribe(
    //   value => {
    //     console.log(value)
    //     this.info = value
    //   },
    //   error => {
    //     console.log(error)
    //   }
    // )
  }

}
