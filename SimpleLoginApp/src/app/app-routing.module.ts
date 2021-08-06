import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AuthGuard } from './guards/auth-guard.service';

const routes: Routes = [
    {
      path: 'register',
      loadChildren: () => import('./register/register.module').then(m => m.RegisterModule)
    },
    {
      path: 'user/:username',
      canLoad: [AuthGuard],
      canActivate: [ AuthGuard ],
      loadChildren: () => import('./user/user.module').then(m => m.UserModule)
    },
    {
      path: 'cities',
      canLoad: [AuthGuard],
      canActivate: [ AuthGuard ],
      loadChildren: () => import('./cities/cities.module').then(m => m.CitiesModule)
    },
    {
      path: 'login',
      loadChildren: () => import('./login/login.module').then(m => m.LoginModule)
    },
    {
      path: '',
      redirectTo: 'login',
      pathMatch: 'full'
    }
  ];
  
  @NgModule({
    imports: [RouterModule.forRoot(routes)],
    exports: [RouterModule]
  })
  export class AppRoutingModule { }