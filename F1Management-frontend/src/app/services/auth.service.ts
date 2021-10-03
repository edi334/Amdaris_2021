import { Injectable } from '@angular/core';
import {environment} from '../../environments/environment';
import {Observable} from 'rxjs';
import {HttpClient} from '@angular/common/http';

const ID = 'user_id';
const TEAM_ID = 'user_team_id';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  private _baseUrl = environment.apiUrl + 'auth/';

  constructor(
    private readonly _http: HttpClient
  ) { }

  registerTeam(teamName: string): Observable<string> {
    const url = this._baseUrl + `register-team?name=${teamName}`;

    return this._http.post(url, teamName, {responseType: 'text'});
  }
}
