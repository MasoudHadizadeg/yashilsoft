import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { SpaHeaderComponent } from './spa-header.component';

describe('SpaHeaderComponent', () => {
  let component: SpaHeaderComponent;
  let fixture: ComponentFixture<SpaHeaderComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ SpaHeaderComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(SpaHeaderComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
