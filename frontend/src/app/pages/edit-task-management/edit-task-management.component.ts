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

  //========================================================
  taskNotes: any[] = [];

  public readOnlyConfig = {
    readOnly: true,
    toolbar: null, // Disable toolbar
    removePlugins: 'toolbar', // Remove unwanted plugins
    extraPlugins: 'image',
    removeButtons: 'Image',
    allowedContent: 'img[src]', // Allow only image elements with src attribute

  };


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
    this.loadNotesById(taskId);

  }

  loadNotesById(taskId: string) {
    const url = `http://localhost:5263/api/CallLog/GetCallLogTaskNotesInfo/${taskId}`;
    this.http.get(url).subscribe((response: any) => {
        this.taskNotes = response;
        console.log('Task notes information:', this.taskNotes);
        // Handle the task notes information in your component logic
      },
      (error) => {
        console.error('Error retrieving task notes information:', error);
        // Handle the error case
      });
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

  ngAfterViewInit(): void {
    // Initialize Select2 inside the ngAfterViewInit method
    setTimeout(() => {
      $('#businessId').select2();
      $('#businessId').val(this.task[0].businessId).trigger('change');
      $('#assignedTo').select2();
      $('#assignedTo').val(this.task[0].assignedTo).trigger('change');
      $('#closedBy').select2();
      $('#closedBy').val(this.task[0].closedBy).trigger('change');



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
      closedBy:  this.selectedClosedUserId,
      initialNote: [''],
      clCustomerId: ['']
    });
  }
  onSubmit() {
    const currentDate = new Date().toISOString();
    let cDateUpdate;
    if (this.taskForm.status.includes('Completed')) {
      cDateUpdate =currentDate;
    }
    else{
      cDateUpdate =this.task[0].appointmentDate;
    }

    if (this.taskForm.valid) {
      const formData: FormGroup = this.taskForm;
      // const selectedClosedUserId = this.taskForm.value.closedBy;

      const updatedTask = {
        ...formData.value,
        ticketId: this.task[0].ticketId,
        callType: this.task[0].callType,
        businessType: 'Registered',
        businessId: this.task[0].businessId,
        serviceType: this.task[0].serviceType,
        openDate: this.task[0].openDate,
        openBy: this.task[0].openBy,
        assignedTo:this.task[0].assignedTo,
        appointmentDate: this.task[0].appointmentDate,
        appointmentType: this.task[0].appointmentType,
        status: this.taskForm.value.status,
        lastUpdate: currentDate,
        closedDate: cDateUpdate,
        closedBy: this.selectedClosedUserId === undefined ? this.task[0].closedBy : this.selectedClosedUserId,
        initialNote: this.task[0].initialNote,
        clCustomerId: this.task[0].clCustomerId,
      };

      const taskId = this.route.snapshot.params['taskId'];
      const url = `http://localhost:5263/api/CallLog/PutCallLogTaskInfo/${taskId}`;
      this.http.put(url, updatedTask).subscribe(
        (response: any) => {
          console.log('Task updated successfully:', response);
          // Perform any other actions after successful update
        },
        (error) => {
          console.error('Error updating task:', error);
          // Handle the error case
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



}
