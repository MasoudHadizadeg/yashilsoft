import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { SpaBodyComponent } from './spa-body.component';

describe('SpaBodyComponent', () => {
  let component: SpaBodyComponent;
  let fixture: ComponentFixture<SpaBodyComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ SpaBodyComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(SpaBodyComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
