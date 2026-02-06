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

  getAllProduct() {
    console.log('CALL getAllProduct');

    this._productService.getAllProducts().subscribe({
      next: (res) => {

        if (res.data != null && res.success) {
          this.products.set(res.data);
        } else {
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

  updateProductById() {
    // const product: IProduct | undefined = this.products().find(x => x.productId == id)
    // if (product != undefined) {
    //   this._productService.updateProductById(product).subscribe({
    //     next: ({success}) => {
    //       if(success){
    //         // console.log("ACTUALIZCION EXTIOSA")
    //       }
    //     },
    //     error: (err) => {

    //     }
    //   })
    // }
    console.log("updateProductById")
    this._router.navigate(['./editar-producto'])
  }

  ngOnInit() {
    this.getAllProduct()
  }
}
