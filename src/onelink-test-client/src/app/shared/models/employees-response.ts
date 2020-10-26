import { Employee } from './employee';

export interface EmployeesResponse {
  employees: Employee[];
  totalCount: number;
}
