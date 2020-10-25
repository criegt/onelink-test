export interface Employee {
  employeeId: number;
  documentType: number;
  document: number;
  firstName: string;
  lastName: string;
  subareaId: number;
  subarea?: object;
}
