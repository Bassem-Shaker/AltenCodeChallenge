import { VehiclesOverviewComponent } from './vehicles-overview/vehicles-overview.component';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

import { VehiclesRoutingModule } from './Vehicles.routing';
import { VehiclesService } from './vehicles.service';
import { HttpClientModule } from '@angular/common/http';
import { MaterialModule } from '../material.module';

@NgModule({
  imports: [
    VehiclesRoutingModule,
    FormsModule,
    CommonModule,
    MaterialModule
  ],
  declarations: [VehiclesOverviewComponent],
  providers:[VehiclesService]
})
export class VehiclesModule { }

