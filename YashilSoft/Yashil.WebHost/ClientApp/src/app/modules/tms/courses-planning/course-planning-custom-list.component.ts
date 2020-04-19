import {Component, Input, OnInit, ViewChild} from '@angular/core';
import {BaseList} from '../../../shared/base/classes/base-list';
import {GenericDataService} from '../../../shared/base/services/generic-data.service';
import {DxTreeViewComponent} from 'devextreme-angular';
import {CachedDataService} from '../../../shared/services/cached-data.service';
import {CachedKey} from '../tms-enums';
import {CoursesPlanningDetailTabBasedComponent} from './courses-planning-detail-tab-based.component';


@Component({
    selector: 'app-course-planning-custom-list',
    templateUrl: './course-planning-custom-list.component.html'
})
export class CoursePlanningCustomListComponent implements OnInit {
    @Input()
    forSelect = false;
    @ViewChild(DxTreeViewComponent, {static: false}) treeView;
    courseCategoryId: number;
    contentHeight: number;
    educationalCenterDataSource: any;
    @ViewChild('frmCourse', {static: true}) frmCourse: BaseList;
    selectedCourseCategory: any;
    /**
     * Course Category And Education Center Id
     */
    representationId: number;
    @Input()
    courseInfo: {};
    @Input()
    hideEducationalCenterColumn = false;
    private _educationalCenterId: number;
    @Input()
    set educationalCenterId(value: number) {
        if (this._educationalCenterId !== value) {
            this._educationalCenterId = value;
        }
    }

    get educationalCenterId(): number {
        return this._educationalCenterId;
    }

    customListUrl: string;
    baseListUrlByCourseCategoryId = 'coursePlanning/GetByCourseCategoryId';
    baseListUrlByMainCourseCategoryId = 'coursePlanning/GetByMainCourseCategoryId';
    selectedItemId: number;
    columns: any[] = [];
    entityName = 'course';
    detailComponent = CoursesPlanningDetailTabBasedComponent;

    afterInitialDetailComponent(componentInstance: any) {
        const comp = (<CoursesPlanningDetailTabBasedComponent>componentInstance.instance);
        comp.educationalCenterId = this.educationalCenterId;
        comp.courseCategoryId = this.courseCategoryId;
    }

    constructor(private genericDataService: GenericDataService, private cachedDataService: CachedDataService) {
        this.contentHeight = window.innerHeight - 110;
        this.bindColumns();
    }

    ngOnInit(): void {
        const data = this.cachedDataService.getData(CachedKey.AdditionalUserProp);
        if (data) {
            if (data.educationalCenterId) {
                this.educationalCenterId = data.educationalCenterId;
            }
            if (data.representationId) {
                this.representationId = data.representationId;
            }
        }
        this.educationalCenterDataSource = this.genericDataService.createCustomDatasourceForSelect('id', 'educationalCenter');
    }

    syncTreeViewSelection(e) {
        const component = (e && e.component) || (this.treeView && this.treeView.instance);

        if (!component) {
            return;
        }
    }

    treeView_itemSelectionChanged(e) {
        if (!e.itemData.isMainCourseCategory) {
            this.courseCategoryId = e.itemData.id;
        }
    }

    selectedEducationalCenterChanged(e) {
        if (e && e.selectedItem) {
            this.courseCategoryId = null;
        }
    }

    private bindDataSources(id: any) {
        if (this.selectedCourseCategory && this.selectedCourseCategory.isMainCourseCategory) {
            const ecmcc = this.selectedCourseCategory.educationalCenterMainCourseCategoryId;
            this.frmCourse.customListUrl =
                `${this.baseListUrlByMainCourseCategoryId}?educationalCenterMainCourseCategoryId=${ecmcc}&representationId=${this.representationId}`;
        } else {
            this.frmCourse.customListUrl = `${this.baseListUrlByCourseCategoryId}?courseCategoryId=${id}&representationId=${this.representationId}`;
        }

        this.frmCourse.refreshList();
    }

    private bindColumns() {
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
            caption: 'تاریخ شروع',
            dataField: 'startDate',
            cellTemplate: 'intDate'
        });
    }

    selectedCourseCategoryChanged(item: any) {
        this.selectedCourseCategory = item;
        if (item && !item.isMainCourseCategory) {
            this.courseCategoryId = item.id;
        }
        this.bindDataSources(item.id);
    }

    onSelectedRepresentationChanged(item: any) {
        this.educationalCenterId = item.educationalCenter.id;
        this.representationId = item.representation.id;
        this.selectedEducationalCenterChanged(item.educationalCenter);
    }
}
