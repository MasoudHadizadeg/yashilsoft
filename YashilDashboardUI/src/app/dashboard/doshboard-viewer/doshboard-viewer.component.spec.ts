import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { DoshboardViewerComponent } from './doshboard-viewer.component';

describe('DoshboardViewerComponent', () => {
  let component: DoshboardViewerComponent;
  let fixture: ComponentFixture<DoshboardViewerComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ DoshboardViewerComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(DoshboardViewerComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
