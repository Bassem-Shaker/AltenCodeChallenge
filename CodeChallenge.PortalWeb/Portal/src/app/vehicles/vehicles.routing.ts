import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { VehiclesOverviewComponent } from './vehicles-overview/vehicles-overview.component';

const VehiclesRoutes: Routes = [
    { path: '', component: VehiclesOverviewComponent },
    // { path: 'VehiclesOverview', component: VehiclesOverviewComponent}
];

@NgModule({
    imports: [
        RouterModule.forChild(VehiclesRoutes)
    ],
    exports: [RouterModule]
})
export class VehiclesRoutingModule { } 
