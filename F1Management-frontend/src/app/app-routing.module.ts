import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import {AuthGuard} from './guards/auth.guard';

const routes: Routes = [
  {
    path: '',
    pathMatch: 'full',
    redirectTo: 'auth'
  },
  {
    path: 'races',
    loadChildren: () =>
      import('./pages/races/races-page.module').then(m => m.RacesPageModule),
    canActivate: [AuthGuard]
  },
  {
    path: 'standings',
    loadChildren: () =>
      import('./pages/standings/standings-page.module').then(m => m.StandingsPageModule),
    canActivate: [AuthGuard]
  },
  {
    path: 'race-car',
    loadChildren: () =>
      import('./pages/race-car/race-car-page.module').then(m => m.RaceCarPageModule),
    canActivate: [AuthGuard]
  },
  {
    path: 'auth',
    loadChildren: () =>
      import('./pages/auth/auth-page.module').then(m => m.AuthPageModule)
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
