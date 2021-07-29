import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import {CitiesComponent} from './cities/cities.component'
import {LoginComponent} from './login/login.component'
import { RegisterComponent } from './register/register.component';
import { UserComponent } from './user/user.component';

const routes: Routes = [
    {path:'cities', component:CitiesComponent},
    {path:'user/:username', component:UserComponent},
    {path:'', component:LoginComponent},
    {path:'register', component:RegisterComponent}
  ];
  
  @NgModule({
    imports: [RouterModule.forRoot(routes)],
    exports: [RouterModule]
  })
  export class AppRoutingModule { }