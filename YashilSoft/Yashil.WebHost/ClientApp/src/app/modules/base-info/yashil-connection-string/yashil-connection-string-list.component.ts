import {Component} from '@angular/core';
import {YashilConnectionStringDetailComponent} from './yashil-connection-string-detail.component';

@Component({
    selector: 'app-yashil-connection-string-list',
    templateUrl: './yashil-connection-string-list.component.html'
})
export class YashilConnectionStringListComponent {
    selectedItemId: number;
    columns: any[] = [];
    entityName = 'yashilConnectionString';
    detailComponent = YashilConnectionStringDetailComponent;

    constructor() {
        this.columns.push({
            caption: 'عنوان',
            dataField: 'title'
        });
        this.columns.push({
            width: '200px',
            caption: 'تامین کننده داده',
            dataField: 'dataProviderTitle'
        });
        this.columns.push({
            width: '100px',
            caption: 'فعال بودن',
            dataField: 'isActive'
        });

    }
}
