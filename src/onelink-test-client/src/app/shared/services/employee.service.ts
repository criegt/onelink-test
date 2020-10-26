import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { EmployeesResponse } from '@shared/models/employees-response';
import { Employee } from '@shared/models/employee';

@Injectable({
  providedIn: 'root'
})
export class EmployeeService {

  constructor(private http: HttpClient) { }

  getEmployees(params = {}): Promise<EmployeesResponse> {
    return this.http.get<EmployeesResponse>('api/v1/employees', { params }).toPromise();
  }

  getEmployee(employeeId: number): Promise<Employee> {
    return this.http.get<Employee>(`api/v1/employees/${employeeId}`).toPromise();
  }

  updateEmployee(employeeId: number, employee: Employee): Promise<any> {
    return this.http.put(`api/v1/employees/${employeeId}`, employee).toPromise();
  }

  addEmployee(employee: Employee): Promise<any> {
    console.log(employee);

    return this.http.post('api/v1/employees', employee).toPromise();
  }
}
