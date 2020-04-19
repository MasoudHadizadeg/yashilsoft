import {Component} from '@angular/core';
import {EducationalCenterDetailTabBasedComponent} from './educational-center-detail-tab-based.component';


@Component({
    selector: 'app-educational-center-list',
    templateUrl: './educational-center-list.component.html'
})
export class EducationalCenterListComponent {
    selectedItemId: number;
    columns: any[] = [];
    entityName = 'educationalCenter';
    detailComponent = EducationalCenterDetailTabBasedComponent;

    constructor() {
        this.columns.push({
            caption: 'عنوان',
            dataField: 'title',
            width: '70%'

        });

        this.columns.push({
            caption: 'نوع مجوز تاسیس',
            dataField: 'establishedLicenseTypeTitle'
        });

    }
}
