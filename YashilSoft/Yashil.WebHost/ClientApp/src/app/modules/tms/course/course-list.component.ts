import {Component, Input, ViewChild} from '@angular/core';
import {CourseDetailTabBasedComponent} from './course-detail-tab-based.component';
import {BaseList} from '../../../shared/base/classes/base-list';


@Component({
    selector: 'app-course-list',
    templateUrl: './course-list.component.html'
})
export class CourseListComponent {
    @ViewChild('frmCourse', {static: true}) frmCourse: BaseList;
    private _educationalCenterId: number;
    /**
     * Course Category And Education Center Id
     */
    @Input()
    courseInfo: {};
    @Input()
    hideEducationalCenterColumn = false;
    selectedEntity: any = null;

    @Input()
    set educationalCenterId(value: number) {
        if (this._educationalCenterId !== value) {
            this._educationalCenterId = value;
            this.frmCourse.customListUrl = `${this.baseListUrl}${this._educationalCenterId}`;
            this.frmCourse.refreshList();
        }
    }

    get educationalCenterId(): number {
        return this._educationalCenterId;
    }

    customListUrl: string;
    baseListUrl = 'course/GetByEducationalCenterIdForList?educationalCenterId=';
    selectedItemId: number;
    columns: any[] = [];
    entityName = 'course';
    detailComponent = CourseDetailTabBasedComponent;

    afterInitialDetailComponent(componentInstance: any) {
        const comp = (<CourseDetailTabBasedComponent>componentInstance);
        comp.educationalCenterId = this.educationalCenterId;
    }

    constructor() {
        this.columns.push({
            caption: 'عنوان',
            dataField: 'title'
        });
        this.columns.push({
            caption: 'گروه آموزشی',
            dataField: 'courseCategoryTitle'
        });
        if (!this.educationalCenterId) {
            this.columns.push({
                caption: 'مرکز آموشی',
                dataField: 'educationalCenterTitle'
            });
        }
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
            caption: 'مدت دوره(ساعت)',
            dataField: 'duration'
        });

    }
}
