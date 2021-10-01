import { Component, OnInit } from '@angular/core';
import {MenuItem} from 'primeng/api';

@Component({
  selector: 'app-menu',
  templateUrl: './menu.component.html',
  styleUrls: ['./menu.component.scss']
})
export class MenuComponent implements OnInit {
  items: MenuItem[];
  activeItem: MenuItem;

  constructor() { }

  ngOnInit(): void {
    this.buildMenu();
  }

  buildMenu(): void {
    this.items = [
      {label: 'Races', icon: 'pi pi-fw pi-flag', routerLink: ['races']},
      {label: 'Standings', icon: 'pi pi-fw pi-sort-alt', routerLink: ['standings']},
      {label: 'Race Car', icon: 'pi pi-fw pi-angle-double-down', routerLink: ['race-car']}
    ];

    this.activeItem = this.items[0];
  }

}
