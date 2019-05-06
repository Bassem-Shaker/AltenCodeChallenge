import { Component, OnInit } from '@angular/core';
import { ICustomer } from 'src/app/shared-models/Customer.models';
import { MatTableDataSource } from '@angular/material';
import { VehiclesService } from '../vehicles.service';
import { IVechicleModel } from '../model/vechicle.model';
import { FilterVehicle } from '../model/filtervehicle.model';
import { KeyValue } from 'src/app/shared-models/keyvalue.model';

@Component({
  selector: 'app-vehicles-overview',
  templateUrl: './vehicles-overview.component.html',
  styleUrls: ['./vehicles-overview.component.css']
})
export class VehiclesOverviewComponent implements OnInit {
  selected:any;
  public vehicleStatus: Array<any> = [{ id: 1, type: 'Connected' }, { id: 0, type: 'Disconnected' }];;
  public filterVehicle: FilterVehicle = new FilterVehicle();
  public filterCustomerID: number = -1;
  public filterIsConnected: number = -1;
  status = ['Select Status', 'All', 'Unpaid and sent', 'Unpaid with due date', 'Paid', 'Open', 'Overdue'];
  public allCustomers: ICustomer[];
  public VechicleModel: IVechicleModel[];

  constructor(private vehiclesService: VehiclesService, ) {

  }
  ngOnInit() {
    this.LoadDDL();
    this.executeSearch()
  }
  private LoadDDL() {
    this.vehiclesService.GetAllCustomer().subscribe(data => {
      this.allCustomers = data
    });
  }
  private executeSearch() {
    debugger
    this.filterVehicle.IsConnected = this.filterIsConnected;
    this.filterVehicle.CustomerID = this.filterCustomerID;
    this.vehiclesService.GetVehicles(this.filterVehicle).subscribe(data => {
      this.VechicleModel = data

    });

  }

}

