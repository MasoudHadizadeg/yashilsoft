import {Component} from '@angular/core';
import {OrganizationDetailComponent} from './organization-detail.component';

@Component({
    selector: 'app-organization-list',
    templateUrl: './organization-list.component.html'
})
export class OrganizationListComponent {
    selectedItemId: number;
    columns: any[] = [];
    entityName = 'organization';
    detailComponent = OrganizationDetailComponent;

    constructor() {
        this.columns.push({
            caption: 'عنوان',
            dataField: 'title'
        });
        this.columns.push({
            caption: 'فعال',
            dataField: 'isActive'
        });
        this.columns.push({
            caption: 'نوع سازمان',
            dataField: 'type'
        });
        this.columns.push({
            caption: 'استان',
            dataField: 'provinceId'
        });

    }
}
