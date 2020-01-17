import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { SpaCardTileComponent } from './spa-card-tile.component';

describe('SpaCardTileComponent', () => {
  let component: SpaCardTileComponent;
  let fixture: ComponentFixture<SpaCardTileComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ SpaCardTileComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(SpaCardTileComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
