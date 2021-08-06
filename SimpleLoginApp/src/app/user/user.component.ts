import { Component, Input, OnInit } from '@angular/core';
import { Service } from '../shared.service';
import { User } from '../user.model';
import { ActivatedRoute, Router } from "@angular/router";
import { ToastrService } from 'ngx-toastr';
import { JwtHelperService } from '@auth0/angular-jwt';

@Component({
  selector: 'app-user',
  templateUrl: './user.component.html',
  styleUrls: ['./user.component.css']
})
export class UserComponent implements OnInit {
  @Input() user: User = new User();
  username:string='';
  newPassword:string='';
  successMessage:string='';

  constructor(private jwtHelper: JwtHelperService, public service:Service, private route: ActivatedRoute,
     private router: Router, private toastr:ToastrService) { }

  ngOnInit(): void {
    this.getUser();
  }

  getUser(): void {
    let username = this.route.snapshot.paramMap.get("username");
    const token = localStorage.getItem("jwt");
    let decodeUsername;
    if (token && !this.jwtHelper.isTokenExpired(token)){
      decodeUsername = this.jwtHelper.decodeToken(token).UserName;
    }
    if(username && username == decodeUsername){
      this.service.getUser(username).subscribe(user => this.user = user);
    }else{
      this.router.navigate(["/login"]);
    }
  }

  onChangePassword(){
    this.user.password = this.newPassword;
    this.service.changePassword(this.user).subscribe(
      res =>{
        this.router.navigate([`/user/`+this.user.userName]);
        this.toastr.success('Password changed succesfully')
      },
      err => {}
    );
  }

  showPassword(){
    this.service.showPassword();
  }

  logout() {
    localStorage.removeItem("jwt");
    this.router.navigate(["/login"]);
 }

}
