import {Component, OnInit} from '@angular/core';
import {RoleDetailComponent} from './role-detail.component';

@Component({
  selector: 'app-role-list',
  templateUrl: './role-list.component.html'
})
export class RoleListComponent {
  selectedItemId: number;
  columns: any[] = [];
  entityName = 'role';
  detailComponent = RoleDetailComponent;

  constructor() {
    this.columns.push({
      caption: 'عنوان',
      dataField: 'title'
    });
    this.columns.push({
      caption: 'فعال بودن',
      dataField: 'isActive'
    });

  }
}
