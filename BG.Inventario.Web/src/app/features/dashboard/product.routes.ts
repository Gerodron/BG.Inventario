import { Routes } from '@angular/router';


export default [
    {
        path: '',
        loadComponent: () => import('./pages/list-products/dashboard').then(x => x.ListProducts),
    },
    {
        path: 'crear-producto',
        loadComponent: () => import('./pages/create-product/create-product').then(x => x.CreateProduct)
    },
    {
        path:'editar-producto/:id',
        loadComponent: () => import('./pages/update-product/update-product').then(x =>x.UpdateProduct)
    }
] as Routes