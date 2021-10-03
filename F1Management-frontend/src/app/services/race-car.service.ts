import { Injectable } from '@angular/core';
import {environment} from '../../environments/environment';
import {HttpClient} from '@angular/common/http';
import {Observable} from 'rxjs';
import {ITeam} from '../models/team';
import {IRaceCar} from '../models/race-car-models/race-car';

@Injectable({
  providedIn: 'root'
})
export class RaceCarService {
  private _baseUrl = environment.apiUrl + 'race-car';

  constructor(
    private readonly _http: HttpClient
  ) { }

  getByTeamId(teamId: string): Observable<IRaceCar[]> {
    const url = this._baseUrl + `/team/${teamId}`;

    return this._http.get<IRaceCar[]>(url);
  }
}
