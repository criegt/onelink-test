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
    return this.http.get<Employee[]>('employees', { params }).toPromise();
  }
}
