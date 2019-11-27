import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from "@angular/forms";
import { ApiService } from "../core/api.service";

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
})
export class HomeComponent {
  disabledButton: boolean = false;
  invalidData: boolean = false;
  queryEmployeesForm: FormGroup;
  errorMessage: string = "";
  employees: Employee[];

  constructor(private formBuilder: FormBuilder, private apiService: ApiService) { }

  onSubmit() {
    let employeeid = this.queryEmployeesForm.controls.employeeId.value;

    this.disabledButton = true;
    this.invalidData = false;

    if (this.queryEmployeesForm.controls.employeeId.value == "") {
      this.apiService.getEmployees().subscribe(data => {
        if (data.Status === 200) {
          //alert(data.Message);

          this.employees = data.Result;
          this.disabledButton = false;

        } else {
          this.employees = [];
          this.invalidData = true;
          this.errorMessage = data.Message;
          this.disabledButton = false;
        }
      });
    } else {
      this.apiService.getEmployee(employeeid).subscribe(data => {
        if (data.Status === 200) {
          //alert(data.Message);
          this.disabledButton = false;

          this.employees = [data.Result];

        } else {
          this.employees = [];
          this.invalidData = true;
          this.errorMessage = data.Message;
          this.disabledButton = false;
        }
      }, error => {
          this.disabledButton = false;

      });
    }
  }

  ngOnInit() {

    this.queryEmployeesForm = this.formBuilder.group({
      employeeId: ['', Validators.maxLength(9)]
    });

  }

  numberOnly(event): boolean {
    const charCode = (event.which) ? event.which : event.keyCode;
    if (charCode > 31 && (charCode < 48 || charCode > 57)) {
      return false;
    }
    return true;

  }
}
