import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { EmployeesEmployeeListComponent } from './employee-list/employee-list.component';
import { EmployeesEmployeeAddComponent } from './employee-add/employee-add.component';

const routes: Routes = [
  // { path: '', redirectTo: 'employee-list', pathMatch: 'full' },
  { path: '', component: EmployeesEmployeeListComponent },
  { path: 'add', component: EmployeesEmployeeAddComponent }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class EmployeesRoutingModule { }
