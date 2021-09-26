import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { StandingsPageComponent } from './standings-page.component';
import {RouterModule, Routes} from '@angular/router';

const routes: Routes = [{path: '', component: StandingsPageComponent}];

@NgModule({
  declarations: [StandingsPageComponent],
  imports: [
    CommonModule,
    RouterModule.forChild(routes)
  ]
})
export class StandingsPageModule { }
