import { Injectable } from '@angular/core';
import { CanActivate, CanLoad, Router } from '@angular/router';
import { JwtHelperService } from '@auth0/angular-jwt';

@Injectable()
export class AuthGuard implements CanLoad, CanActivate {

  constructor(private jwtHelper: JwtHelperService, private router: Router) {
  }
  checkTokenExpiration() {
    const token = localStorage.getItem("jwt");

    if (token && !this.jwtHelper.isTokenExpired(token)){
      console.log(this.jwtHelper.decodeToken(token));
      return true;
    }
    this.router.navigate(["/login"]);
    return false;
}

  canLoad() {
    return this.checkTokenExpiration()
  }

  canActivate(){
    return this.checkTokenExpiration();
  }

}