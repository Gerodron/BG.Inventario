import { Routes } from '@angular/router';
import { authGuard } from './core/guards/auth.guard';

export const routes: Routes = [
    {
        path: 'login',
        loadComponent: () => import('./features/auth/login/login').then(x => x.Login)
    },
    {
        path: 'productos',
        loadChildren: () => import('./features/dashboard/product.routes'),
        canActivate: [authGuard]
    },
    {
        path: 'proveedores',
        loadComponent: () => import('./features/products-supllier/products-supllier').then(x => x.ProductsSupllier),
        canActivate: [authGuard]
    },
    {
        path:'sesion-expirada',
        loadComponent: () => import('./shared/pages/session-expired-page/session-expired-page').then(x => x.SessionExpiredPage)
    },
    {
        path: '',
        pathMatch: 'full',
        redirectTo: 'login'
    }, 
    {
        path: '**',
        redirectTo: 'login'
    }
];
