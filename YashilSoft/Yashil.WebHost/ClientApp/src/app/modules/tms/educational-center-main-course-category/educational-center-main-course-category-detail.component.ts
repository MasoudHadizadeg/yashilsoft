import {Component, Input, OnInit} from '@angular/core';
import {BaseEdit} from '../../../shared/base/classes/base-edit';
import {GenericDataService} from '../../../shared/base/services/generic-data.service';


@Component({
    selector: 'app-educational-center-main-course-category-detail',
    templateUrl: './educational-center-main-course-category-detail.component.html'
})
export class EducationalCenterMainCourseCategoryDetailComponent extends BaseEdit implements OnInit {
    columns: any[] = [];
    @Input()
    educationalCenterId: number;
    @Input()
    mainCourseCategoryId: number;

    constructor(private genericDataService: GenericDataService) {
        super(genericDataService);
        this.entityName = 'educationalCenterMainCourseCategory';
    }

    ngOnInit() {
        super.ngOnInit();
        this.columns.push({
            caption: 'عنوان',
            dataField: 'title',
            allowEditing: false
        });
        this.columns.push({
            caption: 'ترتیب نمایش',
            dataField: 'displayOrder',
            dataType: 'number'
        });
    }
}
