import { Component, OnInit, Inject } from '@angular/core';
import { DOCUMENT } from '@angular/common'
import { Router } from '@angular/router';
import { JwtHelperService } from '@auth0/angular-jwt';


@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.css']
})
export class HeaderComponent implements OnInit {
  UserName: any;


  constructor(@Inject(DOCUMENT) private document: Document, private router:Router) { }

  ngOnInit(): void {
    this.UserName = localStorage.getItem('UserName'); // Get the JWT token from localStorage

  }


  sidebarToggle()
  {
    //toggle sidebar function
    this.document.body.classList.toggle('toggle-sidebar');
  }

  logout(): void {
    // Clear the token from local storage
    localStorage.removeItem('userToken');
    localStorage.removeItem('userName');

    // Redirect to the login page or any other desired page
    this.router.navigate(['/login']);
  }

}
