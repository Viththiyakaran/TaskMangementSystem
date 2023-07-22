import { Component, OnInit, ElementRef } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Chart, ChartConfiguration, ChartType, registerables } from 'chart.js';

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.css']
})
export class DashboardComponent implements OnInit {
  constructor(private elementRef: ElementRef , private http :HttpClient) { }
  taskArrayOpen: any[] = [];
  taskArrayIn_progress: any[] = [];
  taskArrayCompleted: any[] = [];
  ticketMonth: string = '';
  taskArrayPending: any[] = [];


  ngOnInit(): void {

    var s = document.createElement("script");
    s.type = "text/javascript";
    s.src = "../assets/js/main.js";
    this.elementRef.nativeElement.appendChild(s);
    this.loadAllTasks();
    this.loadAllPendingTasks();
    const currentDate = new Date();
    const monthOptions: Intl.DateTimeFormatOptions = { month: 'long' };
    const yearOptions: Intl.DateTimeFormatOptions = { year: 'numeric' };

    const month = currentDate.toLocaleString('en-GB', monthOptions);
    const year = currentDate.toLocaleString('en-GB', yearOptions);

    this.ticketMonth = `${month} ${year}`;


    this.getWeeklyPerformance();

  }

  getWeeklyPerformance()
  {
    Chart.register(...registerables);

    const data = {
      labels: ['January', 'February', 'March', 'April', 'May', 'June', 'July'],
      datasets: [
        {
          label: 'Sales',
          data: [65, 59, 80, 81, 56, 55, 40],
          backgroundColor: 'rgba(54, 162, 235, 0.8)',
          borderColor: 'rgba(54, 162, 235, 1)',
          borderWidth: 1,
        },
      ],
    };

    const config: ChartConfiguration<ChartType, number[], string> = {
      type: 'bar',
      data: data,
      options: {
        responsive: true,
        plugins: {
          legend: {
            position: 'top',
          },
          title: {
            display: true,
            text: 'Bar Chart Example',
          },
        },
      },
    };

    const myChart = new Chart('myChart', config);
  }




  // async loadAllTasks() {
  //   try {
  //     const res = await this.http
  //       .get('http://localhost:5263/api/CallLog/GetAllCallLogsByMonthly')
  //       .toPromise();
  //     this.taskArrayOpen = res as any[];
  //     console.log(res);
  //   } catch (error) {
  //     console.error('Error loading tasks', error);
  //   }
  // }


  selectedTicketStatus: string = 'In_progress'; // Holds the selected ticket status value
//taskArrayOpen: any[] = []; // Holds the tasks

async loadAllTasks() {
  try {
    const res = await this.http
      .get('http://localhost:5263/api/CallLog/GetAllCallLogsByMonthly')
      .toPromise();
      this.taskArrayOpen = res as any[];
      this.taskArrayIn_progress = res as any[];
      this.taskArrayCompleted = res as any[];

      this.taskArrayOpen = this.taskArrayOpen.filter(task => task.status.includes('Open'));
      this.taskArrayIn_progress = this.taskArrayIn_progress.filter(task => task.status.includes('In_progress'));
      this.taskArrayCompleted = this.taskArrayCompleted.filter(task => task.status.includes('Completed'));

    console.log(this.taskArrayOpen);
  } catch (error) {
    console.error('Error loading tasks', error);
  }
}


async loadAllPendingTasks() {
  try {
    const res = await this.http
      .get('http://localhost:5263/api/CallLog/GetAllCallLogsByPendings')
      .toPromise();
      this.taskArrayPending = res as any[];
    console.log(this.taskArrayOpen);
  } catch (error) {
    console.error('Error loading tasks', error);
  }
}


}
