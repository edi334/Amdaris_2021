import {IBase} from '../base';
import {IUser} from '../user';

export interface PitStopMechanic extends IBase {
  user: IUser;
  pitStopCrewId: string;
}
