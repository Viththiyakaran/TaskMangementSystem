import { Component, OnInit, ElementRef, AfterViewInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { HttpClient } from '@angular/common/http';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import * as $ from 'jquery';
import 'select2';

@Component({
  selector: 'app-edit-task-management',
  templateUrl: './edit-task-management.component.html',
  styleUrls: ['./edit-task-management.component.css']
})
export class EditTaskManagementComponent implements OnInit, AfterViewInit {
  task: any;
  taskForm!: FormGroup;
  editorContent!: string; // CKEditor content
  //========================================================
  isSuccess: boolean = false;
  businessArray: any[] = [];
  userArray: any[] = [];
  userArray2: any[] = [];
  userArray3: any[] = [];
  selectedCustomer: any;
  selectedBusinessId: any;
  clCustomerId: any;
  selectedUserId: any;
  selectedAssignedUserId: any;
  selectedClosedUserId: any;
  taskArray: any[] = [];
  ticketIdAlert: any;

  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private http: HttpClient,
    private formBuilder: FormBuilder,
    private elementRef: ElementRef
  ) {}

  ngOnInit() {
    const taskId = this.route.snapshot.params['taskId'];
    this.loadTaskDetails(taskId);
    this.loadAllBusiness();
    this.loadAllUsers();
    this.loadAllTasks();
    this.initializeForm();
  }

  loadTaskDetails(taskId: string) {
    const url = `http://localhost:5263/api/CallLog/GetCallLogTaskInfoById/${taskId}`;
    this.http.get(url).subscribe((data: any) => {
      this.task = data;
      console.log('Selected DATA:', data);
    });
  }

  editTask(task: any) {
    // Perform the edit task functionality
    // Redirect to the edit task component or perform any other action
  }

  //----------------------------------------------------------------------//
  onSubmit() {
    const currentDate = new Date().toISOString();

    if (this.taskForm.valid) {
      const formData = {
        ...this.taskForm.value,
        closedDate: currentDate,
        clCustomerId: this.clCustomerId,
        openBy: this.selectedUserId,
        closedBy: this.selectedAssignedUserId,
        assignedTo: this.selectedAssignedUserId,
        lastUpdate: currentDate,
        businessId: this.selectedBusinessId,
        openDate: currentDate, // Set the openDate to the current date
        ticketId: 0, // Set any additional properties if required
      };
      console.log(formData);
      this.http
        .post('http://localhost:5263/api/CallLog/CreateTask', formData)
        .subscribe(
          (response) => {
            console.log('Data saved successfully', response);
            this.taskForm.reset();
            $('#businessId').val('').trigger('change');
            $('#closedBy').val('').trigger('change');
            $('#openBy').val('').trigger('change');
            $('#assignedTo').val('').trigger('change');
            this.isSuccess = true;
            if (this.isSuccess) {
              // Perform any action after successful form submission
            }
          },
          (error) => {
            console.error('Error saving data', error);
          }
        );
    }
  }

  loadAllBusiness() {
    this.http
      .get('http://localhost:5263/api/Business/BusinessInfo')
      .subscribe(
        (res: any) => {
          this.businessArray = res;
          console.log(res);
        },
        (error) => {
          console.error('Error loading business', error);
        }
      );
  }

  async loadAllTasks() {
    try {
      const res = await this.http
        .get('http://localhost:5263/api/CallLog/GetAllCallLogTaskInfo')
        .toPromise();
      this.taskArray = res as any[];
      console.log(res);
    } catch (error) {
      console.error('Error loading tasks', error);
    }
  }

  loadAllUsers() {
    this.http
      .get('http://localhost:5263/api/User/GetAllUserInfo')
      .subscribe(
        (res: any) => {
          this.userArray = res;
          this.userArray2 = res;
          this.userArray3 = res;
          console.log(res);
        },
        (error) => {
          console.error('Error loading users', error);
        }
      );
  }

  onBusinessIdSelected(event: Event) {
    const target = event.target as HTMLSelectElement;
    const businessId = target.value;
    if (businessId) {
      this.selectedCustomer = this.businessArray.find(
        (option) => option.businessId === businessId
      );
      this.clCustomerId = this.selectedCustomer.clCustomerId;

      // Assign the selected businessId to the form control
      this.taskForm.patchValue({
        businessId: businessId,
      });
    }
  }

  onOpenBySelected(event: Event) {
    const target = event.target as HTMLSelectElement;
    const userId = target.value;
    if (userId) {
      // Assign the selected userId to the form control
      this.taskForm.patchValue({
        openBy: userId,
      });
    }
  }

  onAssignedToSelected(event: Event) {
    const target = event.target as HTMLSelectElement;
    const userId = target.value;
    if (userId) {
      // Assign the selected userId to the form control
      this.taskForm.patchValue({
        assignedTo: userId,
      });
    }
  }

  onClosedBySelected(event: Event) {
    const target = event.target as HTMLSelectElement;
    const userId = target.value;
    if (userId) {
      // Assign the selected userId to the form control
      this.taskForm.patchValue({
        closedBy: userId,
      });
    }
  }

  ngAfterViewInit(): void {
    // Initialize Select2 inside the ngAfterViewInit method
    setTimeout(() => {
      $('#businessId').select2();
      $('#openBy').select2();
      $('#assignedTo').select2();
      $('#closedBy').select2();

      $('#closedBy').on('change', (event) => {
        this.selectedClosedUserId = $(event.target).val();
        console.log('Selected value:', this.selectedClosedUserId);
      });

      $('#openBy').on('change', (event) => {
        this.selectedUserId = $(event.target).val();
        console.log('Selected value:', this.selectedUserId);
      });

      $('#assignedTo').on('change', (event) => {
        this.selectedAssignedUserId = $(event.target).val();
        console.log('Selected value:', this.selectedAssignedUserId);
      });

      $('#businessId').on('change', (event) => {
        this.selectedBusinessId = $(event.target).val();
        console.log('Selected value:', this.selectedBusinessId);

        // Retrieve customer information based on the selected business ID
        if (this.selectedBusinessId) {
          this.http
            .get(
              `http://localhost:5263/api/Business/BusinessInfo/${this.selectedBusinessId}`
            )
            .subscribe(
              (response: any) => {
                // Assuming the customer ID is stored in the response as `customerId`
                const customerId = response.customerId;
                console.log('Customer ID:', customerId);

                // You can perform further operations with the customer ID, such as assigning it to a variable
                this.clCustomerId = customerId;
              },
              (error) => {
                console.error(
                  'Error retrieving customer information',
                  error
                );
              }
            );
        }
      });
    }, 0);
  }


  initializeForm() {
    this.taskForm = this.formBuilder.group({
      ticketId: [''],
      callType: [''],
      businessType: ['Registered'],
      businessId: [''],
      serviceType: [''],
      openDate: [''],
      openBy: [''],
      assignedTo: [''],
      appointmentDate: [''],
      appointmentType: [''],
      status: ['Open'],
      lastUpdate: [''],
      closedDate: [''],
      closedBy: [''],
      initialNote: [''],
      clCustomerId: ['']
    });
  }
}
