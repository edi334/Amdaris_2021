import {IBase} from '../base';
import {IUser} from '../user';

export interface ICarMechanic extends IBase {
  user: IUser;
  teamId: string;
}
