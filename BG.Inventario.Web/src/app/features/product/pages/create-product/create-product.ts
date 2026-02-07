import { Component, inject } from '@angular/core';
import { Navbar } from "../../../../shared/components/navbar/navbar";
import { FormControl, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { RouterLink } from '@angular/router';
import { CreateProductModel } from '../../../../core/models/CreateProduct.model';
import { ProductService } from '../../../../core/services/product/product.service';

@Component({
  selector: 'app-create-product',
  imports: [Navbar, ReactiveFormsModule, CommonModule, RouterLink],
  templateUrl: './create-product.html',
  styleUrl: './create-product.css',
})
export class CreateProduct {

  _productService = inject(ProductService)

  productForm = new FormGroup({
    name: new FormControl('', Validators.required),
    description: new FormControl('', Validators.required),
    statusProduct: new FormControl('', Validators.required),
    stock: new FormControl('', Validators.required),
    salePrice: new FormControl('', Validators.required)
  })

  onSubmit() {
    this.createProduct()
  }

  createProduct() {
    if (this.productForm.valid) {
      const { name, description, statusProduct, stock, salePrice } = this.productForm.value;

        const product = new CreateProductModel(
          name ?? '',
          description ?? '',
          statusProduct ?? 'Disponible',
          Number(stock) ?? 0,
          Number(salePrice) ?? 0
        );

      this._productService.createProduct(product).subscribe({
        next: (resp) => {
          this.productForm.reset();
        },
        error: (err) => {
          console.log("Error al crear producto " + err)
        }
      });
    }
  }
}
