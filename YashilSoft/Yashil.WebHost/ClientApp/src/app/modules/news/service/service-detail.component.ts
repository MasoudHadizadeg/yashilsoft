import {Component, Input, OnInit} from '@angular/core';
import {BaseEdit} from '../../../shared/base/classes/base-edit';
import {GenericDataService} from '../../../shared/base/services/generic-data.service';
import {Entity} from '../../../shared/base/base-data/entity.enum';


@Component({
    selector: 'app-service-detail',
    templateUrl: './service-detail.component.html'
})
export class ServiceDetailComponent extends BaseEdit implements OnInit {
    @Input()
    parentId: number;
    @Input()
    appEntityId: number;
    @Input()
    accessLevelId: number;
    parentDataSource: any;
    appEntityDataSource: any;
    accessLevels: any[] = [];

    constructor(private genericDataService: GenericDataService) {
        super(genericDataService);
        this.entityName = 'service';
    }

    ngOnInit() {
        super.ngOnInit();
        if (this.parentId) {
            this.entity.parentId = this.parentId;
        }
        if (this.appEntityId) {
            this.entity.appEntityId = this.appEntityId;
        }
        if (this.accessLevelId) {
            this.entity.accessLevelId = this.accessLevelId;
        }

        this.parentDataSource = this._genericDataService.createCustomDatasourceForSelect('id', 'service');
        this.appEntityDataSource = this._genericDataService.createCustomDatasourceForSelect('id', 'appEntity');
        this._genericDataService.getEntitiesByEntityNameForSelect(Entity.AccessLevel).subscribe(res => this.accessLevels = res);
    }
}
