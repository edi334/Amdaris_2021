import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AuthPageComponent } from './auth-page.component';
import {RouterModule, Routes} from '@angular/router';
import { LoginPageComponent } from './components/login-page/login-page.component';
import { RegisterPageComponent } from './components/register-page/register-page.component';
import {ButtonModule} from 'primeng/button';
import {RippleModule} from 'primeng/ripple';
import { TeamRegisterComponent } from './components/team-register/team-register.component';
import {InputTextModule} from 'primeng/inputtext';
import {FormsModule} from '@angular/forms';
import {MessageModule} from 'primeng/message';
import {MessagesModule} from 'primeng/messages';
import {ToastModule} from 'primeng/toast';
import {DropdownModule} from 'primeng/dropdown';
import {PasswordModule} from 'primeng/password';
import { RegisterRoleComponent } from './components/register-page/register-role/register-role.component';
import {InputNumberModule} from 'primeng/inputnumber';

const routes: Routes =
  [
    {path: '', component: AuthPageComponent},
    {path: 'login', component: LoginPageComponent},
    {path: 'register', component: RegisterPageComponent},
    {path: 'register-team', component: TeamRegisterComponent}
  ];

@NgModule({
  declarations: [AuthPageComponent, LoginPageComponent, RegisterPageComponent, TeamRegisterComponent, RegisterRoleComponent],
  imports: [
    CommonModule,
    RouterModule.forChild(routes),
    ButtonModule,
    RippleModule,
    InputTextModule,
    FormsModule,
    MessageModule,
    MessagesModule,
    ToastModule,
    DropdownModule,
    PasswordModule,
    InputNumberModule,
  ]
})
export class AuthPageModule { }
