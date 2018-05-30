import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ViewStatsComponent } from './/stats.component';

describe('ViewStateComponent', () => {
  let component: ViewStatsComponent;
  let fixture: ComponentFixture<ViewStatsComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ViewStatsComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ViewStatsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
