import { FormBuilder, FormGroup } from '@angular/forms';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-employees-employee-add',
  templateUrl: './employee-add.component.html',
  styleUrls: ['./employee-add.component.scss']
})
export class EmployeesEmployeeAddComponent implements OnInit {

  employeeForm: FormGroup;

  constructor(private formBuilder: FormBuilder) {
    this.employeeForm = this.formBuilder.group({
      document: [''],
      documentType: [''],
      firstName: [''],
      lastName: [''],
    });
  }

  ngOnInit() {
  }

}
