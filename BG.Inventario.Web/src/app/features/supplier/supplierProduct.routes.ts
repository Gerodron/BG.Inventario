import { Routes } from "@angular/router";

export default [
    {
        path:'',
        loadComponent: () => import('./pages/list-product-supplier/products-supplier').then(x => x.ProductsSupllier)
    }
] as Routes