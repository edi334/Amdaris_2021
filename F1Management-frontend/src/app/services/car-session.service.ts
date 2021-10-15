import {Injectable} from '@angular/core';
import {HttpClient} from '@angular/common/http';
import {environment} from '../../environments/environment';
import {Observable} from 'rxjs';
import {ICarSession} from '../models/car-session';

@Injectable({
  providedIn: 'root'
})
export class CarSessionService {
  private _baseUrl = environment.apiUrl + 'car-session';

  constructor(
    private readonly http: HttpClient
  ) {
  }

  getByTeamAndRace(raceCarId: string, grandPrixId: string): Observable<ICarSession[]> {
    const url = this._baseUrl + `?raceCarId=${raceCarId}&grandPrixId=${grandPrixId}`;

    return this.http.get<ICarSession[]>(url);
  }

  getById(id: string): Observable<ICarSession> {
    const url = this._baseUrl + `/${id}`;

    return this.http.get<ICarSession>(url);
  }

  startSession(dto: any, strategy: string): Observable<boolean> {
    const url = this._baseUrl + `/start-session?strategy=${strategy}`;

    return this.http.patch<boolean>(url, dto);
  }
}
