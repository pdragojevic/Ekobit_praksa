import { Component, Input, OnInit } from '@angular/core';
import { Service } from '../shared.service';
import { User } from '../user.model';
import { ActivatedRoute } from "@angular/router";

@Component({
  selector: 'app-user',
  templateUrl: './user.component.html',
  styleUrls: ['./user.component.css']
})
export class UserComponent implements OnInit {
  @Input() user: User = new User();
  username:string='';

  constructor(public service:Service, private route: ActivatedRoute) { }

  ngOnInit(): void {
    this.getUser();
  }

  getUser(): void {
    let username = this.route.snapshot.paramMap.get("username")
    if(username){
      this.service.getUser(username)
      .subscribe(user => this.user = user);
    }
  }

}
