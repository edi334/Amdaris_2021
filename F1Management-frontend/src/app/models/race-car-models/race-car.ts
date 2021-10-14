import {IBase} from '../base';
import {IChassis} from './chassis';
import {IEngine} from './engine';
import {IGearbox} from './gearbox';
import {ITireSet} from './tire-set';

export interface IRaceCar extends IBase {
  name: string;
  chassis: IChassis;
  engine: IEngine;
  gearbox: IGearbox;
  tireSet: ITireSet;
}
