import { Routes } from "@angular/router";

export default [
    {
        path:'',
        loadComponent: () => import('./pages/list-supplier/list-supplier').then(x => x.ListSupplier)
    },
    {
        path:'crear-proveedor',
        loadComponent: () => import('./pages/create-product-supplier/create-product-supplier').then(x => x.CreateProductSupplier)
    },
    {
        path:'lista-productos/:id',
        loadComponent: () => import('./pages/list-product-supplier/products-supplier').then(x => x.ProductsSupllier)
    }
] as Routes