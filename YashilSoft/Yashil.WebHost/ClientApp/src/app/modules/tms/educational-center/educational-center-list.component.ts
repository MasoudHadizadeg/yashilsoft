import {Component} from '@angular/core';
import {EducationalCenterDetailTabBasedComponent} from './educational-center-detail-tab-based.component';
import {Selectable} from '../../../shared/base/classes/selectable';


@Component({
    selector: 'app-educational-center-list',
    templateUrl: './educational-center-list.component.html'
})
export class EducationalCenterListComponent extends Selectable {
    selectedItemId: number;
    columns: any[] = [];
    entityName = 'educationalCenter';
    detailComponent = EducationalCenterDetailTabBasedComponent;

    constructor() {
        super()
        this.columns.push({
            caption: 'عنوان',
            dataField: 'title'
        });
        this.columns.push({
            caption: 'نوع مجوز تاسیس',
            dataField: 'establishedLicenseType'
        });
        this.columns.push({
            type: 'buttons',
            width: 50,
            buttons: [
                {
                    hint: 'نمایندگی',
                    icon: 'exportselected',
                    onClick: this.navigateToRepresentation
                }]
        });

    }

    navigateToRepresentation(e) {
        const selectedId = e.row.data.id;
    }
}
