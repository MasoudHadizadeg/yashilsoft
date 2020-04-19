import {Selectable} from '../../../shared/base/classes/selectable';
import {BaseList} from '../../../shared/base/classes/base-list';
import {Component, Input, OnInit, ViewChild} from '@angular/core';
import {EducationalCenterMainCourseCategoryDetailComponent} from './educational-center-main-course-category-detail.component';


@Component({
    selector: 'app-educational-center-main-course-category-list',
    templateUrl: './educational-center-main-course-category-list.component.html'
})
export class EducationalCenterMainCourseCategoryListComponent extends Selectable implements OnInit {
    @ViewChild('listForm', {static: true}) listForm: BaseList;
    loadAfterSetFilter: boolean;
    selectedItemId: number;
    columns: any[] = [];
    entityName = 'educationalCenterMainCourseCategory';
    detailComponent = EducationalCenterMainCourseCategoryDetailComponent;
    _educationalCenterId: number;
    @Input()
    set educationalCenterId(val) {
        if (val !== this._educationalCenterId) {
            this._educationalCenterId = val;
        }
    }

    get educationalCenterId(): number {
        return this._educationalCenterId;
    }

    _mainCourseCategoryId: number;
    @Input()
    set mainCourseCategoryId(val) {
        if (val !== this._mainCourseCategoryId) {
            this._mainCourseCategoryId = val;
        }
    }

    get mainCourseCategoryId(): number {
        return this._mainCourseCategoryId;
    }

    private baseListUrl = 'educationalCenterMainCourseCategory/GetByCustomFilterForList?';

    constructor() {
        super();
    }

    ngOnInit(): void {
        this.bindColumns();
        if (this.bindCustomDataSources()) {
            this.loadAfterSetFilter = true;
        }
    }

    bindColumns() {
        if (!this.educationalCenterId) {
            this.columns.push({
                caption: 'مرکز آموشي',
                dataField: 'educationalCenterTitle',
                groupIndex: 1
            });
        }
        this.columns.push({
            caption: 'دسته بندی اصلی',
            dataField: 'mainCourseCategoryTitle'
        });
        this.columns.push({
            caption: 'ترتیب نمایش',
            dataField: 'displayOrder'
        });

    }

    private bindCustomDataSources() {
        let customListUrl = `${this.baseListUrl}`;
        if (this.listForm) {
            if (this.educationalCenterId) {
                customListUrl += `educationalCenterId=${this.educationalCenterId}&`;
            }
            if (this.mainCourseCategoryId) {
                customListUrl += `mainCourseCategoryId=${this.mainCourseCategoryId}&`;
            }
        }
        let res = false;
        if (this.educationalCenterId || this.mainCourseCategoryId) {
            this.listForm.customListUrl = customListUrl;
            this.listForm.refreshList();
            res = true;
        }
        return res;
    }

    afterInitialDetailComponent(componentInstance: any) {
        const comp = (<EducationalCenterMainCourseCategoryDetailComponent>componentInstance.instance);

        if (this.educationalCenterId) {
            comp.educationalCenterId = this.educationalCenterId;
        }

        if (this.mainCourseCategoryId) {
            comp.mainCourseCategoryId = this.mainCourseCategoryId;
        }

    }
}
