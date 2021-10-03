import { Component, OnInit } from '@angular/core';
import {IUser} from '../../../../models/user';
import {TeamService} from '../../../../services/team.service';
import {ITeam} from '../../../../models/team';
import {Router} from '@angular/router';

@Component({
  selector: 'app-register-page',
  templateUrl: './register-page.component.html',
  styleUrls: ['./register-page.component.scss']
})
export class RegisterPageComponent implements OnInit {
  user: IUser = {
    firstName: '',
    lastName: '',
    email: '',
    phoneNumber: '',
    password: '',
    userTeamRole: ''
  };
  roles = [
    'Driver',
    'CarMechanic',
    'PitStopMechanic',
    'RaceEngineer'
  ];
  teams: ITeam[];
  teamId: string;

  constructor(
    private readonly _teamService: TeamService,
    readonly router: Router
  ) {
  }

  ngOnInit(): void {
    this._teamService.getAll().subscribe(res => {
      this.teams = res;
    });
  }


}
