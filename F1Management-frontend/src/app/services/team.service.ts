import { Injectable } from '@angular/core';
import {HttpClient} from '@angular/common/http';
import {environment} from '../../environments/environment';
import {Observable} from 'rxjs';
import {ITeam} from '../models/team';
import {IDriver} from '../models/team-members/driver';

@Injectable({
  providedIn: 'root'
})
export class TeamService {
  private _baseUrl = environment.apiUrl + 'team';

  constructor(
    private readonly _http: HttpClient
  ) { }

  getAll(): Observable<ITeam[]> {
    return this._http.get<ITeam[]>(this._baseUrl);
  }

  getDrivers(teamId: string): Observable<IDriver[]> {
    const url = this._baseUrl + `/${teamId}/drivers`;

    return this._http.get<IDriver[]>(url);
  }
}
