import {Component, OnInit} from '@angular/core';
import {MenuDetailComponent} from './menu-detail.component';

@Component({
    selector: 'app-menu-list',
    templateUrl: './menu-list.component.html'
})
export class MenuListComponent {
    selectedItemId: number;
    columns: any[] = [];
    entityName = 'menu';
    detailComponent = MenuDetailComponent;

    constructor() {
        this.columns.push({
            caption: 'مسیر',
            dataField: 'path'
        });
        this.columns.push({
            caption: 'عنوان',
            dataField: 'title'
        });
        this.columns.push({
            caption: 'پدر',
            dataField: 'parentTitle'
        });
        this.columns.push({
            caption: 'منبع',
            dataField: 'resourceTitle'
        });
        this.columns.push({
            caption: 'ترتیب',
            dataField: 'orderNo',
            width: 50
        });

    }
}
