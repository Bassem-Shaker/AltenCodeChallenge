import { Routes } from '@angular/router';

export const ApplicationRoutes: Routes = [
     { path: '', loadChildren:
     '../app/vehicles/vehicles.modules#VehiclesModule', pathMatch: 'full' },
    // { path: 'home/VehiclesOverview', component: VehiclesOverviewComponent },
    // ,
    // { path: 'home/contact', component: ContactComponent },
    // { path: 'home/about', component: AboutComponent },
    {
        path: 'vehicles', loadChildren:
             '../app/vehicles/vehicles.modules#VehiclesModule'
    },
    // {
    //     path: 'inventorymanagement', loadChildren:
    //         '../app/inventory-management/inventory-management.module#InventoryManagementModule'
    // },
    // {
    //     path: 'purchaseordermanagement', loadChildren:
    //         '../app/purchase-order-management/purchase-order-management.module#PurchaseOrderManagementModule'
    // },
    // {
    //     path: 'salesordermanagement', loadChildren:
    //         '../app/sales-order-management/sales-order-management.module#SalesOrderManagementModule'
    // }
];
