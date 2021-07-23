import { Component, OnInit } from '@angular/core';
import { City } from 'src/app/city.model';
import { Service } from 'src/app/shared.service';

@Component({
  selector: 'app-cities',
  templateUrl: './cities.component.html',
  styleUrls: ['./cities.component.css']
})
export class CitiesComponent implements OnInit {
  cities: City[] = [];

  constructor(public service:Service) { }

  ngOnInit() {
    this.getCities();
  }

  getCities(): void {
    this.service.getCities()
    .subscribe(cities => this.cities = cities);
  }

}
