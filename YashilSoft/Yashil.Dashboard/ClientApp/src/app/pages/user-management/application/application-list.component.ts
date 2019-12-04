import {Component, OnInit} from '@angular/core';
import {ApplicationDetailComponent} from './application-detail.component';

@Component({
  selector: 'app-application-list',
  templateUrl: './application-list.component.html'
})
export class ApplicationListComponent {
  selectedItemId: number;
  columns: any[] = [];
  entityName = 'application';
  detailComponent = ApplicationDetailComponent;

  constructor() {
    this.columns.push({
      caption: 'عنوان',
      dataField: 'title'
    });
    this.columns.push({
      caption: 'توضیحات',
      dataField: 'description'
    });
    this.columns.push({
      caption: 'آدرس',
      dataField: 'url'
    });
    this.columns.push({
      caption: 'کلید',
      dataField: 'secretKey'
    });
    this.columns.push({
      caption: 'اطلاعات تکمیلی',
      dataField: 'additionalInfo'
    });

  }
}
