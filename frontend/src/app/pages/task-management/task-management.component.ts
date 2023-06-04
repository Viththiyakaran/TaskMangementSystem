import { Component, OnInit, ElementRef } from '@angular/core';
import {  HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-task-management',
  templateUrl: './task-management.component.html',
  styleUrls: ['./task-management.component.css']
})
export class TaskManagementComponent implements OnInit {

  taskArray: any[] = [];
  constructor(private elementRef: ElementRef , private http: HttpClient) { }

  ngOnInit(): void {

    var s = document.createElement("script");
    s.type = "text/javascript";
    s.src = "../assets/js/main.js";
    this.elementRef.nativeElement.appendChild(s);

    this.loadAllTasks();
  }



  // loadAllTasks() {
  //   this.http.get("http://localhost:5263/api/CallLog/GetAllCallLogTaskInfo")
  //     .subscribe(
  //       (res: any) => {
  //         this.taskArray = res;
  //         console.log(res);
  //       },
  //       error => {
  //         console.error('Error loading business', error);
  //       }
  //     );
  // }

  async loadAllTasks() {
    try {
      const res = await this.http.get("http://localhost:5263/api/CallLog/GetAllCallLogTaskInfo").toPromise();
      this.taskArray = res as any[];
      console.log(res);
    } catch (error) {
      console.error('Error loading tasks', error);
    }
  }


}
