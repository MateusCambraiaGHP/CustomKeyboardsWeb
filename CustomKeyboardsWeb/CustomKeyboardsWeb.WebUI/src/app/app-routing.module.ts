import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CustomerFormComponent } from './components/customer/customer-form/customer-form.component';
import { TableCustomersComponent } from './components/customer/table-customers/table-customers.component';
import { FormComponent } from './components/generics/form/form.component';

const routes: Routes = [
    { path: '', component: TableCustomersComponent },
    {
        path: 'form-customer/:id', // Defina o nome do parâmetro precedido por ':' na URL da rota
        component: CustomerFormComponent
      }
  ];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
