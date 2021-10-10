import {Component, OnInit} from '@angular/core';
import {RaceCarService} from '../../services/race-car.service';
import {AuthService} from '../../services/auth.service';
import {IRaceCar} from '../../models/race-car-models/race-car';
import {Router} from '@angular/router';
import {IChassis} from '../../models/race-car-models/chassis';
import {IEngine} from '../../models/race-car-models/engine';
import {IGearbox} from '../../models/race-car-models/gearbox';
import {ITireSet} from '../../models/race-car-models/tire-set';

const ID = 'user_id';
const TEAM_ID = 'user_team_id';

@Component({
  selector: 'app-race-car-page',
  templateUrl: './race-car-page.component.html',
  styleUrls: ['./race-car-page.component.scss']
})
export class RaceCarPageComponent implements OnInit {
  types: string[] = ['Soft', 'Medium', 'Hard', 'Intermediate', 'Wet'];
  raceCars: IRaceCar[] = [];
  display: boolean;
  displayChassis: boolean;
  displayEngine: boolean;
  displayGearbox: boolean;
  displayTireSet: boolean;
  goToRegister = false;
  carName = '';
  chassis: IChassis = {
    wear: 0,
    frontWing: '',
    rearWing: '',
    bodyWork: ''
  };
  engine: IEngine = {
    wear: 0,
    brand: '',
    horsePower: 0
  };
  gearbox: IGearbox = {
    wear: 0,
    gearCount: 8
  };
  tireSet: ITireSet = {
    type: '',
    brand: '',
    frontLeftWear: 0,
    frontRightWear: 0,
    rearLeftWear: 0,
    rearRightWear: 0
  };


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

  showDialog(): void {
    this.display = true;
  }

  showChassisDialog(): void {
    this.displayChassis = true;
  }

  showEngineDialog(): void {
    this.displayEngine = true;
  }

  showGearboxDialog(): void {
    this.displayGearbox = true;
  }

  showTireSetDialog(): void {
    this.displayTireSet = true;
  }

  async submit(): Promise<void> {
    try {
      await this._raceCarService.addRaceCar(this.carName).toPromise();
      this.goToRegister = true;
    } catch (e) {
      console.log(e);
    }
  }

  async submitChassis(id: string): Promise<void> {
    try {
      await this._raceCarService.addChassis(id, this.chassis).toPromise();
      this.displayChassis = false;
      this.raceCars = await this._raceCarService.getByTeamId(this._authService.getTeamId()).toPromise();
    } catch (e) {
      console.log(e);
    }
  }

  async submitEngine(id: string): Promise<void> {
    try {
      await this._raceCarService.addEngine(id, this.engine).toPromise();
      this.displayEngine = false;
      this.raceCars = await this._raceCarService.getByTeamId(this._authService.getTeamId()).toPromise();
    } catch (e) {
      console.log(e);
    }
  }

  async submitGearbox(id: string): Promise<void> {
    try {
      await this._raceCarService.addGearbox(id, this.gearbox).toPromise();
      this.displayGearbox = false;
      this.raceCars = await this._raceCarService.getByTeamId(this._authService.getTeamId()).toPromise();
    } catch (e) {
      console.log(e);
    }
  }

  async submitTireSet(id: string): Promise<void> {
    try {
      await this._raceCarService.addTireSet(id, this.tireSet).toPromise();
      this.displayTireSet = false;
      this.raceCars = await this._raceCarService.getByTeamId(this._authService.getTeamId()).toPromise();
    } catch (e) {
      console.log(e);
    }
  }

  navigateToRegister(): void {
    localStorage.removeItem(ID);
    localStorage.removeItem(TEAM_ID);
    this._router.navigate(['auth/register']).then();
  }
}
