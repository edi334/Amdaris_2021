import {IBase} from '../base';
import {IUser} from '../user';

export interface IDriver extends IBase {
  user: IUser;
  teamId: string;
  number: number;
  points: number;
  raceCarId: string;
}
