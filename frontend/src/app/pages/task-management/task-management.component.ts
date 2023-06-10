import { Component, OnInit, ElementRef } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-task-management',
  templateUrl: './task-management.component.html',
  styleUrls: ['./task-management.component.css']
})
export class TaskManagementComponent implements OnInit {
  taskArray: any[] = [];
  ticketId: string = '';
  p: number = 1; // Declare the 'p' property for pagination
  key: string = 'id'; // Default sort key
  reverse: boolean = false;

  constructor(private elementRef: ElementRef, private http: HttpClient) {}

  ngOnInit(): void {
    this.loadAllTasks();
  }

  loadAllTasks(): void {
    this.http.get("http://localhost:5263/api/CallLog/GetAllCallLogTaskInfo").subscribe(
      (res: any) => {
        this.taskArray = res;
        console.log(res);
      },
      error => {
        console.error('Error loading tasks', error);
      }
    );
  }

  onKeyUp(event: KeyboardEvent): void {
    if (event.key === 'Backspace') {
      this.Search();
    }
  }

  Sort(key: string): void {
    this.key = key;
    this.reverse = !this.reverse;

    this.taskArray.sort((a, b) => {
      const valA = a[key];
      const valB = b[key];

      if (key === 'ticketId') {
        // Convert ticketId values to numbers for numerical sorting
        const numA = parseInt(valA, 10);
        const numB = parseInt(valB, 10);

        if (numA < numB) {
          return this.reverse ? 1 : -1;
        }
        if (numA > numB) {
          return this.reverse ? -1 : 1;
        }
      } else {
        // For non-ticketId fields, perform string comparison
        if (valA < valB) {
          return this.reverse ? 1 : -1;
        }
        if (valA > valB) {
          return this.reverse ? -1 : 1;
        }
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

  Search(): void {
    let filteredArray: any[];

    if (this.ticketId.trim() === '') {
      // If the search box is empty, show all results
      filteredArray = this.taskArray;
    } else {
      // If the search box has a value, filter the results
      filteredArray = this.taskArray.filter(task => {
        // Check if the business name or ID matches the search input
        return task.ticketId.includes(this.ticketId) || task.ticketId.toString().includes(this.ticketId);
      });
    }

    this.taskArray = filteredArray;
    this.p = 1; // Reset the pagination to the first page after searching

    if (this.ticketId.trim() === '') {
      // Clear the search input and reload all tasks
      this.ticketId = '';
      this.loadAllTasks();
    }
  }


  deleteTask(task: any): void {

    this.http.delete(`http://localhost:5263/api/CallLog/DeleteTask/${task.ticketId}`)
    .subscribe(
      (response: any) => {
        console.log('Task deleted successfully', response);
        // Refresh the task list or perform any necessary actions after deletion
        this.loadAllTasks();
      },
      (error: any) => {
        console.error('Error deleting task', error);
      }
    );

  }


  editTask(task: any): void {
    // Perform the necessary actions to handle the edit functionality
    console.log("Edit task:", task);
    // You can navigate to the edit page or display a modal for editing the task
  }

}
