import { Component, OnInit } from '@angular/core';
import { MenuItem } from 'primeng/api';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent implements OnInit {
  constructor() {}

  title = 'Personal Library';
  items: MenuItem[] | undefined;
  
  ngOnInit() {
    this.items = [
      {
          label: 'List',
          route: '/'
      },
      {
          label: 'Create New',
          route: '/book/data/0'
      }
  ]
  }
}
