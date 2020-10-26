import { DOCUMENT_TYPES } from './../../../shared/models/document-type';
import { EmployeeService } from './../../../shared/services/employee.service';
import { Employee } from './../../../shared/models/employee';
import { Component, OnInit, ChangeDetectorRef } from '@angular/core';
import { MtxGridColumn } from '@ng-matero/extensions';
import { PageEvent } from '@angular/material/paginator';
import { Router } from '@angular/router';

@Component({
  selector: 'app-employees-employee-list',
  templateUrl: './employee-list.component.html',
  styleUrls: ['./employee-list.component.scss'],
})
export class EmployeesEmployeeListComponent implements OnInit {
  columns: MtxGridColumn[] = [
    { header: 'Document type', field: 'documentType', formatter: (data: any) => DOCUMENT_TYPES[data.documentType].name },
    { header: 'Document', field: 'document' },
    { header: 'First name', field: 'firstName' },
    { header: 'Last name', field: 'lastName' },
    {
      header: 'Edit',
      field: 'employeeId',
      pinned: 'right',
      type: 'button',
      buttons: [
        {
          type: 'icon',
          text: 'edit',
          icon: 'edit',
          tooltip: 'Edit',
          click: record => this.router.navigate([ `employees/${record.employeeId}/edit` ]),
        },
      ],
    },
  ];
  total = 20;
  isLoading = true;
  query = {
    searchTerms: '',
    pageIndex: 0,
    pageSize: 10,
  };

  employees: Employee[] = [];

  constructor(
    private employeeService: EmployeeService,
    private changeDetector: ChangeDetectorRef,
    private router: Router
  ) {}

  ngOnInit() {
    this.loadEmployees();
  }

  loadEmployees() {
    this.isLoading = true;
    this.employeeService.getEmployees(this.query).then(e => {
      this.employees = e.employees;
      this.total = e.totalCount;
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

  navigateToAdd(){
    this.router.navigate(['employees/add']);
  }
}
