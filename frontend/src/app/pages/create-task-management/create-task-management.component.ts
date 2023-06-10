import { Component, OnInit, AfterViewInit,ElementRef } from '@angular/core';
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
  isSuccess: boolean = false;
  taskForm!: FormGroup;
  businessArray: any[] = [];
  userArray: any[] = [];
  userArray2: any[] = [];
  userArray3: any[] = [];
  selectedCustomer: any;
  selectedBusinessId: any;
  clCustomerId: any;
  selectedUserId : any;
  selectedAssignedUserId : any;
  selectedClosedUserId : any;
  taskArray: any[] = [];
  ticketIdAlert : any;


  p: number = 1; // Declare the 'p' property for pagination
  key: string = 'id'; // Default sort key
  reverse: boolean = false;
  constructor(private formBuilder: FormBuilder, private http: HttpClient,private elementRef: ElementRef) {}

  ngOnInit() {

    // var s = document.createElement("script");
    // s.type = "text/javascript";
    // s.src = "../assets/js/main.js";
    // this.elementRef.nativeElement.appendChild(s);

    this.initializeForm();
    this.loadAllBusiness();
    this.loadAllUsers();
    this.loadAllTasks();


  }

  Sort(key: string): void {
    this.key = key;
    this.reverse = !this.reverse;

    this.taskArray.sort((a, b) => {
      const valA = a[key];
      const valB = b[key];

      if (valA < valB) {
        return this.reverse ? 1 : -1;
      }
      if (valA > valB) {
        return this.reverse ? -1 : 1;
      }
      return 0;
    });
  }

  getSortIcon(key: string): string {
    if (this.key === key) {
      return this.reverse ? 'bi bi-sort-up' : 'bi bi-sort-down';
    }
    return 'bi bi-filter';
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

  onBusinessIdSelected(event: Event) {
    const target = event.target as HTMLSelectElement;
    const businessId = target.value;
    if (businessId) {
      this.selectedCustomer = this.businessArray.find(option => option.businessId === businessId);
      this.clCustomerId = this.selectedCustomer.clCustomerId;

      // Assign the selected businessId to the form control
      this.taskForm.patchValue({
        businessId: businessId
      });
    }
  }


  onOpenBySelected(event: Event) {
    const target = event.target as HTMLSelectElement;
    const userId = target.value;
    if (userId) {
      // Assign the selected businessId to the form control
      this.taskForm.patchValue({
        userId: userId
      });
    }
  }

  onAssignedToSelected(event: Event) {
    const target = event.target as HTMLSelectElement;
    const userId = target.value;
    if (userId) {
      // Assign the selected businessId to the form control
      this.taskForm.patchValue({
        userId: userId
      });
    }
  }

  onClosedBySelected(event: Event) {
    const target = event.target as HTMLSelectElement;
    const userId = target.value;
    if (userId) {
      // Assign the selected businessId to the form control
      this.taskForm.patchValue({
        userId: userId
      });
    }
  }

  ngAfterViewInit(): void {
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
            this.http.get(`http://localhost:5263/api/Business/BusinessInfo/${this.selectedBusinessId}`)
              .subscribe(
                (response: any) => {
                  // Assuming the customer ID is stored in the response as `customerId`
                  const customerId = response.customerId;
                  console.log('Customer ID:', customerId);

                  // You can perform further operations with the customer ID, such as assigning it to a variable
                  this.clCustomerId = customerId;
                },
                error => {
                  console.error('Error retrieving customer information', error);
                }
              );
          }
    });
  }

  onSubmit() {
    const currentDate = new Date().toISOString();

    if (this.taskForm.valid) {
      const formData = {
        ...this.taskForm.value,
        closedDate: currentDate,
        clCustomerId :this.clCustomerId,
        openBy: this.selectedUserId,
        closedBy : this.selectedAssignedUserId,
        assignedTo: this.selectedAssignedUserId,
        lastUpdate: currentDate,
        businessId: this.selectedBusinessId,
        openDate: currentDate, // Set the openDate to the current date
        ticketId: 0, // Set any additional properties if required
      };
      console.log(formData)
      this.http.post('http://localhost:5263/api/CallLog/CreateTask', formData)
        .subscribe(
          response => {
            console.log('Data saved successfully', response);
            this.taskForm.reset();
            $('#businessId').val('').trigger('change');
            $('#closedBy').val('').trigger('change');
            $('#openBy').val('').trigger('change');
            $('#assignedTo').val('').trigger('change');
            this.isSuccess = true;
            if (this.isSuccess) {
              this.getGeneratedTicketId();
              this.loadAllTasks(); // Refresh the tasks
            }
          },
          error => {
            console.error('Error saving data', error);
          }
        );
    }
  }

  getGeneratedTicketId() {
    this.http.get<string>('http://localhost:5263/api/CallLog/GenerateTicketId')
      .subscribe((id: string) => {
        // Assign the fetched ID to a variable or display it directly
        this.ticketIdAlert = id;
      });
  }

  loadAllBusiness() {
    this.http.get("http://localhost:5263/api/Business/BusinessInfo")
      .subscribe(
        (res: any) => {
          this.businessArray = res;
          console.log(res);
        },
        error => {
          console.error('Error loading business', error);
        }
      );
  }

  async loadAllTasks() {
    try {
      const res = await this.http.get("http://localhost:5263/api/CallLog/GetAllCallLogTaskInfo").toPromise();
      this.taskArray = res as any[];
      console.log(res);
    } catch (error) {
      console.error('Error loading tasks', error);
    }
  }


  loadAllUsers() {
    this.http.get("http://localhost:5263/api/User/GetAllUserInfo")
      .subscribe(
        (res: any) => {
          this.userArray = res;
          this.userArray2 = res;
          this.userArray3 = res;
          console.log(res);
        },
        error => {
          console.error('Error loading users', error);
        }
      );
  }
}
