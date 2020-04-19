import {Selectable} from '../../../shared/base/classes/selectable';
import {BaseList} from '../../../shared/base/classes/base-list';
import {Component, Input, OnInit, ViewChild} from '@angular/core';
import {RepresentationCourseCategoryDetailComponent} from './representation-course-category-detail.component';


@Component({
    selector: 'app-representation-course-category-list',
    templateUrl: './representation-course-category-list.component.html'
})
export class RepresentationCourseCategoryListComponent extends Selectable implements OnInit {
    @ViewChild('listForm', {static: true}) listForm: BaseList;
    loadAfterSetFilter: boolean;
    selectedItemId: number;
    columns: any[] = [];
    entityName = 'representationCourseCategory';
    detailComponent = RepresentationCourseCategoryDetailComponent;
    _representationId: number;
    @Input()
    set representationId(val) {
        if (val !== this._representationId) {
            this._representationId = val;
        }
    }

    get representationId(): number {
        return this._representationId;
    }

    _courseCategoryId: number;
    @Input()
    set courseCategoryId(val) {
        if (val !== this._courseCategoryId) {
            this._courseCategoryId = val;
        }
    }

    get courseCategoryId(): number {
        return this._courseCategoryId;
    }

    _accessLevelId: number;
    @Input()
    set accessLevelId(val) {
        if (val !== this._accessLevelId) {
            this._accessLevelId = val;
        }
    }

    get accessLevelId(): number {
        return this._accessLevelId;
    }

    private baseListUrl = 'representationCourseCategory/GetByCustomFilterForList?';

    constructor() {
        super();
        this.columns.push({
            caption: 'نمایندگی',
            dataField: 'representationTitle'
        });
        this.columns.push({
            caption: 'دسته بندي  آموزشی',
            dataField: 'courseCategoryTitle'
        });

    }

    ngOnInit(): void {
        if (this.bindCustomDataSources()) {
            this.loadAfterSetFilter = true;
        }
    }

    private bindCustomDataSources() {
        let customListUrl = `${this.baseListUrl}`;
        if (this.listForm) {
            if (this.representationId) {
                customListUrl += `representationId=${this.representationId}&`;
            }
            if (this.courseCategoryId) {
                customListUrl += `courseCategoryId=${this.courseCategoryId}&`;
            }
            if (this.accessLevelId) {
                customListUrl += `accessLevelId=${this.accessLevelId}&`;
            }
        }
        let res = false;
        if (this.representationId || this.courseCategoryId || this.accessLevelId) {
            this.listForm.customListUrl = customListUrl;
            this.listForm.refreshList();
            res = true;
        }
        return res;
    }

    afterInitialDetailComponent(componentInstance: any) {
        const comp = (<RepresentationCourseCategoryDetailComponent>componentInstance.instance);

        if (this.representationId) {
            comp.representationId = this.representationId;
        }

        if (this.courseCategoryId) {
            comp.courseCategoryId = this.courseCategoryId;
        }

        if (this.accessLevelId) {
            comp.accessLevelId = this.accessLevelId;
        }

    }
}
