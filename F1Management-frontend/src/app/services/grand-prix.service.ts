import { Injectable } from '@angular/core';
import {HttpClient} from '@angular/common/http';
import {environment} from '../../environments/environment';
import {Observable} from 'rxjs';
import {IGrandPrix} from '../models/grand-prix';

@Injectable({
  providedIn: 'root'
})
export class GrandPrixService {
  private _baseUrl = environment.apiUrl;

  constructor(
    private readonly _http: HttpClient
  ) { }

  getAll(): Observable<IGrandPrix[]> {
    const url = this._baseUrl + 'grand-prix';

    return this._http.get<IGrandPrix[]>(url);
  }
}
