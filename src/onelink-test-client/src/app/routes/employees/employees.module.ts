import { NgModule } from '@angular/core';
import { SharedModule } from '@shared/shared.module';
import { EmployeesRoutingModule } from './employees-routing.module';
import { EmployeesEmployeeListComponent } from './employee-list/employee-list.component';
import { EmployeesEmployeeAddComponent } from './employee-add/employee-add.component';
import { EmployeesEmployeeEditComponent } from './employee-edit/employee-edit.component';

const COMPONENTS = [EmployeesEmployeeListComponent, EmployeesEmployeeAddComponent, EmployeesEmployeeEditComponent];
const COMPONENTS_DYNAMIC = [];

@NgModule({
  imports: [
    SharedModule,
    EmployeesRoutingModule
  ],
  declarations: [
    ...COMPONENTS,
    ...COMPONENTS_DYNAMIC
  ],
  entryComponents: COMPONENTS_DYNAMIC
})
export class EmployeesModule { }
