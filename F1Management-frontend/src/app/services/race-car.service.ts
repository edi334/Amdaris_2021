import {Injectable} from '@angular/core';
import {environment} from '../../environments/environment';
import {HttpClient} from '@angular/common/http';
import {Observable} from 'rxjs';
import {IRaceCar} from '../models/race-car-models/race-car';
import {IChassis} from '../models/race-car-models/chassis';
import {IEngine} from '../models/race-car-models/engine';
import {IGearbox} from '../models/race-car-models/gearbox';
import {ITireSet} from '../models/race-car-models/tire-set';

@Injectable({
  providedIn: 'root'
})
export class RaceCarService {
  private _baseUrl = environment.apiUrl + 'race-car';

  constructor(
    private readonly _http: HttpClient
  ) {
  }

  getAll(): Observable<IRaceCar[]> {
    const url = this._baseUrl;

    return this._http.get<IRaceCar[]>(url);
  }

  getByTeamId(teamId: string): Observable<IRaceCar[]> {
    const url = this._baseUrl + `/team/${teamId}`;

    return this._http.get<IRaceCar[]>(url);
  }

  getById(id: string): Observable<IRaceCar> {
    const url = this._baseUrl + `/${id}`;

    return this._http.get<IRaceCar>(url);
  }

  addRaceCar(name: string): Observable<boolean> {
    const url = this._baseUrl + `/${name}`;

    return this._http.post<boolean>(url, {});
  }

  addChassis(id: string, chassis: IChassis): Observable<boolean> {
    const url = this._baseUrl + `/${id}/chassis`;

    return this._http.post<boolean>(url, chassis);
  }

  addEngine(id: string, engine: IEngine): Observable<boolean> {
    const url = this._baseUrl + `/${id}/engine`;

    return this._http.post<boolean>(url, engine);
  }

  addGearbox(id: string, gearbox: IGearbox): Observable<boolean> {
    const url = this._baseUrl + `/${id}/gearbox`;

    return this._http.post<boolean>(url, gearbox);
  }

  addTireSet(id: string, tireSet: ITireSet): Observable<boolean> {
    const url = this._baseUrl + `/${id}/tire-set`;

    return this._http.post<boolean>(url, tireSet);
  }

  fixRaceCar(car: IRaceCar): Observable<boolean> {
    const url = this._baseUrl + `/fix`;

    return this._http.patch<boolean>(url, car);
  }

  fixChassis(car: IRaceCar): Observable<boolean> {
    const url = this._baseUrl + `/fix-chassis`;

    return this._http.patch<boolean>(url, car);
  }

  fixEngine(car: IRaceCar): Observable<boolean> {
    const url = this._baseUrl + `/fix-engine`;

    return this._http.patch<boolean>(url, car);
  }

  fixGearBox(car: IRaceCar): Observable<boolean> {
    const url = this._baseUrl + `/fix-gearbox`;

    return this._http.patch<boolean>(url, car);
  }
}
