import {Component, OnInit} from '@angular/core';
import {CourseDetailComponent} from './course-detail.component';
import {CourseDetailTabBasedComponent} from './course-detail-tab-based.component';


@Component({
    selector: 'app-course-list',
    templateUrl: './course-list.component.html'
})
export class CourseListComponent {
    selectedItemId: number;
    columns: any[] = [];
    entityName = 'course';
    detailComponent = CourseDetailTabBasedComponent;

    constructor() {
        this.columns.push({
            caption: 'کد',
            dataField: 'code'
        });
        this.columns.push({
            caption: 'عنوان',
            dataField: 'title'
        });
        this.columns.push({
            caption: 'گروه آموزشی',
            dataField: 'courseCategoryTitle'
        });
        this.columns.push({
            caption: 'مرکز آموشی',
            dataField: 'educationalCenterTitle'
        });
        this.columns.push({
            caption: 'سطح مهارت دوره',
            dataField: 'skillTypeTitle'
        });
        this.columns.push({
            caption: 'نوع گواهي نامه',
            dataField: 'certificateTypeTitle'
        });
        this.columns.push({
            caption: 'روش ارزیابی دوره',
            dataField: 'evaluationMethodTitle'
        });
        this.columns.push({
            caption: 'مدت دوره',
            dataField: 'duration'
        });
        this.columns.push({
            caption: 'سطح دسترسی',
            dataField: 'accessLevelTitle'
        });

    }
}
