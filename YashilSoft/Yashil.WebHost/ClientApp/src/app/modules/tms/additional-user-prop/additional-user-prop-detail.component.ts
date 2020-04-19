import {Component, OnInit} from '@angular/core';
import {BaseEdit} from '../../../shared/base/classes/base-edit';
import {GenericDataService} from '../../../shared/base/services/generic-data.service';
import {Entity} from '../../../shared/base/base-data/entity.enum';


@Component({
    selector: 'app-additional-user-prop-detail',
    templateUrl: './additional-user-prop-detail.component.html'
})
export class AdditionalUserPropDetailComponent extends BaseEdit implements OnInit {
    userDataSource: any;
    representationDataSource: any;
    accessLevels: any[] = [];

    constructor(private genericDataService: GenericDataService) {
        super(genericDataService);
        this.entityName = 'additionalUserProp';
    }

    ngOnInit() {
        super.ngOnInit();
        this.userDataSource = this._genericDataService.createCustomDatasourceForSelect('id', 'user');
        this.representationDataSource = this._genericDataService.createCustomDatasourceForSelect('id', 'representation');
        this._genericDataService.getEntitiesByEntityNameForSelect(Entity.AccessLevel).subscribe(res => this.accessLevels = res);
    }
}
