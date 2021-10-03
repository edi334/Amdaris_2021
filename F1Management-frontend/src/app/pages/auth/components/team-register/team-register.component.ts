import { Component, OnInit } from '@angular/core';
import {AuthService} from '../../../../services/auth.service';
import {MessageService} from 'primeng/api';
import {Router} from '@angular/router';

@Component({
  selector: 'app-team-register',
  templateUrl: './team-register.component.html',
  styleUrls: ['./team-register.component.scss'],
  providers: [MessageService]
})
export class TeamRegisterComponent {
  teamName: string;

  constructor(
    private readonly _authService: AuthService,
    private readonly _messageService: MessageService,
    readonly router: Router
  ) { }

  submit(): void {
    this._authService.registerTeam(this.teamName).subscribe(res => {
      this._messageService.add({key: 'bc', severity: 'success', summary: 'Success', detail: res});
    });
  }
}
