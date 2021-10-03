import { Component, OnInit } from '@angular/core';
import {IUser} from '../../../../models/user';

@Component({
  selector: 'app-register-page',
  templateUrl: './register-page.component.html',
  styleUrls: ['./register-page.component.scss']
})
export class RegisterPageComponent {
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
}
