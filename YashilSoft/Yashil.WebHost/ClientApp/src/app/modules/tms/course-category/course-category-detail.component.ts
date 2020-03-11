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
    parentDataSource: any;
    educationalCenterDataSource: any;
    accessLevels: any[] = [];

    constructor(private genericDataService: GenericDataService) {
        super(genericDataService);
        this.entityName = 'courseCategory';
    }

    ngOnInit() {
        super.ngOnInit();
        if (!this.selectedEntityId && this.educationalCenterId) {
            this.entity.educationalCenterId = this.educationalCenterId;
        }
        this.parentDataSource = this._genericDataService.createCustomDatasourceForSelect('id', 'courseCategory');
        this.educationalCenterDataSource = this._genericDataService.createCustomDatasourceForSelect('id', 'educationalCenter');
        this._genericDataService.getEntitiesByEntityNameForSelect(Entity.AccessLevel).subscribe(res => this.accessLevels = res);
    }

    allowSetEducationalCenter() {
        return this.educationalCenterId != null && this.educationalCenterId !== undefined;
    }
}
