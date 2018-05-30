import { Component, OnInit } from '@angular/core';
import {TabMenuModule} from 'primeng/tabmenu';
import {MenuItem} from 'primeng/api';@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.css']
})
export class DashboardComponent implements OnInit {

  
  items: MenuItem[];
  constructor() { }

  ngOnInit() {
    this.items = [
      {label: 'JitterHome', icon: 'fa-bar-chart'},
      {label: 'Followers', icon: 'fa-calendar'},
      {label: 'Following', icon: 'fa-book'},
      {label: 'Stats', icon: 'fa-support'},
      {label: 'About', icon: 'fa-twitter'}
  ];
  }

}
