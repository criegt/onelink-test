import { AreaService } from './../../../shared/services/area.service';
import { Router } from '@angular/router';
import { EmployeeService } from './../../../shared/services/employee.service';
import { Employee } from './../../../shared/models/employee';
import { DOCUMENT_TYPES } from './../../../shared/models/document-type';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ChangeDetectorRef, Component, OnInit } from '@angular/core';
import { Area } from '@shared/models/area';
import { Subarea } from '@shared/models/subarea';

@Component({
  selector: 'app-employees-employee-add',
  templateUrl: './employee-add.component.html',
  styleUrls: ['./employee-add.component.scss']
})
export class EmployeesEmployeeAddComponent implements OnInit {

  employeeForm: FormGroup;
  documentTypes = DOCUMENT_TYPES;
  isLoading = false;
  areas: Area[] = [];
  subareas: Subarea[] = [];
  selectedArea: Area;

  constructor(private formBuilder: FormBuilder,
              private changeDetector: ChangeDetectorRef,
              private employeeService: EmployeeService,
              private areaService: AreaService,
              private router: Router) {
    this.employeeForm = this.formBuilder.group({
      document: [''],
      documentType: [''],
      firstName: [''],
      lastName: [''],
      subareaId: [''],
    });
  }

  ngOnInit() {
    this.areaService.getAreas().then(a => {
      this.areas = a;
      this.changeDetector.detectChanges();
    });
  }

  onSubmit(value) {
    this.isLoading = true;
    const employee: Employee = {
      document: +value.document,
      documentType: +value.documentType,
      firstName: value.firstName,
      lastName: value.lastName,
      subareaId: +value.subareaId
    };
    console.log(employee);
    this.employeeService.addEmployee(employee)
      .then(r => {
        this.router.navigate(['employees']);
      })
      .catch(e => console.log(e))
      .finally(() => this.isLoading = false);
  }

  onSelectedAreaChange(e) {
    if (e) {
      this.subareas = e.subareas;
    } else {
      this.subareas = [];
    }
  }
}
