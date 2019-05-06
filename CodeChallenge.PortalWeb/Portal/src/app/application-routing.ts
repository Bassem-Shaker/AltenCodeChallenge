import { Routes } from '@angular/router';

export const ApplicationRoutes: Routes = [
     { path: '', loadChildren:
     '../app/vehicles/vehicles.modules#VehiclesModule', pathMatch: 'full' },
    {
        path: 'vehicles', loadChildren:
             '../app/vehicles/vehicles.modules#VehiclesModule'
    }
];
