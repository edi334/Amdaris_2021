import { Component, OnInit } from '@angular/core';
import {Router} from '@angular/router';
import {AuthService} from '../../services/auth.service';

@Component({
  selector: 'app-auth-page',
  templateUrl: './auth-page.component.html',
  styleUrls: ['./auth-page.component.scss'],
})
export class AuthPageComponent  {

  constructor(
    readonly router: Router,
    private readonly _authService: AuthService
  ) {
    if (_authService.isLoggedIn()) {
      router.navigate(['races']).then();
    }
  }
}
