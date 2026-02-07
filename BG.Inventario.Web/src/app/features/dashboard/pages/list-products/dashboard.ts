import { Component, inject, signal, WritableSignal } from '@angular/core';
import { Navbar } from '../../../../shared/components/navbar/navbar';
import { IProduct } from '../../../../core/interfaces/product.interface';
import { ProductService } from '../../../../core/services/product/product.service';
import { Router, RouterLink } from "@angular/router";


@Component({
  selector: 'app-dashboard',
  imports: [Navbar, RouterLink],
  templateUrl: './dashboard.html',
  styleUrl: './dashboard.css',
})
export class ListProducts {
  products: WritableSignal<IProduct[]> = signal([])

  _productService = inject(ProductService)
  _router = inject(Router)

  ngOnInit() {
    this.getAllProduct()
  }

  getAllProduct() {
    this._productService.getAllProducts().subscribe({
      next: (res) => {

        if (res.data != null && res.success) {
          console.log(res.data)
          this.products.set(res.data);
        } 
      },
      error: (err) => {
        console.error('API ERROR:', err);
      },
      complete: () => {
        console.log('getAllProducts() completed');
      }
    });
  }


}
