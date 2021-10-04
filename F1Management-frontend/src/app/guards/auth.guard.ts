import {Injectable} from '@angular/core';
import {CanActivate, Router} from '@angular/router';
import {AuthService} from '../services/auth.service';

@Injectable({
  providedIn: 'root'
})
export class AuthGuard implements CanActivate {
  constructor(
    private readonly _authService: AuthService,
    private readonly _router: Router
  ) {
  }

  canActivate(): boolean {
    if (!this._authService.isLoggedIn()) {
      this._router.navigate(['auth']).then();
      return false;
    }

    return true;
  }
}
