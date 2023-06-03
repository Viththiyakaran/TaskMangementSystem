import { Component, OnInit,AfterViewInit  } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { HttpClient } from '@angular/common/http';
import * as $ from 'jquery';
import 'select2';


@Component({
  selector: 'app-create-task-management',
  templateUrl: './create-task-management.component.html',
  styleUrls: ['./create-task-management.component.css']
})
export class CreateTaskManagementComponent implements OnInit, AfterViewInit {
  taskForm!: FormGroup;
  businessArray: any[] = [];

  constructor(private formBuilder: FormBuilder, private http: HttpClient) {}

  ngOnInit() {
    this.initializeForm();
    this.loadAllBusiness();
  }

  ngAfterViewInit(): void {
    // Use setTimeout to ensure the DOM is fully rendered before initializing Select2
    setTimeout(() => {
      $('#businessId').select2();
    });
  }
  initializeForm() {
    this.taskForm = this.formBuilder.group({
      // ticketId: ['', Validators.required],
      callType: [''],
      businessType: [''],
      businessId: ['', Validators.required],
      serviceType: [''],
      openDate: ['', Validators.required],
      openBy: [''],
      assignedTo: [''],
      appointmentDate: [''],
      appointmentType: [''],
      status: [''],
      lastUpdate: [''],
      closedDate: [''],
      closedBy: [''],
      initialNote: [''],
      clCustomerId: ['']
    });
  }

  onSubmit() {

    console.log(this.taskForm.value);

    if (this.taskForm.valid) {
      const formData = { ...this.taskForm.value };

      // Perform API request with form data
      this.http.post('http://localhost:5263/api/CallLog/CreateTask', formData)
        .subscribe(
          response => {
            console.log('Data saved successfully', response);
            this.taskForm.reset();
          },
          error => {
            console.error('Error saving data', error);
          }
        );
    }
  }

  loadAllBusiness() {
    this.http.get("http://localhost:5263/BusinessInfo")
      .subscribe(
        (res: any) => {
          this. businessArray = res;
          console.log(res);
        },
        error => {
          console.error('Error loading tasks', error);
        }
      );
  }
}
