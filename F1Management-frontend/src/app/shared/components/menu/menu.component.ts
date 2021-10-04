import { Component, OnInit } from '@angular/core';
import {MenuItem} from 'primeng/api';
import {Router} from '@angular/router';

const ID = 'user_id';
const TEAM_ID = 'user_team_id';

@Component({
  selector: 'app-menu',
  templateUrl: './menu.component.html',
  styleUrls: ['./menu.component.scss']
})
export class MenuComponent implements OnInit {
  items: MenuItem[];
  activeItem: MenuItem;

  constructor(
    private readonly _router: Router
  ) { }

  ngOnInit(): void {
    this.buildMenu();
  }

  buildMenu(): void {
    this.items = [
      {label: 'Races', icon: 'pi pi-fw pi-flag', routerLink: ['races']},
      {label: 'Standings', icon: 'pi pi-fw pi-sort-alt', routerLink: ['standings']},
      {label: 'Race Car', icon: 'pi pi-fw pi-angle-double-down', routerLink: ['race-car']},
      {label: 'Logout', icon: 'pi pi-fw pi-sign-out', command: () => {
        localStorage.removeItem(ID);
        localStorage.removeItem(TEAM_ID);
        this._router.navigate(['auth']).then();
        }}
    ];
    this.activeItem = this.items[0];
  }

}
