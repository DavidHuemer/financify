import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import {RatUiModule} from "./rat-ui/rat-ui.module";

@NgModule({
  declarations: [
    AppComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    RatUiModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
