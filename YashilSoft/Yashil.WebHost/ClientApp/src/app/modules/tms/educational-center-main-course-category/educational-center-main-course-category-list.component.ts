import {Component} from '@angular/core';
import {EducationalCenterMainCourseCategoryDetailComponent} from './educational-center-main-course-category-detail.component';


@Component({
    selector: 'app-educational-center-main-course-category-list',
    templateUrl: './educational-center-main-course-category-list.component.html'
})
export class EducationalCenterMainCourseCategoryListComponent {
    selectedItemId: number;
    columns: any[] = [];
    entityName = 'educationalCenterMainCourseCategory';
    detailComponent = EducationalCenterMainCourseCategoryDetailComponent;

    constructor() {
        this.columns.push({
            caption: 'مرکز آموشي',
            dataField: 'educationalCenterTitle',
            groupIndex: 1
        });
        this.columns.push({
            caption: 'دسته بندی اصلی',
            dataField: 'mainCourseCategoryTitle'
        });
        this.columns.push({
            caption: 'ترتیب نمایش',
            dataField: 'displayOrder'
        });

    }
}
