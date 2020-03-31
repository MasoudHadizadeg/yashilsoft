import {Component} from '@angular/core';
import {CoursesPlanningDetailTabBasedComponent} from './courses-planning-detail-tab-based.component';


@Component({
    selector: 'app-courses-planning-list',
    templateUrl: './courses-planning-list.component.html'
})
export class CoursesPlanningListComponent {
    selectedItemId: number;
    columns: any[] = [];
    entityName = 'coursePlanning';
    detailComponent = CoursesPlanningDetailTabBasedComponent;

    constructor() {
        this.columns.push({
            caption: 'نمایندگی',
            dataField: 'representationTitle'
        });
        this.columns.push({
            caption: 'دوره',
            dataField: 'courseTitle',
            width: 300
        });
        this.columns.push({
            caption: 'دوره سازمانی',
            dataField: 'organizational'
        });
        this.columns.push({
            caption: 'وضعیت دوره',
            dataField: 'courseStatusTitle'
        });
        this.columns.push({
            caption: 'رده سنی',
            dataField: 'ageCategoryTitle'
        });
        this.columns.push({
            caption: 'نوع برگزاری',
            dataField: 'implementationTypeTitle'
        });
        this.columns.push({
            caption: 'نوع دوره',
            dataField: 'courseTypeTitle'
        });
        this.columns.push({
            caption: 'روش اجرای دوره',
            dataField: 'runTypeTitle'
        });
        this.columns.push({
            caption: 'تاریخ شروع',
            dataField: 'startDate',
            cellTemplate: 'intDate'
        });
        this.columns.push({
            caption: 'جنسیت',
            dataField: 'customGenderTitle'
        });
        this.columns.push({
            caption: 'حداکثر ظرفیت',
            dataField: 'maxCapacity'
        });

    }
}
