import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RacesPageComponent } from './races-page.component';
import { GrandPrixCardComponent } from './components/grand-prix-card/grand-prix-card.component';
import {RouterModule, Routes} from '@angular/router';

const routes: Routes = [{path: '', component: RacesPageComponent}];

@NgModule({
  declarations: [RacesPageComponent, GrandPrixCardComponent],
  imports: [
    CommonModule,
    RouterModule.forChild(routes)
  ]
})
export class RacesPageModule { }
