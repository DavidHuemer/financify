import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RatAuthPageComponent } from './pages/rat-auth-page/rat-auth-page.component';
import { RatRippleDirective } from './directives/ripple/rat-ripple.directive';
import {MatRippleModule} from "@angular/material/core";



@NgModule({
  declarations: [
    RatAuthPageComponent,
    RatRippleDirective
  ],
  exports: [
    RatAuthPageComponent,
    RatRippleDirective
  ],
  imports: [
    CommonModule,
    MatRippleModule
  ]
})
export class RatUiModule { }
