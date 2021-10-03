import {IBase} from '../base';

export interface ITireSet extends IBase {
  type: string;
  brand: string;
  frontLeftWear: number;
  frontRightWear: number;
  rearLeftWear: number;
  rearRightWear: number;
}
