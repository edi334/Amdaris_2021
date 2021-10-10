import {Injectable} from '@angular/core';
import {environment} from '../../environments/environment';
import {Observable} from 'rxjs';
import {HttpClient} from '@angular/common/http';
import {IRegister} from '../models/register';
import {ILogin} from '../models/login';

const ID = 'user_id';
const TEAM_ID = 'user_team_id';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  private _baseUrl = environment.apiUrl + 'auth/';

  constructor(
    private readonly _http: HttpClient
  ) {
  }

  getTeamId(): string {
    return localStorage.getItem(TEAM_ID) as string;
  }

  getId(): string {
    return localStorage.getItem(ID) as string;
  }

  registerTeam(teamName: string): Observable<string> {
    const url = this._baseUrl + `register-team?name=${teamName}`;

    return this._http.post(url, teamName, {responseType: 'text'});
  }

  registerDriver(driverNumber: number, raceCarId: string, register: IRegister): Observable<string> {
    const url = this._baseUrl + `register-driver?number=${driverNumber}&raceCarId=${raceCarId}`;

    return this._http.post(url, register, {responseType: 'text'});
  }

  registerRaceEngineer(driverId: string, register: IRegister): Observable<string> {
    const url = this._baseUrl + `register-race-engineer?driverId=${driverId}`;

    return this._http.post(url, register, {responseType: 'text'});
  }

  registerMechanic(register: IRegister, type: string): Observable<string> {
    let url = this._baseUrl;
    if (type === 'PitStopMechanic') {
      url = url + 'register-pit-stop-mechanic';
    } else {
       url = url + 'register-car-mechanic';
    }

    return this._http.post(url, register, {responseType: 'text'});
  }

  login(login: ILogin): Observable<{teamId: string, userId: string}> {
    const url = this._baseUrl + 'login';

    return this._http.post<{teamId: string, userId: string}>(url, login);
  }

  isLoggedIn(): boolean {
    return localStorage.getItem(ID) !== null || localStorage.getItem(TEAM_ID) !== null;
  }
}
