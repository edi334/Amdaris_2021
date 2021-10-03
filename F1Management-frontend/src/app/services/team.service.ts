import { Injectable } from '@angular/core';
import {HttpClient} from '@angular/common/http';
import {environment} from '../../environments/environment';
import {Observable} from 'rxjs';
import {ITeam} from '../models/team';

@Injectable({
  providedIn: 'root'
})
export class TeamService {
  private _baseUrl = environment.apiUrl + 'team';

  constructor(
    private readonly _http: HttpClient
  ) { }

  getAll(): Observable<ITeam> {
    
  }
}
