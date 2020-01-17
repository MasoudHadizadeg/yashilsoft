import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { SpaIndexComponent } from './spa-index.component';

describe('SpaIndexComponent', () => {
  let component: SpaIndexComponent;
  let fixture: ComponentFixture<SpaIndexComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ SpaIndexComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(SpaIndexComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
