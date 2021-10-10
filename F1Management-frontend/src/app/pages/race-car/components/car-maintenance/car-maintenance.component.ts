import {Component, OnInit} from '@angular/core';
import {IRaceCar} from '../../../../models/race-car-models/race-car';
import {RaceCarService} from '../../../../services/race-car.service';
import {AuthService} from '../../../../services/auth.service';
import {Router} from '@angular/router';

const ID = 'user_id';
const TEAM_ID = 'user_team_id';

@Component({
  selector: 'app-car-maintenance',
  templateUrl: './car-maintenance.component.html',
  styleUrls: ['./car-maintenance.component.scss']
})
export class CarMaintenanceComponent implements OnInit {
  raceCars: IRaceCar[] = [];
  selectedRaceCar: IRaceCar;

  constructor(
    private readonly _raceCarService: RaceCarService,
    private readonly _authService: AuthService,
    private readonly _router: Router
  ) {
  }

  ngOnInit(): void {
    this._raceCarService.getByTeamId(this._authService.getTeamId()).subscribe(res => {
      this.raceCars = res;
    });
  }

  async fixCar(): Promise<void> {
    await this._raceCarService.fixRaceCar(this.selectedRaceCar).toPromise();
    this._router.navigate(['race-car']).then();
  }

  async fixChassis(): Promise<void> {
    await this._raceCarService.fixChassis(this.selectedRaceCar).toPromise();
    this._router.navigate(['race-car']).then();
  }

  async fixEngine(): Promise<void> {
    await this._raceCarService.fixEngine(this.selectedRaceCar).toPromise();
    this._router.navigate(['race-car']).then();
  }

  async fixGearBox(): Promise<void> {
    await this._raceCarService.fixGearBox(this.selectedRaceCar).toPromise();
    this._router.navigate(['race-car']).then();
  }

}
