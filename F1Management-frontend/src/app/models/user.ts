import {IBase} from './base';

export interface IUser extends IBase {
  firstName: string;
  lastName: string;
  email: string;
  phoneNumber: string;
  password: string;
  userTeamRole: '' | 'Driver' | 'CarMechanic' | 'PitStopMechanic' | 'RaceEngineer';
}
