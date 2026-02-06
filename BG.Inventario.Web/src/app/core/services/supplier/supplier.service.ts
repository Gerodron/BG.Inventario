import { HttpClient } from '@angular/common/http';
import { inject, Injectable } from '@angular/core';
import { BaseResponseApi } from '../../interfaces/BaseResponseApi.interface';
import { IProductSupplier } from '../../interfaces/productSupplier.interface';

@Injectable({
  providedIn: 'root',
})
export class SupplierService {
  private _http: HttpClient = inject(HttpClient);
  private url: string = 'http://localhost:5092'

  public getAllProductSuppliers() {
    return this._http.get<BaseResponseApi<IProductSupplier[]>>(`${this.url}/api/Inventory/GetProductSuppliers`)
  }
}
