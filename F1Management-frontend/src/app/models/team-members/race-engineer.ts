import {IBase} from '../base';
import {IUser} from '../user';

export interface RaceEngineer extends IBase {
  user: IUser;
  driverId: string;
  teamId: string;
}
