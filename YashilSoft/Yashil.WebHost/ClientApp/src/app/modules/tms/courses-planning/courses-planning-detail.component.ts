import {Component, Input, OnInit, ViewChild} from '@angular/core';
import {BaseEdit} from '../../../shared/base/classes/base-edit';
import {GenericDataService} from '../../../shared/base/services/generic-data.service';
import {Entity} from '../../../shared/base/base-data/entity.enum';
import {CachedDataService} from '../../../shared/services/cached-data.service';
import {CachedKey} from '../tms-enums';
import {DxDropDownBoxComponent, DxTreeViewComponent} from 'devextreme-angular';


@Component({
    selector: 'app-courses-planning-detail',
    templateUrl: './courses-planning-detail.component.html'
})
export class CoursesPlanningDetailComponent extends BaseEdit implements OnInit {
    @ViewChild(DxTreeViewComponent, {static: false}) treeView;
    @ViewChild('ddlCourse', {static: false}) courseComponent: DxDropDownBoxComponent;
    @Input()
    representationId: number;
    @Input()
    educationalCenterId: number;
    @Input()
    courseCategoryId: number;
    courseCategoryDataSource: any;
    representationDataSource: any;
    courseStatuss: any;
    representationPersonDataSource: any;
    courseDataSource: any;
    ageCategorys: any;
    implementationTypes: any;
    courseTypes: any;
    runTypes: any;
    customGenders: any;
    accessLevels: any[] = [];
    baseListUrlByCourseCategoryId = 'GetRepresentationCourseByCategoryId';
    baseListUrlByMainCourseCategoryId = 'GetByMainCourseCategoryId';
    selectedCourseCategory: any;
    selectedCourseChanged = false;

    constructor(private genericDataService: GenericDataService, private cachedDataService: CachedDataService) {
        super(genericDataService);
        this.entityName = 'coursePlanning';
        this.selectedRepresentationValueChanged = this.selectedRepresentationValueChanged.bind(this);
        this.ddlCourseSelectedChanged = this.ddlCourseSelectedChanged.bind(this);
    }

    ngOnInit() {
        super.ngOnInit();

        const data = this.cachedDataService.getData(CachedKey.AdditionalUserProp);
        if (data && data.representationId) {
            if (!this.selectedEntityId) {
                this.entity.representationId = data.representationId;
                this.representationId = data.representationId;
            }
        }
        if (!this.selectedEntityId) {
            this.initialEntityDefaultValues();
            if (this.educationalCenterId) {
                this.entity.educationalCenterId = this.educationalCenterId;
            }
            if (this.courseCategoryId) {
                this.entity.courseCategoryId = this.courseCategoryId;
                this.bindCourseDataSources();
            }
        }
        this.bindCourseCategoriesDataSources();
        this.representationPersonDataSource = this._genericDataService.createCustomDatasourceForSelect('id', 'representationPerson');
        this.representationDataSource = this._genericDataService.createCustomDatasourceForSelect('id', 'representation');
        this._genericDataService.getEntitiesByEntityNameForSelect(Entity.AccessLevel).subscribe(res => this.accessLevels = res);
        this._genericDataService.getCommonBaseDataForSelect('CourseStatus').subscribe(res => this.courseStatuss = res);
        this._genericDataService.getCommonBaseDataForSelect('AgeCategory').subscribe(res => this.ageCategorys = res);
        this._genericDataService.getCommonBaseDataForSelect('ImplementationType').subscribe(res => this.implementationTypes = res);
        this._genericDataService.getCommonBaseDataForSelect('CourseType').subscribe(res => this.courseTypes = res);
        this._genericDataService.getCommonBaseDataForSelect('RunType').subscribe(res => this.runTypes = res);
        this._genericDataService.getCommonBaseDataForSelect('CustomGender').subscribe(res => this.customGenders = res);
    }

    selectedCourseCategoryValueChanged(e) {
        if (e.value) {
            const that = this;
            this.bindCourseDataSources();
            this.selectedCourseChanged = true;
        }
    }

    selectedCourseCategoryChanged(e) {
        this.selectedCourseCategory = e.itemData;
        if (!e.itemData.isMainCourseCategory) {
            this.entity.courseCategoryId = e.itemData.id;
        }
    }

    private bindCourseDataSources() {
        let customListUrl = '';
        if (this.selectedCourseCategory && this.selectedCourseCategory.isMainCourseCategory) {
            customListUrl = `${this.baseListUrlByMainCourseCategoryId}?educationalCenterMainCourseCategoryId=${this.selectedCourseCategory.educationalCenterMainCourseCategoryId}`;
        } else if (this.entity.courseCategoryId) {
            customListUrl = `${this.baseListUrlByCourseCategoryId}?courseCategoryId=${this.entity.courseCategoryId}&representationId=${this.representationId}`;
        }
        if (customListUrl !== '') {
            this.courseDataSource = this._genericDataService.createCustomDatasourceWithAction('id', 'course', customListUrl);
        }
    }

    selectedRepresentationValueChanged(e) {
        if (e.previousValue != null && e.previousValue) {
            this.entity.courseCategoryId = null;
            this.entity.courseId = null;
        }
        this.bindCourseCategoriesDataSources();
    }

    afterLoadData(res: any): any {
        this.bindCourseDataSources();
        this.bindCourseCategoriesDataSources();
        return super.afterLoadData(res);
    }

    onCourseSelectionChanged(e) {
        if (e && e.data) {
            this.entity.courseId = e.data.id;
        }
    }

    private bindCourseCategoriesDataSources() {
        if (this.representationId) {
            this.courseCategoryDataSource =
                this._genericDataService.getCustomEntitiesByUrl(`api/courseCategory/GetRepresentationCourseCategories?representationId=${this.representationId}`)
                    .subscribe((res: any) => {
                        this.courseCategoryDataSource = res;
                    });
        } else {
            this.courseCategoryDataSource = null;
        }
    }

    courseCategoryTreeContentReady(e: any) {
        // if (this.selectedCourseChanged) {
        //     this.selectedCourseChanged = false;
        //     this.entity.courseId = null;
        // }
    }

    private initialEntityDefaultValues() {
        this.entity.courseStatus = 55;
        this.entity.maxCapacity = 50;
        this.entity.ageCategory = 17;
        this.entity.implementationType = 12;
        this.entity.courseType = 5;
        this.entity.runType = 34;
        this.entity.customGender = 4;
        this.entity.courseCategoryId = this.courseCategoryId;
        this.entity.educationalCenterId = this.educationalCenterId;
        this.entity.representationId = this.representationId;
    }

    selectedPersonChanged(item: any) {
        this.entity.RepresentationTeacherId = item.id;
    }

    courseDataSourceChagend(e) {
        const ss = '';
    }

    ddlCourseSelectedChanged($event: any) {
        this.entity.courseId = null;
    }
}
