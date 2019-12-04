import {Component, OnInit} from '@angular/core';
import {RoleResourceActionDetailComponent} from './role-resource-action-detail.component';

@Component({
  selector: 'app-role-resource-action-list',
  templateUrl: './role-resource-action-list.component.html'
})
export class RoleResourceActionListComponent {
  selectedItemId: number;
  columns: any[] = [];
  entityName = 'roleResourceAction';
  detailComponent = RoleResourceActionDetailComponent;

  constructor() {
    this.columns.push({
      caption: 'منبع عملیات',
      dataField: 'resourceActionTitle'
    });
    this.columns.push({
      caption: 'نقش',
      dataField: 'roleTitle'
    });

  }
}
