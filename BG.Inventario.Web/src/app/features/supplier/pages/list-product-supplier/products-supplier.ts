import { Component, inject, signal, WritableSignal } from '@angular/core';
import { Navbar } from '../../../../shared/components/navbar/navbar';
import { IProductSupplier } from '../../../../core/interfaces/productSupplier.interface';
import { SupplierService } from '../../../../core/services/supplier/supplier.service';
import { ActivatedRoute, RouterLink } from "@angular/router";
import { ISupplier } from '../../../../core/interfaces/supplier.inteface';

@Component({
  selector: 'app-products-supllier',
  standalone: true,
  imports: [Navbar, RouterLink],
  templateUrl: './products-supllier.html',
  styleUrl: './products-supllier.css',
})
export class ProductsSupllier {

  _supplierService = inject(SupplierService)
  _route = inject(ActivatedRoute);

  public products = signal<IProductSupplier[]>([]);

  deleteProductFromSupplier(productId: string) {

  }

  ngOnInit() {
    this.getAllProductBySupplierId()
  }

  getAllProductBySupplierId() {
    const id = this._route.snapshot.paramMap.get('id') ?? '0';
    const idint = parseInt(id)
    this._supplierService.getAllProductSuppliersBySupplierId(idint).subscribe({
      next: (response) => {

        this.products.set(response.data!)
      },
      error: (err) => {
      }
    });
  }
}
