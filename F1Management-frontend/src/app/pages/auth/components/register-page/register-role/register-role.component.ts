import {Component, Input, OnInit} from '@angular/core';
import {IUser} from '../../../../../models/user';

@Component({
  selector: 'app-register-role',
  templateUrl: './register-role.component.html',
  styleUrls: ['./register-role.component.scss']
})
export class RegisterRoleComponent {
  @Input() user: IUser;
}
