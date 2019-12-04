import {Component, OnInit} from '@angular/core';
import {RoleDashboardDetailComponent} from './role-dashboard-detail.component';

@Component({
  selector: 'app-role-dashboard-list',
  templateUrl: './role-dashboard-list.component.html'
})
export class RoleDashboardListComponent {
  selectedItemId: number;
  columns: any[] = [];
  entityName = 'roleDashboard';
  detailComponent = RoleDashboardDetailComponent;

  constructor() {
    this.columns.push({
      caption: 'نقش',
      dataField: 'roleTitle'
    });
    this.columns.push({
      caption: 'داشبورد',
      dataField: 'dashboardTitle'
    });

  }
}
