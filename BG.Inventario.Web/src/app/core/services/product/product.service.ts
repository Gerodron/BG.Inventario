import { HttpClient } from '@angular/common/http';
import { inject, Injectable } from '@angular/core';
import { IProduct } from '../../interfaces/product.interface';
import { BaseResponseApi } from '../../interfaces/BaseResponseApi.interface';
import { Observable } from 'rxjs';
import { CreateProductModel } from '../../models/CreateProduct.model';

@Injectable({
  providedIn: 'root',
})
export class ProductService {
  private _http: HttpClient = inject(HttpClient);
  private url: string = 'http://localhost:5092'

  public getAllProducts(): Observable<BaseResponseApi<IProduct[]>> {
    return this._http.get<BaseResponseApi<IProduct[]>>(`${this.url}/api/Inventory/GetAllProducts`);
  }

  public updateProductById(data: IProduct) {
    return this._http.put<BaseResponseApi<boolean>>(`${this.url}/api/Inventory/UpdateProductById`, data);
  }

    public createProduct(data: CreateProductModel) {
    return this._http.post<BaseResponseApi<boolean>>(`${this.url}/api/Inventory/CreateProduct`, data);
  }
}
