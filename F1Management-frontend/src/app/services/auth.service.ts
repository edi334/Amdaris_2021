import { Injectable } from '@angular/core';
import {environment} from '../../environments/environment';

const ID = 'user_id';
const TEAM_ID = 'user_team_id';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  private _baseUrl = environment.apiUrl + 'auth';

  constructor() { }
}
