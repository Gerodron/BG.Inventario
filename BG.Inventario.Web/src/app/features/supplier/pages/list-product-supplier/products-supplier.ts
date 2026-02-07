import { Component, inject, signal, WritableSignal } from '@angular/core';
import { Navbar } from '../../../../shared/components/navbar/navbar';
import { IProductSupplier } from '../../../../core/interfaces/productSupplier.interface';
import { SupplierService } from '../../../../core/services/supplier/supplier.service';
import { RouterLink } from "@angular/router";
import { ISupplier } from '../../../../core/interfaces/supplier.inteface';

@Component({
  selector: 'app-products-supllier',
  imports: [Navbar, RouterLink],
  templateUrl: './products-supllier.html',
  styleUrl: './products-supllier.css',
})
export class ProductsSupllier {
  productSuppliers: WritableSignal<IProductSupplier[]> = signal([])
  suppliers: WritableSignal<ISupplier[]> = signal([])

  _supplierService = inject(SupplierService)

  getAllProductSuppliers() {
    console.log('CALL getAllProductSuppliers');

    this._supplierService.getAllProductSuppliers().subscribe({
      next: (res) => {

        if (res.data != null && res.success) {
          this.productSuppliers.set(res.data);
        } else {
        }
      },
      error: (err) => {
        console.error('API ERROR:', err);
      },
      complete: () => {
        console.log('getAllProductSuppliers() completed');
      }
    });
  }

  getAllSuppliers() {
    this._supplierService.getAllSuppliers().subscribe({
      next: (res) => {
        if (res.data != null && res.success) {
          this.suppliers.set(res.data);
        }
      },
      error: (err) => {
      }
    });
  }

  ngOnInit() {
    this.getAllProductSuppliers()
    this.getAllSuppliers()
  }
}
