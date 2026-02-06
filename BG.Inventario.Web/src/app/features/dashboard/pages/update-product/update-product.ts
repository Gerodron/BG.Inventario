import { Component, inject } from '@angular/core';
import { ProductService } from '../../../../core/services/product/product.service';
import { FormControl, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { CreateProductModel } from '../../../../core/models/CreateProduct.model';
import { ActivatedRoute, RouterLink } from '@angular/router';
import { CommonModule } from '@angular/common';
import { Navbar } from "../../../../shared/components/navbar/navbar";

@Component({
  selector: 'app-update-product',
  imports: [ReactiveFormsModule, RouterLink, CommonModule, Navbar],
  templateUrl: './update-product.html',
  styleUrl: './update-product.css',
})
export class UpdateProduct {
  _productService = inject(ProductService)
  _route = inject(ActivatedRoute);

  productForm = new FormGroup({
    name: new FormControl('', Validators.required),
    description: new FormControl('', Validators.required),
    status: new FormControl('', Validators.required),
    stock: new FormControl('', Validators.required),
    salePrice: new FormControl('', Validators.required)
  })

  onSubmit() {
    const id = this._route.snapshot.paramMap.get('id');

    console.log("ID DE UPDATE" + id);

    if (this.productForm.valid) {
      const { name, description, status, stock, salePrice } = this.productForm.value;

      const product = new CreateProductModel(
        name ?? '',
        description ?? '',
        status ?? 'disponible',
        Number(stock) ?? 0,
        Number(salePrice) ?? 0
      );

      // this._productService.createProduct(product).subscribe({
      //   next: (resp) => {
      //     this.productForm.reset();
      //   },
      //   error: (err) => {
      //     console.log("Error al crear producto " + err)
      //   }
      // });
    }
  }
}
