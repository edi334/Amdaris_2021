import {Component, Input} from '@angular/core';
import {IGrandPrix} from '../../../models/grand-prix';

@Component({
  selector: 'app-grand-prix-card',
  templateUrl: './grand-prix-card.component.html',
  styleUrls: ['./grand-prix-card.component.scss']
})
export class GrandPrixCardComponent {
  @Input() grandPrix: IGrandPrix;
}
