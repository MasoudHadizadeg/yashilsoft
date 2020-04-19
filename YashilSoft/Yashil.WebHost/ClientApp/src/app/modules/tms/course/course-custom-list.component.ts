import {Component, Input, OnInit, ViewChild} from '@angular/core';
import {CourseDetailTabBasedComponent} from './course-detail-tab-based.component';
import {BaseList} from '../../../shared/base/classes/base-list';
import {GenericDataService} from '../../../shared/base/services/generic-data.service';
import {DxTreeViewComponent} from 'devextreme-angular';
import {CachedDataService} from '../../../shared/services/cached-data.service';
import {CachedKey} from '../tms-enums';


@Component({
    selector: 'app-course-custom-list',
    templateUrl: './course-custom-list.component.html'
})
export class CourseCustomListComponent implements OnInit {
    additionalUserProp: any;
    @Input()
    forSelect = false;
    @ViewChild(DxTreeViewComponent, {static: false}) treeView;
    courseCategoryId: number;
    contentHeight: number;
    educationalCenterDataSource: any;
    @ViewChild('frmCourse', {static: true}) frmCourse: BaseList;
    private _educationalCenterId: number;
    selectedCourseCategory: any;
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
        }
    }

    get educationalCenterId(): number {
        return this._educationalCenterId;
    }

    customListUrl: string;
    baseListUrlByCourseCategoryId = 'course/GetByCourseCategoryId?courseCategoryId=';
    baseListUrlByMainCourseCategoryId = 'course/GetByMainCourseCategoryId';
    selectedItemId: number;
    columns: any[] = [];
    entityName = 'course';
    detailComponent = CourseDetailTabBasedComponent;

    afterInitialDetailComponent(componentInstance: any) {
        const comp = (<CourseDetailTabBasedComponent>componentInstance);
        comp.educationalCenterId = this.educationalCenterId;
        comp.courseCategoryId = this.courseCategoryId;
    }

    constructor(private genericDataService: GenericDataService, private cachedDataService: CachedDataService) {
        this.contentHeight = window.innerHeight - 110;
        this.bindColumns();
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
    selectedCourseCategoryChanged(item: any) {
        this.selectedCourseCategory = item;
        if (this.selectedCourseCategory && !this.selectedCourseCategory.isMainCourseCategory) {
            this.courseCategoryId = item.id;
        }
        this.bindDataSources();
    }
    private bindDataSources() {
        if (this.selectedCourseCategory && this.selectedCourseCategory.isMainCourseCategory) {
            this.frmCourse.customListUrl = `${this.baseListUrlByMainCourseCategoryId}?educationalCenterMainCourseCategoryId=${this.selectedCourseCategory.educationalCenterMainCourseCategoryId}`;
        } else {
            this.frmCourse.customListUrl = `${this.baseListUrlByCourseCategoryId}${this.selectedCourseCategory.id}`;
        }

        this.frmCourse.refreshList();
    }

    ngOnInit(): void {
        this.additionalUserProp = this.cachedDataService.getData(CachedKey.AdditionalUserProp);
        if (this.additionalUserProp && this.additionalUserProp.educationalCenterId) {
            this.educationalCenterId = this.additionalUserProp.educationalCenterId;
        }
        this.educationalCenterDataSource = this.genericDataService.createCustomDatasourceForSelect('id', 'educationalCenter');
    }

    private bindColumns() {
        this.columns.push({
            caption: 'عنوان',
            dataField: 'title',
            width: 300
        });
        this.columns.push({
            caption: 'گروه آموزشی',
            dataField: 'courseCategoryTitle'
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
