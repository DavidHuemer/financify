import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RatAuthPageComponent } from './pages/rat-auth-page/rat-auth-page.component';



@NgModule({
  declarations: [
    RatAuthPageComponent
  ],
  exports: [
    RatAuthPageComponent
  ],
  imports: [
    CommonModule
  ]
})
export class RatUiModule { }
