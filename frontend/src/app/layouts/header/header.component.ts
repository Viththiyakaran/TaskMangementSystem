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
  UserName: string ='';


  constructor(@Inject(DOCUMENT) private document: Document, private router:Router) { }

  ngOnInit(): void {
      //   // Retrieve the token from local storage
      // const UserName = localStorage.getItem('UserName');

      // // Check if the token is present
      // if (UserName) {
      //   // Decode the token
      //   const decodedToken = this.jwtHelper.decodeToken(UserName);

      //   // Extract the UserName from the decoded token
      //   this.UserName = decodedToken.UserName;
      // }
  }


  sidebarToggle()
  {
    //toggle sidebar function
    this.document.body.classList.toggle('toggle-sidebar');
  }

  logout(): void {
    // Clear the token from local storage
    localStorage.removeItem('userToken');
    localStorage.removeItem('UserName');

    // Redirect to the login page or any other desired page
    this.router.navigate(['/login']);
  }

}
