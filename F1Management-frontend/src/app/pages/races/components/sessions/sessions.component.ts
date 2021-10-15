import { Component, OnInit } from '@angular/core';
import {ActivatedRoute, Router} from '@angular/router';
import {CarSessionService} from '../../../../services/car-session.service';
import {ICarSession} from '../../../../models/car-session';
import {IRaceCar} from '../../../../models/race-car-models/race-car';
import {RaceCarService} from '../../../../services/race-car.service';
import {AuthService} from '../../../../services/auth.service';

@Component({
  selector: 'app-sessions',
  templateUrl: './sessions.component.html',
  styleUrls: ['./sessions.component.scss']
})
export class SessionsComponent implements OnInit {
  grandPrixId: string;
  selectedRaceCar: IRaceCar;
  raceCars: IRaceCar[] = [];
  sessions: ICarSession[] = [];

  constructor(
    private readonly _route: ActivatedRoute,
    private readonly _router: Router,
    private readonly _carSessionService: CarSessionService,
    private readonly _raceCarService: RaceCarService,
    private readonly _authService: AuthService
  ) {
  }

  ngOnInit(): void {
    // tslint:disable-next-line:no-non-null-assertion
    this.grandPrixId = this._route.snapshot.paramMap.get('grandPrixId')!;
    this._raceCarService.getByTeamId(this._authService.getTeamId()).subscribe(res => {
      this.raceCars = res;
    });
  }

  getSessions(): void {
    // tslint:disable-next-line:no-non-null-assertion
    this._carSessionService.getByTeamAndRace(this.selectedRaceCar.id!, this.grandPrixId).subscribe(res => {
      this.sessions = res;
    });
  }

  goToSession(session: ICarSession): void {
    this._router.navigate(['races/edit-session', {id: session.id}]).then();
  }
}
