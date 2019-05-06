export interface IVechicleModel {
    id:number;
    VehicleID: number;
    VIN: string;
    Regnr: string;
    CustomerID: number;
    customerName:string;
    isconnected: boolean;
    lastPingTime:Date;
}
