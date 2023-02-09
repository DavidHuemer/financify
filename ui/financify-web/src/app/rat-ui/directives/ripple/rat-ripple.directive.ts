import {Directive, ElementRef, NgZone} from '@angular/core';
import {MatRipple} from "@angular/material/core";
import {Platform} from "@angular/cdk/platform";

@Directive({
  selector: '[ratRipple]'
})
export class RatRippleDirective extends MatRipple{

  constructor(_elementRef: ElementRef<HTMLElement>, ngZone: NgZone, platform: Platform) {
    super(_elementRef, ngZone, platform, undefined, undefined);
  }

}
