import { HttpClient, HttpParams } from '@angular/common/http';
import { inject, Injectable } from '@angular/core';
import { BaseResponseApi } from '../../interfaces/BaseResponseApi.interface';
import { IProductSupplier } from '../../interfaces/productSupplier.interface';
import { CreateSupplierModel } from '../../models/CreateSupplier.model';
import { ISupplier } from '../../interfaces/supplier.inteface';

@Injectable({
  providedIn: 'root',
})
export class SupplierService {
  private _http: HttpClient = inject(HttpClient);
  private url: string = 'http://localhost:5092'

  public getAllProductSuppliers() {
    return this._http.get<BaseResponseApi<IProductSupplier[]>>(`${this.url}/api/Inventory/GetProductSuppliers`)
  }

  public getAllProductSuppliersBySupplierId(id : number) {
    const params = new HttpParams().set('supplierId', id)

    return this._http.get<BaseResponseApi<IProductSupplier[]>>(`${this.url}/api/Inventory/GetProductSuppliersBySupplierId`, {params})
  }

  public createSupplier(model: CreateSupplierModel) {
    return this._http.post<BaseResponseApi<BaseResponseApi<boolean>>>(`${this.url}/api/Inventory/CreateSupplier`, model)
  }

  public getAllSuppliers() {
    return this._http.get<BaseResponseApi<ISupplier[]>>(`${this.url}/api/Inventory/GetAllSuppliers`)
  }
}
