import {Component, Input, OnInit} from '@angular/core';
import {BaseEdit} from '../../../shared/base/classes/base-edit';
import {GenericDataService} from '../../../shared/base/services/generic-data.service';
import {Entity} from '../../../shared/base/base-data/entity.enum';


@Component({
    selector: 'app-course-category-detail',
    templateUrl: './course-category-detail.component.html'
})
export class CourseCategoryDetailComponent extends BaseEdit implements OnInit {
    @Input()
    educationalCenterId: number;
    @Input()
    educationalCenterMainCourseCategoryId: number;
    @Input()
    parentId: number;
    parentDataSource: any;
    educationalCenterDataSource: any;
    accessLevels: any[] = [];
    mainCourseCategories: any[] = [];

    constructor(private genericDataService: GenericDataService) {
        super(genericDataService);
        this.entityName = 'courseCategory';
    }

    ngOnInit() {
        super.ngOnInit();
        if (!this.selectedEntityId && this.educationalCenterId) {
            this.entity.educationalCenterId = this.educationalCenterId;
            this.entity.educationalCenterMainCourseCategoryId = this.educationalCenterMainCourseCategoryId;
            this.entity.parentId = this.parentId;
        }
        // this.parentDataSource = this._genericDataService.createCustomDatasourceForSelect('id', 'courseCategory');
        this._genericDataService.getCustomEntitiesByUrl(`api/courseCategory/GetByEducationalCenterMainCourseCategoryId/${this.educationalCenterMainCourseCategoryId}`)
            .subscribe(res => {
                if (this.selectedEntityId) {
                    res = res.filter(x => x.id !== this.selectedEntityId);
                }
                this.parentDataSource = res;
            });
        this.educationalCenterDataSource = this._genericDataService.createCustomDatasourceForSelect('id', 'educationalCenter');
        this._genericDataService.getEntitiesByEntityNameForSelect(Entity.AccessLevel).subscribe(res => this.accessLevels = res);
        this._genericDataService.getCustomEntitiesByUrl(`api/educationalCenterMainCourseCategory/GetByEducationalCenterId/${this.educationalCenterId}`)
            .subscribe(res => {
                this.mainCourseCategories = res
            });
    }

    allowSetMainCourseCategories() {
        return (this.entity && this.entity.id) || this.educationalCenterMainCourseCategoryId != null;
    }

    allowSetEducationalCenter() {
        return this.educationalCenterId != null && this.educationalCenterId !== undefined;
    }

    allowSEducationalCenterMainCourseCategoryId() {
        return this.educationalCenterMainCourseCategoryId != null && this.educationalCenterMainCourseCategoryId !== undefined;
    }
}
