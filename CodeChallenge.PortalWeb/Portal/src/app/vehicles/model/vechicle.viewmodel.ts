import { IVechicleModel } from "./vechicle.model";
import { ICustomer } from "src/app/shared-models/Customer.models";

export interface IVechicleViewModel extends IVechicleModel,ICustomer {
}
