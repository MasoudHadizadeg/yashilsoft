import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { SpaNavbarComponent } from './spa-navbar.component';

describe('SpaNavbarComponent', () => {
  let component: SpaNavbarComponent;
  let fixture: ComponentFixture<SpaNavbarComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ SpaNavbarComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(SpaNavbarComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
