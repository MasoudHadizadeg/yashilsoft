import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { SpaBodySectionComponent } from './spa-body-section.component';

describe('SpaBodySectionComponent', () => {
  let component: SpaBodySectionComponent;
  let fixture: ComponentFixture<SpaBodySectionComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ SpaBodySectionComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(SpaBodySectionComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
