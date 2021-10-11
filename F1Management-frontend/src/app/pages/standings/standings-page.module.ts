import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { StandingsPageComponent } from './standings-page.component';
import {RouterModule, Routes} from '@angular/router';
import {TableModule} from 'primeng/table';
import {DropdownModule} from 'primeng/dropdown';
import {FormsModule} from '@angular/forms';

const routes: Routes = [{path: '', component: StandingsPageComponent}];

@NgModule({
  declarations: [StandingsPageComponent],
  imports: [
    CommonModule,
    RouterModule.forChild(routes),
    TableModule,
    DropdownModule,
    FormsModule
  ]
})
export class StandingsPageModule { }
