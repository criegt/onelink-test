import { Employee } from './../models/employee';
import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class EmployeeService {

  constructor(private http: HttpClient) { }

  getEmployees(params = {}): Promise<Employee[]> {
    return this.http.get<Employee[]>('api/v1/employees', { params }).toPromise();
  }

  getEmployee(employeeId: number): Promise<Employee> {
    return this.http.get<Employee>(`api/v1/employees/${employeeId}`).toPromise();
  }

  updateEmployees(employeeId: number, employee: Employee): Promise<any> {
    return this.http.put(`api/v1/employees/${employeeId}`, employee).toPromise();
  }

  addEmployees(employee: Employee): Promise<any> {
    return this.http.post('api/v1/employees', employee).toPromise();
  }
}
