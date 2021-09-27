import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RaceCarPageComponent } from './race-car-page.component';
import {RouterModule, Routes} from '@angular/router';

const routes: Routes = [{path: '', component: RaceCarPageComponent}];

@NgModule({
  declarations: [RaceCarPageComponent],
  imports: [
    CommonModule,
    RouterModule.forChild(routes)
  ]
})
export class RaceCarPageModule { }
