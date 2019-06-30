import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import {HomeComponent} from './home/home.component';
import {ProductsComponent} from './products/products.component';
import {LoginComponent} from './login/login.component';
import {RegisterComponent} from './register/register.component';



const routes: Routes = [];

@NgModule({
  imports: [RouterModule.forRoot([
    {path:"" , component:HomeComponent ,pathMatch:"full"},
    {path:"home", component:HomeComponent},
    
    {path:"register" , component:RegisterComponent},
    {path:"products", component:ProductsComponent},
    {path:"login", component:LoginComponent},
    {path:"**", component:HomeComponent }

  ])],
  exports: [RouterModule]
})
export class AppRoutingModule { }
