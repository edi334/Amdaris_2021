import {Component, OnInit} from '@angular/core';
import {TeamService} from '../../services/team.service';
import {IDriver} from '../../models/team-members/driver';
import {ITeam} from '../../models/team';

@Component({
  selector: 'app-standings-page',
  templateUrl: './standings-page.component.html',
  styleUrls: ['./standings-page.component.scss']
})
export class StandingsPageComponent implements OnInit {
  drivers: IDriver[];
  teams: ITeam[];
  options = ['Driver\'s Championship', 'Constructor\'s Championship'];
  selectedOption = 'Driver\'s Championship';

  constructor(
    private readonly _teamService: TeamService
  ) {
  }

  ngOnInit(): void {
    this._teamService.getAll().subscribe(res => {
      this.teams = res;
    });
    this._teamService.getAllDrivers().subscribe(res => {
      this.drivers = res;
    });
  }
}
