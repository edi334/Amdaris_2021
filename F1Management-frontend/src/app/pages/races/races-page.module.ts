import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RacesPageComponent } from './races-page.component';
import { GrandPrixCardComponent } from './components/grand-prix-card/grand-prix-card.component';
import {RouterModule, Routes} from '@angular/router';
import { SessionsComponent } from './components/sessions/sessions.component';
import {FormsModule} from '@angular/forms';
import {DropdownModule} from 'primeng/dropdown';
import {ButtonModule} from 'primeng/button';
import {RippleModule} from 'primeng/ripple';
import { EditSessionComponent } from './components/edit-session/edit-session.component';
import {InputTextModule} from 'primeng/inputtext';

const routes: Routes = [
  {path: '', component: RacesPageComponent},
  {path: 'sessions', component: SessionsComponent},
  {path: 'edit-session', component: EditSessionComponent}
];

@NgModule({
  declarations: [RacesPageComponent, GrandPrixCardComponent, SessionsComponent, EditSessionComponent],
  imports: [
    CommonModule,
    RouterModule.forChild(routes),
    FormsModule,
    DropdownModule,
    ButtonModule,
    RippleModule,
    InputTextModule
  ]
})
export class RacesPageModule { }
