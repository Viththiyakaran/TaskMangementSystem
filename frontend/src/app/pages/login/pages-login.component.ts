import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Router } from '@angular/router';

@Component({
  selector: 'app-pages-login',
  templateUrl: './pages-login.component.html',
  styleUrls: ['./pages-login.component.css']
})
export class PagesLoginComponent implements OnInit {
  UserName: string = '';
  UserPassword: string = '';

  constructor(private http: HttpClient, private router: Router) { }

  ngOnInit(): void {
  }

  login(): void {
    const url = `http://localhost:5263/api/User/LoginUser?UserName=${encodeURIComponent(this.UserName)}&UserPassword=${encodeURIComponent(this.UserPassword)}`;

    this.http.post<any>(url, null).subscribe(
      response => {
        // Save the JWT token in local storage

        try {
          localStorage.setItem('userToken', response.userToken);
          localStorage.setItem('UserName', response.userName);
          console.log('UserToken:', response.userToken);
          console.log('UserName:', response.userName);
          //console.log('response Data:', response);

          // Redirect to the desired page after successful login
          this.router.navigate(['/dashboard']);

        } catch (error) {
          console.log('Error storing token in localStorage:', error);
        }
      },
      error => {
        console.log('Login failed:', error);

        // Handle login error here
        if (error.status === 400) {
          // Handle specific error code
          console.log('Invalid username or password');
        } else {
          console.log('An error occurred during login. Please try again later.');
        }
      }
    );
  }
}
