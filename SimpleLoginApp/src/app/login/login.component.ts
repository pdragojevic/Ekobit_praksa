import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { Router } from '@angular/router';
import { LoginUser } from 'src/app/login.model';
import { Service } from 'src/app/shared.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
  loginUser: LoginUser = new LoginUser();
  errmessage: String;

  constructor(public service:Service, private router: Router) { }

  ngOnInit(): void {
  }

  onSubmit(form:NgForm){
    this.service.login(this.loginUser).subscribe(
      res =>{
        this.router.navigate([`/user/`+this.loginUser.username]);

      },
      err => {this.errmessage = "Wrong username or password. Please try again.";}
    );
  }

}
