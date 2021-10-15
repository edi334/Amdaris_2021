import {Component, Input} from '@angular/core';
import {IGrandPrix} from '../../../../models/grand-prix';
import {Router} from '@angular/router';
import {AuthService} from '../../../../services/auth.service';

@Component({
  selector: 'app-grand-prix-card',
  templateUrl: './grand-prix-card.component.html',
  styleUrls: ['./grand-prix-card.component.scss']
})
export class GrandPrixCardComponent {
  constructor(
    private readonly _router: Router
  ) {
  }

  @Input() grandPrix: IGrandPrix;

  goToSessions(): void {
    this._router.navigate(['races/sessions', {grandPrixId: this.grandPrix.id }]).then();
  }
}
