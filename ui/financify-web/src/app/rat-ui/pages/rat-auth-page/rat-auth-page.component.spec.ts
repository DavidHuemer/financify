import { ComponentFixture, TestBed } from '@angular/core/testing';

import { RatAuthPageComponent } from './rat-auth-page.component';

describe('RatAuthPageComponent', () => {
  let component: RatAuthPageComponent;
  let fixture: ComponentFixture<RatAuthPageComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ RatAuthPageComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(RatAuthPageComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
