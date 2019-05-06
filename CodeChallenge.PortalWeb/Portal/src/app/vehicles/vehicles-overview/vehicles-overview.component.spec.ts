import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { VehiclesOverviewComponent } from './vehicles-overview.component';

describe('VehiclesOverviewComponent', () => {
  let component: VehiclesOverviewComponent;
  let fixture: ComponentFixture<VehiclesOverviewComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ VehiclesOverviewComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(VehiclesOverviewComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
