import { Component, OnInit } from '@angular/core';
import { MatTableDataSource } from '@angular/material/table';

export interface Task {
  title: string;
  description: string;
  status: string;
}

@Component({
  selector: 'app-task-management',
  templateUrl: './task-management.component.html',
  styleUrls: ['./task-management.component.css']
})
export class TaskManagementComponent implements OnInit {

  displayedColumns: string[] = ['title', 'description', 'status'];
  dataSource = new MatTableDataSource<Task>([
    { title: 'Task 1', description: 'Description 1', status: 'Pending' },
    { title: 'Task 2', description: 'Description 2', status: 'Completed' },
    // Add more tasks here...
  ]);

  ngOnInit() {
    // Initialization logic goes here
  }

}
