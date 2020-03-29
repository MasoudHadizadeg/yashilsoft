import {Component, Input, OnInit, ViewChild} from '@angular/core';
import {BaseEdit} from '../../../shared/base/classes/base-edit';
import {GenericDataService} from '../../../shared/base/services/generic-data.service';
import {Entity} from '../../../shared/base/base-data/entity.enum';
import {CachedDataService} from '../../../shared/services/cached-data.service';
import {CachedKey} from '../tms-enums';
import {DxTreeViewComponent} from 'devextreme-angular';


@Component({
    selector: 'app-courses-planning-detail',
    templateUrl: './courses-planning-detail.component.html'
})
export class CoursesPlanningDetailComponent extends BaseEdit implements OnInit {
    @ViewChild(DxTreeViewComponent, {static: false}) treeView;
    @Input()
    representationId: number;
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
    firstLoad = false;

    constructor(private genericDataService: GenericDataService, private cachedDataService: CachedDataService) {
        super(genericDataService);
        this.entityName = 'coursePlanning';
        this.selectedRepresentationChanged = this.selectedRepresentationChanged.bind(this);
    }

    ngOnInit() {
        super.ngOnInit();

        const data = this.cachedDataService.getData(CachedKey.AdditionalUserProp);
        if (data && data.representationId) {
            if (!this.selectedEntityId) {
                this.entity.representationId = data.representationId;
                this.representationId = data.representationId;
                this.bindCourseCategoriesDataSources(data.representationId);
            }
        }
        this.representationDataSource = this._genericDataService.createCustomDatasourceForSelect('id', 'representation');
        this._genericDataService.getCommonBaseDataForSelect('CourseStatus').subscribe(res => this.courseStatuss = res);
        this.representationPersonDataSource = this._genericDataService.createCustomDatasourceForSelect('id', 'representationPerson');
        // this.courseDataSource = this._genericDataService.createCustomDatasourceForSelect('id', 'course');
        this._genericDataService.getCommonBaseDataForSelect('AgeCategory').subscribe(res => this.ageCategorys = res);
        this._genericDataService.getCommonBaseDataForSelect('ImplementationType').subscribe(res => this.implementationTypes = res);
        this._genericDataService.getCommonBaseDataForSelect('CourseType').subscribe(res => this.courseTypes = res);
        this._genericDataService.getCommonBaseDataForSelect('RunType').subscribe(res => this.runTypes = res);
        this._genericDataService.getCommonBaseDataForSelect('CustomGender').subscribe(res => this.customGenders = res);
        this._genericDataService.getEntitiesByEntityNameForSelect(Entity.AccessLevel).subscribe(res => this.accessLevels = res);
    }

    syncTreeViewSelection(e) {
        const component = (e && e.component) || (this.treeView && this.treeView.instance);

        if (!component) {
            return;
        }
    }

    treeView_itemSelectionChanged(e) {
        if (!e.itemData.isMainCourseCategory) {
            this.entity.courseCategoryId = e.itemData.id;
        }
    }

    selectedRepresentationChanged(e) {
        if (e && e.selectedItem) {
            if (!this.firstLoad) {
                this.entity.courseCategoryId = null;
                this.entity.courseId = null;
                this.bindCourseCategoriesDataSources(e.selectedItem.id);
            }
            this.firstLoad = false;
        }
    }

    afterLoadData(res: any): any {
        this.bindCourseCategoriesDataSources(res.representationId);
        return super.afterLoadData(res);
    }

    private bindCourseCategoriesDataSources(id: any) {
        this.courseCategoryDataSource =
            this._genericDataService.getCustomEntitiesByUrl(`api/courseCategory/GetMainCourseCategoriesByEducationalCenterId?educationalCenterId=${id}`).subscribe((res: any) => {
                this.courseCategoryDataSource = res;
            });
        this.courseDataSource = this._genericDataService.createCustomDatasourceWithAction('id', 'course', `GetByRepresentationIdForSelect?representationId=${id}`);
    }
}
