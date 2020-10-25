import { EmployeeService } from './../../../shared/services/employee.service';
import { Employee } from './../../../shared/models/employee';
import { Component, OnInit, ChangeDetectorRef } from '@angular/core';
import { MtxGridColumn } from '@ng-matero/extensions';
import { PageEvent } from '@angular/material/paginator';

@Component({
  selector: 'app-employees-employee-list',
  templateUrl: './employee-list.component.html',
  styleUrls: ['./employee-list.component.scss'],
})
export class EmployeesEmployeeListComponent implements OnInit {
  columns: MtxGridColumn[] = [
    { header: 'Document Type', field: 'documentType' },
    { header: 'Document', field: 'document' },
    { header: 'First Name', field: 'firstName' },
    { header: 'LastName', field: 'lastName' },
  ];
  total = 0;
  isLoading = true;
  query = {
    searchTerms: '',
    pageIndex: 0,
    pageSize: 10,
  };

  employees: Employee[] = [];

  constructor(
    private employeeService: EmployeeService,
    private changeDetector: ChangeDetectorRef
  ) {}

  ngOnInit() {
    this.loadEmployees();
  }

  loadEmployees() {
    this.isLoading = true;
    this.employeeService.getEmployees(this.query).then(e => {
      this.employees = e;
      this.isLoading = false;
      this.changeDetector.detectChanges();
    }).catch(r => console.log(r));
  }

  nextPage(e: PageEvent) {
    this.query.pageIndex = e.pageIndex;
    this.query.pageSize = e.pageSize;
    this.loadEmployees();
  }

  search() {
    this.query.pageIndex = 0;
    this.loadEmployees();
  }
}
