import { Component, OnInit } from '@angular/core';
import {GrandPrixService} from '../../services/grand-prix.service';
import {IGrandPrix} from '../../models/grand-prix';

@Component({
  selector: 'app-races-page',
  templateUrl: './races-page.component.html',
  styleUrls: ['./races-page.component.scss']
})
export class RacesPageComponent implements OnInit {
  grandPrix: IGrandPrix[];

  constructor(
    private readonly _grandPrixService: GrandPrixService
  ) { }

  ngOnInit(): void {
    this._grandPrixService.getAll().subscribe(grandPrix => {
      this.grandPrix = grandPrix;
    });
  }

}
