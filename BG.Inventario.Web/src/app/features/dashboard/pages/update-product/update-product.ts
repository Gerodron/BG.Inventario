import { Component, inject, signal, WritableSignal } from '@angular/core';
import { ProductService } from '../../../../core/services/product/product.service';
import { FormControl, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { CreateProductModel } from '../../../../core/models/CreateProduct.model';
import { ActivatedRoute, RouterLink } from '@angular/router';
import { CommonModule } from '@angular/common';
import { Navbar } from "../../../../shared/components/navbar/navbar";
import { IProduct } from '../../../../core/interfaces/product.interface';

@Component({
  selector: 'app-update-product',
  imports: [ReactiveFormsModule, RouterLink, CommonModule, Navbar],
  templateUrl: './update-product.html',
  styleUrl: './update-product.css',
})
export class UpdateProduct {
  _productService = inject(ProductService)
  _route = inject(ActivatedRoute);

  product: WritableSignal<IProduct> = signal({} as IProduct)

  productForm = new FormGroup({
    name: new FormControl('', Validators.required),
    description: new FormControl('', Validators.required),
    status: new FormControl('', Validators.required),
    stock: new FormControl(0, Validators.required),
    salePrice: new FormControl(0, Validators.required)
  })

  ngOnInit() {
    this.completeDataForm()
  }

  onSubmit() {
    if(this.productForm.valid){
      const product : IProduct = {
        ...this.product(),
        ...this.productForm.value
      } as IProduct

      this.updateProduct(product)
    }
  }

  updateProduct(product : IProduct) {
    
    this._productService.updateProductById(product).subscribe({
      next: ({ success }) => {
        if (success) {
          console.log("ACTUALIZCION EXTIOSA")
        }
      },
      error: (err) => {

      }
    })
  }
  completeDataForm() {
    const id = this._route.snapshot.paramMap.get('id') ?? '0';
    const idint = parseInt(id)

    this._productService.getProductById(idint).subscribe({
      next: (response) => {
        const data = response.data;
        if (data) {
          this.product.set(data)
          this.productForm.patchValue(data)
        }
      }
    })
  }
}