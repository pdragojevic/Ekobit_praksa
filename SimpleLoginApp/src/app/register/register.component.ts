import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { Router } from '@angular/router';
import { City } from '../city.model';
import { Service } from '../shared.service';
import { User } from '../user.model';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {
  user: User = new User();
  cities: City[] = [];

  constructor(public service:Service, private router: Router) { }

  ngOnInit(): void {
    this.getCities();
  }

  onRegister(form:NgForm){
    this.service.register(this.user).subscribe(
      res =>{
        this.router.navigate(["/login"]);
      },
      err => {}
    );
  }

  getCities(): void {
    this.service.getCities()
    .subscribe(cities => this.cities = cities);
  }

  showPassword(){
    this.service.showPassword();
  }

}
