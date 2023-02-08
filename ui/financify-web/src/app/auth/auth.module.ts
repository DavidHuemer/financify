import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { AuthRoutingModule } from './auth-routing.module';
import { SignUpPageComponent } from './pages/sign-up-page/sign-up-page.component';
import {RatUiModule} from "../rat-ui/rat-ui.module";


@NgModule({
  declarations: [
    SignUpPageComponent
  ],
  imports: [
    CommonModule,
    AuthRoutingModule,
    RatUiModule
  ]
})
export class AuthModule { }
