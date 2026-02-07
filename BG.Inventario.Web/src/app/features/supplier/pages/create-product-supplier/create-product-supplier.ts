import { Component, inject } from '@angular/core';
import { Navbar } from "../../../../shared/components/navbar/navbar";
import { FormControl, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { RouterLink } from '@angular/router';
import { SupplierService } from '../../../../core/services/supplier/supplier.service';
import { CreateSupplierModel } from '../../../../core/models/CreateSupplier.model';

@Component({
  selector: 'app-create-product-supplier',
  imports: [Navbar, ReactiveFormsModule, CommonModule, RouterLink],
  templateUrl: './create-product-supplier.html',
  styleUrl: './create-product-supplier.css',
})
export class CreateProductSupplier {

  _supplierService = inject(SupplierService)

  supplierForm = new FormGroup({
    name: new FormControl('', Validators.required),
    email: new FormControl('', Validators.required),
  })

  onSubmit() {
    this.createSupplier()
  }

  createSupplier() {
    console.log("HHOLA")
    if (this.supplierForm.valid) {
      const { name, email } = this.supplierForm.value;
      const product = new CreateSupplierModel(
        name ?? '',
        email ?? ''
      );

      this._supplierService.createSupplier(product).subscribe({
        next: (response) => {
          this.supplierForm.reset();
        },
        error: (err) => {
          console.log("Error al crear producto " + err)
        }
      })
    }
  }
}
