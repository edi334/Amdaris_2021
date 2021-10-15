import {IBase} from './base';
import {Moment} from 'moment';

export interface ICarSession extends IBase{
  name: string;
  grandPrixId: string;
  raceCarId: string;
  position: number;
  sessionType: string;
  startDate: Date;
  endDate: Date;
  fastestLap: Moment;
}
