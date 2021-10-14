import { Component, OnInit } from '@angular/core';
import {IRaceCar} from '../../../../models/race-car-models/race-car';
import {RaceCarService} from '../../../../services/race-car.service';
import {AuthService} from '../../../../services/auth.service';
import {Router} from '@angular/router';

@Component({
  selector: 'app-update-car',
  templateUrl: './update-car.component.html',
  styleUrls: ['./update-car.component.scss']
})
export class UpdateCarComponent implements OnInit {
  raceCars: IRaceCar[] = [];
  selectedRaceCar: IRaceCar;

  constructor(
    private readonly _raceCarService: RaceCarService,
    private readonly _authService: AuthService,
    readonly router: Router
  ) { }

  ngOnInit(): void {
    this._raceCarService.getByTeamId(this._authService.getTeamId()).subscribe(res => {
      this.raceCars = res;
    });
  }

  async update(): Promise<void> {
    try {
      await this._raceCarService.update(this.selectedRaceCar).toPromise();
      this.router.navigate(['race-car']).then();
    } catch (err) {
      console.log(err);
    }
  }

}
