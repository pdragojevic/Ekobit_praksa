import { Injectable } from '@angular/core';
import { Observable, of } from 'rxjs';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { City } from './city.model';
import { LoginUser } from './login.model';
import { User } from './user.model';

@Injectable({
  providedIn: 'root',
})
export class Service {
  constructor(private http: HttpClient) { }

  readonly baseURL = 'http://localhost:60524/api'

  getCities(): Observable<City[]> {
      return this.http.get<City[]>(this.baseURL+'/City');
  }

  getUser(username:string): Observable<User>{
    const url = `${this.baseURL}/User/${username}`;
    return this.http.get<User>(url);
  }

  login(loginUser: LoginUser){
    return this.http.post(this.baseURL+'/Login', loginUser);
  }

  changePassword(user: User){
    return this.http.put(this.baseURL+'/User', user)
  }

}