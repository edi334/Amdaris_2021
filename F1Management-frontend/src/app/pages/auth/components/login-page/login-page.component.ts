import { Component, OnInit } from '@angular/core';
import {AuthService} from '../../../../services/auth.service';
import {Router} from '@angular/router';
import {ILogin} from '../../../../models/login';

const ID = 'user_id';
const TEAM_ID = 'user_team_id';

@Component({
  selector: 'app-login-page',
  templateUrl: './login-page.component.html',
  styleUrls: ['./login-page.component.scss']
})
export class LoginPageComponent {
  email = '';
  password = '';

  constructor(
    private readonly _authService: AuthService,
     readonly router: Router
  ) { }

  login(): void {
    const loginModel: ILogin = {
      email: this.email,
      password: this.password
    };
    this._authService.login(loginModel).subscribe(res => {
      localStorage.setItem(ID, res.userId);
      localStorage.setItem(TEAM_ID, res.teamId);
      this.router.navigate(['races']).then();
    });
  }
}
