import { Injectable } from '@angular/core';  
import { HttpClient, HttpParams } from '@angular/common/http';  
import { Observable } from 'rxjs';  
import { ICustomer } from '../shared-models/Customer.models';
import { IVechicleModel } from './model/vechicle.model';
import { RequestOptions } from '@angular/http';
import { FilterVehicle } from './model/filtervehicle.model';
  
@Injectable({  
  providedIn: 'root'  
})  
export class VehiclesService {  
  cutomerUrl = "http://localhost:52845/"; 
  vehiclesUrl = "http://localhost:53373/";  

  constructor(private http: HttpClient) { }  
  GetAllCustomer(): Observable<ICustomer[]> {  
    return this.http.get<ICustomer[]>(this.cutomerUrl + 'api/Customer/GetAll')  
  }  

  
  GetVehicles(filterVehicle:FilterVehicle): Observable<IVechicleModel[]> {  
    return this.http.post<IVechicleModel[]>(this.vehiclesUrl + 'api/Vehicles/Get',filterVehicle);  
  }  

}  