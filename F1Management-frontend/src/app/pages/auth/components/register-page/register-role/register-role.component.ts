import {Component, Input, OnInit} from '@angular/core';
import {IUser} from '../../../../../models/user';
import {TeamService} from '../../../../../services/team.service';
import {RaceCarService} from '../../../../../services/race-car.service';
import {IRaceCar} from '../../../../../models/race-car-models/race-car';
import {IDriver} from '../../../../../models/team-members/driver';
import {AuthService} from '../../../../../services/auth.service';
import {IRegister} from '../../../../../models/register';
import {Router} from '@angular/router';

@Component({
  selector: 'app-register-role',
  templateUrl: './register-role.component.html',
  styleUrls: ['./register-role.component.scss'],
})
export class RegisterRoleComponent implements OnInit {
  @Input() user: IUser;
  @Input() teamId: string;
  raceCarId = '';
  number = 0;
  driverId = '';
  raceCars: IRaceCar[];
  drivers: IDriver[];

  constructor(
    private readonly _raceCarService: RaceCarService,
    private readonly _teamService: TeamService,
    private readonly _authService: AuthService,
    private readonly _router: Router
  ) {
  }

  isDisabled(): boolean {
    const userOk = this.user.userTeamRole !== '' && this.user.firstName !== '' && this.user.lastName !== ''
      && this.user.email !== '' && this.user.phoneNumber !== '' && this.user.password !== '';

    if (!userOk) { return true; }
    else {
      if (this.user.userTeamRole === 'Driver') { return !(this.raceCarId !== '' && this.number !== 0); }
      else if (this.user.userTeamRole === 'RaceEngineer') { return this.driverId === ''; }
      else { return false; }
    }
  }

  ngOnInit(): void {
    this._raceCarService.getByTeamId(this.teamId).subscribe(res => {
      this.raceCars = res;
    });
    this._teamService.getDrivers(this.teamId).subscribe(res => {
      this.drivers = res;
    });
  }

  submit(): void {
    const register: IRegister = {
      teamId: this.teamId,
      user: this.user
    };
    if (this.user.userTeamRole === 'Driver') {
      this._authService.registerDriver(this.number, this.raceCarId, register).subscribe(() => {
        this._router.navigate(['auth/login']).then();
      });
    } else if (this.user.userTeamRole === 'RaceEngineer') {
      this._authService.registerRaceEngineer(this.driverId, register).subscribe(() => {
        this._router.navigate(['auth/login']).then();
      });
    } else {
      this._authService.registerMechanic(register, this.user.userTeamRole).subscribe(() => {
        this._router.navigate(['auth/login']).then();
      });
    }
  }

}
