import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RaceCarPageComponent } from './race-car-page.component';
import {RouterModule, Routes} from '@angular/router';
import {SplitterModule} from 'primeng/splitter';
import {MessageModule} from 'primeng/message';
import {ButtonModule} from 'primeng/button';
import {DialogModule} from 'primeng/dialog';
import {InputTextModule} from 'primeng/inputtext';
import {FormsModule} from '@angular/forms';
import {RippleModule} from 'primeng/ripple';
import {CardModule} from 'primeng/card';
import {DropdownModule} from 'primeng/dropdown';
import { CarMaintenanceComponent } from './components/car-maintenance/car-maintenance.component';

const routes: Routes =
  [
    {path: '', component: RaceCarPageComponent},
    {path: 'maintenance', component: CarMaintenanceComponent}
  ];

@NgModule({
  declarations: [RaceCarPageComponent, CarMaintenanceComponent],
  imports: [
    CommonModule,
    RouterModule.forChild(routes),
    SplitterModule,
    MessageModule,
    ButtonModule,
    DialogModule,
    InputTextModule,
    FormsModule,
    RippleModule,
    CardModule,
    DropdownModule
  ]
})
export class RaceCarPageModule { }
