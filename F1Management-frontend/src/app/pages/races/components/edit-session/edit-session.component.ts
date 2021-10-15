import { Component, OnInit } from '@angular/core';
import {ICarSession} from '../../../../models/car-session';
import {IChassis} from '../../../../models/race-car-models/chassis';
import {IEngine} from '../../../../models/race-car-models/engine';
import {IGearbox} from '../../../../models/race-car-models/gearbox';
import {ITireSet} from '../../../../models/race-car-models/tire-set';
import {ActivatedRoute} from '@angular/router';
import {CarSessionService} from '../../../../services/car-session.service';

@Component({
  selector: 'app-edit-session',
  templateUrl: './edit-session.component.html',
  styleUrls: ['./edit-session.component.scss']
})
export class EditSessionComponent implements OnInit {
  carSession: ICarSession;
  strategy = '';
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
    private readonly _route: ActivatedRoute,
    private readonly _carSessionService: CarSessionService,
  ) { }

  ngOnInit(): void {
    // tslint:disable-next-line:no-non-null-assertion
    this._carSessionService.getById(this._route.snapshot.paramMap.get('id')!).subscribe(res => {
      this.carSession = res;
    });
  }

  async start(): Promise<void> {
    const dto = {
      carSessionDto: this.carSession,
      chassisDto: this.chassis,
      engineDto: this.engine,
      gearboxDto: this.gearbox,
    };

    await this._carSessionService.startSession(dto, this.strategy).toPromise();
  }

}
