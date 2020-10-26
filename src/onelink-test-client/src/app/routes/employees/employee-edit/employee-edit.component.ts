import { Subarea } from './../../../shared/models/subarea';
import { ChangeDetectorRef, Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { Area } from '@shared/models/area';
import { DOCUMENT_TYPES } from '@shared/models/document-type';
import { Employee } from '@shared/models/employee';
import { AreaService } from '@shared/services/area.service';
import { EmployeeService } from '@shared/services/employee.service';

@Component({
  selector: 'app-employees-employee-edit',
  templateUrl: './employee-edit.component.html',
  styleUrls: ['./employee-edit.component.scss'],
})
export class EmployeesEmployeeEditComponent implements OnInit {
  employeeForm: FormGroup;
  documentTypes = DOCUMENT_TYPES;
  isLoading = false;
  areas: Area[] = [];
  employeeId: number;
  subareas: Subarea[] = [];
  selectedArea: Area;

  constructor(
    private formBuilder: FormBuilder,
    private changeDetector: ChangeDetectorRef,
    private employeeService: EmployeeService,
    private areaService: AreaService,
    private router: Router,
    private route: ActivatedRoute
  ) {
    this.employeeForm = this.formBuilder.group({
      document: [''],
      documentType: [''],
      firstName: [''],
      lastName: [''],
      areaId: [''],
      subareaId: [''],
    });
  }

  ngOnInit() {
    this.route.params.subscribe(async params => {
      this.areas = await this.areaService.getAreas();
      this.changeDetector.detectChanges();
      this.employeeId = params.employeeId;
      await this.populateEmployee(this.employeeId);
    });
  }

  async populateEmployee(employeeId: number) {
    const employee = await this.employeeService.getEmployee(employeeId);
    const area = this.areas.find(a => a.subareas.findIndex(s => s.subareaId === employee.subareaId) > -1);

    if (area) {
      this.subareas = area.subareas;
      this.changeDetector.detectChanges();
    }

    this.employeeForm.setValue({
      document: employee.document,
      documentType: employee.documentType,
      firstName: employee.firstName,
      lastName: employee.lastName,
      subareaId: employee.subareaId,
      areaId: area.areaId,
    });
  }

  onSubmit(value) {
    this.isLoading = true;
    const employee: Employee = {
      document: +value.document,
      documentType: +value.documentType,
      firstName: value.firstName,
      lastName: value.lastName,
      subareaId: 1,
    };
    this.employeeService
      .updateEmployee(this.employeeId, employee)
      .then(r => {
        this.router.navigate(['employees']);
      })
      .catch(e => console.log(e))
      .finally(() => (this.isLoading = false));
  }

  onSelectedAreaChange(e: number) {
    const area = this.areas.find(a => a.areaId === e);

    if (area) {
      this.subareas = area.subareas;
    } else {
      this.subareas = [];
    }
  }
}
