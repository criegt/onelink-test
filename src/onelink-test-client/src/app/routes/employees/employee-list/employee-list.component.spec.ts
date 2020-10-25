import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { EmployeesEmployeeListComponent } from './employee-list.component';

describe('EmployeeListComponent', () => {
  let component: EmployeesEmployeeListComponent;
  let fixture: ComponentFixture<EmployeesEmployeeListComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ EmployeesEmployeeListComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(EmployeesEmployeeListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
