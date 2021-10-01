import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

const routes: Routes = [
  {
    path: '',
    pathMatch: 'full',
    redirectTo: 'races'
  },
  {
    path: 'races',
    loadChildren: () =>
      import('./pages/races/races-page.module').then(m => m.RacesPageModule)
  },
  {
    path: 'standings',
    loadChildren: () =>
      import('./pages/standings/standings-page.module').then(m => m.StandingsPageModule)
  },
  {
    path: 'race-car',
    loadChildren: () =>
      import('./pages/race-car/race-car-page.module').then(m => m.RaceCarPageModule)
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
