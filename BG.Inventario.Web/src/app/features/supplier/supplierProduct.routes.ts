import { Routes } from "@angular/router";

export default [
    {
        path:'',
        loadComponent: () => import('./pages/list-product-supplier/products-supplier').then(x => x.ProductsSupllier)
    },
    {
        path:'crear-proveedor',
        loadComponent: () => import('./pages/create-product-supplier/create-product-supplier').then(x => x.CreateProductSupplier)
    }
] as Routes