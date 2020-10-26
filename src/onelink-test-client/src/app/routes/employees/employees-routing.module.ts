import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { EmployeesEmployeeListComponent } from './employee-list/employee-list.component';
import { EmployeesEmployeeAddComponent } from './employee-add/employee-add.component';
import { EmployeesEmployeeEditComponent } from './employee-edit/employee-edit.component';

const routes: Routes = [
  { path: '', component: EmployeesEmployeeListComponent },
  { path: 'add', component: EmployeesEmployeeAddComponent },
  { path: ':employeeId/edit', component: EmployeesEmployeeEditComponent }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class EmployeesRoutingModule { }
