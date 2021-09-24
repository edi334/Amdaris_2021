import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MenuComponent } from './components/menu/menu.component';
import {TabMenuModule} from 'primeng/tabmenu';



@NgModule({
    declarations: [MenuComponent],
    exports: [
        MenuComponent
    ],
  imports: [
    CommonModule,
    TabMenuModule,
  ]
})
export class SharedModule { }
