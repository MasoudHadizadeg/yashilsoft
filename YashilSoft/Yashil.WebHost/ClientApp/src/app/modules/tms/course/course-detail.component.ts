import {Component, Input, OnInit, ViewChild} from '@angular/core';
import {BaseEdit} from '../../../shared/base/classes/base-edit';
import {GenericDataService} from '../../../shared/base/services/generic-data.service';
import {Entity} from '../../../shared/base/base-data/entity.enum';
import {DxTreeViewComponent} from 'devextreme-angular/ui/tree-view';


@Component({
    selector: 'app-course-detail',
    templateUrl: './course-detail.component.html'
})
export class CourseDetailComponent extends BaseEdit implements OnInit {
    @ViewChild(DxTreeViewComponent, {static: false}) treeView;
    @Input()
    educationalCenterId: number;
    @Input()
    courseCategoryId: number;
    courseCategoryDataSource: any;
    educationalCenterDataSource: any;
    skillTypes: any;
    certificateTypes: any;
    evaluationMethods: any;
    accessLevels: any[] = [];
    firstLoad = false;

    constructor(private genericDataService: GenericDataService) {
        super(genericDataService);
        this.entityName = 'course';
        this.selectedEducationalCenterChanged = this.selectedEducationalCenterChanged.bind(this);
    }

    ngOnInit() {
        super.ngOnInit();
        if (this.selectedEntityId) {
            this.firstLoad = true;
        } else if (!this.selectedEntityId && this.educationalCenterId) {
            this.entity.educationalCenterId = this.educationalCenterId;
            this.entity.courseCategoryId = this.courseCategoryId;
            this.bindDataSources(this.educationalCenterId);
            this.firstLoad = true;
        } else {
            this.firstLoad = false;
        }
        this.educationalCenterDataSource = this._genericDataService.createCustomDatasourceForSelect('id', 'educationalCenter');
        this._genericDataService.getCommonBaseDataForSelect('SkillType').subscribe(res => this.skillTypes = res);
        this._genericDataService.getCommonBaseDataForSelect('CertificateType').subscribe(res => this.certificateTypes = res);
        this._genericDataService.getCommonBaseDataForSelect('EvaluationMethod').subscribe(res => this.evaluationMethods = res);
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

    allowSetEducationalCenter() {
        return this.educationalCenterId != null && this.educationalCenterId !== undefined;
    }

    selectedEducationalCenterChanged(e) {
        if (e && e.selectedItem) {
            if (!this.firstLoad) {
                this.entity.courseCategoryId = null;
                this.bindDataSources(e.selectedItem.id);
            }
            this.firstLoad = false;
        }
    }

    afterLoadData(res: any): any {
        this.bindDataSources(this.entity.educationalCenterId)
        return super.afterLoadData(res);
    }

    private bindDataSources(id: any) {
        this.courseCategoryDataSource =
            this._genericDataService.getCustomEntitiesByUrl(`api/courseCategory/GetMainCourseCategoriesByEducationalCenterId?educationalCenterId=${id}`).subscribe((res: any) => {
                this.courseCategoryDataSource = res;
            });
    }
}
